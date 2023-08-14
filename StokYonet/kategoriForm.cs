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
    public partial class kategoriForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\berko\OneDrive\Belgeler\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public kategoriForm()
        {
            InitializeComponent();
            LoadCategory();
        }
        public void LoadCategory()
        {
            int i = 0;
            dgvKat.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbCategory", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvKat.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form5 catForm = new Form5();
            catForm.btnSave.Enabled = true;
            catForm.btnUp.Enabled = false;
            catForm.ShowDialog();
            LoadCategory();

        }

        private void dgvKat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvKat.Columns[e.ColumnIndex].Name;
            if (colName == "Column5")
            {
                Form5 catForm = new Form5();
                catForm.lbcatid.Text = dgvKat.Rows[e.RowIndex].Cells[1].Value.ToString();
                catForm.textBox1.Text = dgvKat.Rows[e.RowIndex].Cells[2].Value.ToString();
                

                catForm.btnSave.Enabled = false;
                catForm.btnUp.Enabled = true;


                catForm.ShowDialog();
            }
            else if (colName == "Column6")
            {
                if (MessageBox.Show("Kategoriyi Silmekten Emin Misin?", "Kayıt Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbCategory WHERE catid LIKE '" + dgvKat.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarıyla Silindi");
                }
            }
            LoadCategory();
        }
    }
    }


