using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StokYonet
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\berko\OneDrive\Belgeler\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (MessageBox.Show("Bu müşteriyi kaydetmek ister misin?", "Kaydediliyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("Insert Into tbCustomer(cname,cphone)VALUES(@cname,@cphone)", con);
                    cm.Parameters.AddWithValue("@cname", textBox1.Text);
                    cm.Parameters.AddWithValue("@cphone", textBox4.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Müşteri Kaydedildi");
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
            textBox4.Clear();
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

                    cm = new SqlCommand("UPDATE tbCustomer SET cname = @cname, cphone=@cphone WHERE cid LIKE '" + lblid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@cname", textBox1.Text);

                    cm.Parameters.AddWithValue("@cphone", textBox4.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Müşteri başarı ile güncellendi");
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

