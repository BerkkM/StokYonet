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

    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\berko\OneDrive\Belgeler\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        
        public Form5()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                if (MessageBox.Show("Bu kategoriyi kaydetmek ister misin?", "Kaydediliyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("Insert Into tbCategory(catname)VALUES(@catname)", con);
                    cm.Parameters.AddWithValue("@catname", textBox1.Text);
                    
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kategori Kaydedildi");
                    Clear();
                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Clear()
        {
            textBox1.Clear();
           
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUp.Enabled = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (MessageBox.Show("Güncellemekten emin misin?", "Güncelleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE tbCategory SET catname = @catname WHERE catid LIKE '" + lbcatid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@catname", textBox1.Text);
                    
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kategori başarı ile güncellendi");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
