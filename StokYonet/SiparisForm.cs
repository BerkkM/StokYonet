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
    public partial class SiparisForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\berko\OneDrive\Belgeler\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public SiparisForm()
        {
            InitializeComponent();
            LoadSip();
        }
        public void LoadSip()
        {
            double toplam = 0;
            int i = 0;
            dgvSip.Rows.Clear();
            cm = new SqlCommand("SELECT oid, odate, O.pid, P.pname, O.cid, C.cname, adet, fiyat, toplam FROM tbSip AS O JOIN tbCustomer AS C ON O.cid=C.cid JOIN tbUrun AS P ON O.pid=P.pid WHERE CONCAT(oid, odate, O.pid, P.pname, O.cid, C.cname, adet, fiyat) LIKE '%"+textBox1.Text+"%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvSip.Rows.Add(i, dr[0].ToString(),Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                toplam += Convert.ToInt32(dr[8].ToString());
            }
            dr.Close();
            con.Close();

            label5.Text = i.ToString();
            label6.Text = toplam.ToString();


        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form7 sipModul = new Form7();
            sipModul.btnekle.Enabled = true;
            
            sipModul.ShowDialog();
            LoadSip();

        }

        private void dgvUrun_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSip.Columns[e.ColumnIndex].Name;
            if (colName == "Column5")
            {
                Form7 sipModul = new Form7();
                sipModul.lblqid.Text = dgvSip.Rows[e.RowIndex].Cells[1].Value.ToString();
                sipModul.dateTimePicker1.Text = dgvSip.Rows[e.RowIndex].Cells[2].Value.ToString();
                sipModul.txtuid.Text = dgvSip.Rows[e.RowIndex].Cells[3].Value.ToString();
                sipModul.txtcid.Text = dgvSip.Rows[e.RowIndex].Cells[4].Value.ToString();
                sipModul.adet.Value = Convert.ToInt32(dgvSip.Rows[e.RowIndex].Cells[5].Value.ToString());
                sipModul.txtfyt.Text = dgvSip.Rows[e.RowIndex].Cells[6].Value.ToString();

                sipModul.btnekle.Enabled = false;
                


                sipModul.ShowDialog();
            }
            else if (colName == "Column6")
            {
                if (MessageBox.Show("Ürünü Silmekten Emin Misin?", "Kayıt Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbSip WHERE oid LIKE '" + dgvSip.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarıyla Silindi");

                    cm = new SqlCommand("UPDATE tbUrun SET padet =(padet+@padet) WHERE pid LIKE '" + dgvSip.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", con);

                    cm.Parameters.AddWithValue("@padet", Convert.ToInt16(dgvSip.Rows[e.RowIndex].Cells[5].Value.ToString()));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                }
            }
            LoadSip();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadSip();
        }
    }
}
