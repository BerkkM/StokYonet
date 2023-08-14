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
    public partial class MusteriForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\berko\OneDrive\Belgeler\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public MusteriForm()
        {
            InitializeComponent();
            LoadCustomer();
        }
        public void LoadCustomer()
        {
            int i = 0;
            dgvMus.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbCustomer", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvMus.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            con.Close();

        }

        private void dgvMus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvMus.Columns[e.ColumnIndex].Name;
            if (colName == "Column5")
            {
                Form4 musteriForm = new Form4();
                musteriForm.lblid.Text = dgvMus.Rows[e.RowIndex].Cells[1].Value.ToString();
                musteriForm.textBox1.Text = dgvMus.Rows[e.RowIndex].Cells[2].Value.ToString();
                musteriForm.textBox4.Text = dgvMus.Rows[e.RowIndex].Cells[3].Value.ToString();

                musteriForm.btnSave.Enabled = false;
                musteriForm.btnUp.Enabled = true;
                

                musteriForm.ShowDialog();
            }
            else if (colName == "Column6")
            {
                if (MessageBox.Show("Kullanıcıyı Silmekten Emin Misin?", "Kayıt Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbCustomer WHERE cid LIKE '" + dgvMus.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarıyla Silindi");
                }
            }
            LoadCustomer();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            {
                Form4 musteriForm = new Form4();
                musteriForm.btnSave.Enabled = true;
                musteriForm.btnUp.Enabled = false;
                musteriForm.ShowDialog();
            }
        }
    }

    
    }

