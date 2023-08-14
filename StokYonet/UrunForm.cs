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
    public partial class UrunForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\berko\OneDrive\Belgeler\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public UrunForm()
        {
            InitializeComponent();
            LoadUrun();
        }
        public void LoadUrun()
        {
            int i = 0;
            dgvUrun.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUrun WHERE CONCAT(pname,pfiyat,pacik,pcate) LIKE'%"+txtSearch.Text+"%' ", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUrun.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            {
                Form6 urunForm = new Form6();
                urunForm.btnSave.Enabled = true;
                urunForm.btnUp.Enabled = false;
                urunForm.ShowDialog();
                
            }
        }

        private void dgvUrun_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUrun.Columns[e.ColumnIndex].Name;
            if (colName == "Column5")
            {
                Form6 urunForm = new Form6();
                urunForm.lblpid.Text = dgvUrun.Rows[e.RowIndex].Cells[1].Value.ToString();
                urunForm.textBox1.Text = dgvUrun.Rows[e.RowIndex].Cells[2].Value.ToString();
                urunForm.textBox2.Text = dgvUrun.Rows[e.RowIndex].Cells[3].Value.ToString();
                urunForm.textBox3.Text = dgvUrun.Rows[e.RowIndex].Cells[4].Value.ToString();
                urunForm.textBox5.Text = dgvUrun.Rows[e.RowIndex].Cells[5].Value.ToString();
                urunForm.comboBox1.Text = dgvUrun.Rows[e.RowIndex].Cells[6].Value.ToString();

                urunForm.btnSave.Enabled = false;
                urunForm.btnUp.Enabled = true;


                urunForm.ShowDialog();
            }
            else if (colName == "Column6")
            {
                if (MessageBox.Show("Ürünü Silmekten Emin Misin?", "Kayıt Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbUrun WHERE pid LIKE '" + dgvUrun.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarıyla Silindi");
                }
            }
            LoadUrun();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUrun();
        }
    }
    }


