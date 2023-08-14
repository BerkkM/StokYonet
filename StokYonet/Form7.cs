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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StokYonet
{
    public partial class Form7 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\berko\OneDrive\Belgeler\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int adt = 0;

        public Form7()
        {
            InitializeComponent();
            LoadUrun();
            LoadCustomer();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }
        public void LoadCustomer()
        {
            int i = 0;
            dgvMus.Rows.Clear();
            cm = new SqlCommand("SELECT cid,cname FROM tbCustomer WHERE CONCAT(cid,cname) LIKE '%"+txtSM.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvMus.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();

        }
        public void LoadUrun()
        {
            int i = 0;
            dgvUrun.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUrun WHERE CONCAT(pid,pname,pfiyat,pacik,pcate) LIKE'%" + txtSU.Text + "%' ", con);
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void txtSM_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtSU_TextChanged(object sender, EventArgs e)
        {
            LoadUrun();
        }

        

        private void adet_ValueChanged(object sender, EventArgs e)
        {
            GetAdet();
            if (Convert.ToInt16(adet.Value) > adt)
            {
                MessageBox.Show("Stok miktarı yeterli değil", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                adet.Value = adet.Value - 1;
                return;

            }
            if (Convert.ToInt16(adet.Value) > 0)
            {
                int total = Convert.ToInt16(txtfyt.Text) * Convert.ToInt16(adet.Value);
                txttop.Text = total.ToString();
            }
            }

        private void dgvMus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcid.Text = dgvMus.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtcname.Text = dgvMus.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgvUrun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtuid.Text = dgvUrun.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtua.Text = dgvUrun.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtfyt.Text = dgvUrun.Rows[e.RowIndex].Cells[4].Value.ToString();
            
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcid.Text =="")
                {
                    MessageBox.Show("Lütfen Müşteri Seçin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtuid.Text == "")
                {
                    MessageBox.Show("Lütfen Ürün Seçin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bu siparişi eklemek ister misin?", "Kaydediliyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("Insert Into tbSip(odate,pid,cid,adet,fiyat,toplam)VALUES(@odate,@pid,@cid,@adet,@fiyat,@toplam)", con);
                    cm.Parameters.AddWithValue("@odate", dateTimePicker1.Value);
                    cm.Parameters.AddWithValue("@pid", Convert.ToInt32(txtuid.Text));
                    cm.Parameters.AddWithValue("@cid", Convert.ToInt32(txtcid.Text));
                    cm.Parameters.AddWithValue("@adet", Convert.ToInt32(adet.Value));
                    cm.Parameters.AddWithValue("@fiyat", Convert.ToInt32(txtfyt.Text));
                    cm.Parameters.AddWithValue("@toplam", Convert.ToInt32(txttop.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sipariş eklendi.");
                    

                    cm = new SqlCommand("UPDATE tbUrun SET padet =(padet-@padet) WHERE pid LIKE '" + txtuid.Text + "' ", con);
                    
                    cm.Parameters.AddWithValue("@padet", Convert.ToInt16(adet.Value));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    Clear();
                    LoadUrun();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

        }
        public void Clear()
        {
            txtcid.Clear();
            txtcname.Clear();

            txtuid.Clear();
            txtua.Clear();

            txtfyt.Clear();
            adet.Value = 0;
            txttop.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            Clear();
            btnekle.Enabled = true;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        

        public void GetAdet()
        {
            cm = new SqlCommand("SELECT padet FROM tbUrun WHERE pid= '" + txtuid.Text + "' ", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                adt = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void dgvUrun_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
