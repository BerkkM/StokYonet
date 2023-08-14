using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokYonet
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\berko\OneDrive\Belgeler\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Form3()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUser", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i,dr[0].ToString(),dr[1].ToString(),dr[2].ToString(),dr[3].ToString());
            }
            dr.Close();
            con.Close();

        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Column5")
            {
                KullaniciForm userModule = new KullaniciForm();
                userModule.textBox1.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.textBox2.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.textBox3.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.textBox4.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();

                userModule.btnSave.Enabled = false;
                userModule.btnUp.Enabled = true;
                userModule.textBox1.Enabled = false;

                userModule.ShowDialog();
            }
            else if (colName == "Column6")
            {
                if (MessageBox.Show("Kullanıcıyı Silmekten Emin Misin?", "Kayıt Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbUser WHERE username LIKE '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarıyla Silindi");
                }
            }
            }

            private void kullaniciButton2_Click(object sender, EventArgs e)
        {
            KullaniciForm kullaniciForm = new KullaniciForm();
            kullaniciForm.btnSave.Enabled = true;
            kullaniciForm.btnUp.Enabled = false;
            kullaniciForm.ShowDialog();
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
