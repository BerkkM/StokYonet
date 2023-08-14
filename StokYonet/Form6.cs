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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\berko\OneDrive\Belgeler\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Form6()
        {
            InitializeComponent();
            LoadCategory();
        }
        public void LoadCategory()
        {
            comboBox1.Items.Clear();
            cm = new SqlCommand("SELECT catname FROM tbCategory", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (MessageBox.Show("Bu ürünü kaydetmek ister misin?", "Kaydediliyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("Insert Into tbUrun(pname,padet,pfiyat,pacik,pcate)VALUES(@pname,@padet,@pfiyat,@pacik,@pcate)", con);
                    cm.Parameters.AddWithValue("@pname", textBox1.Text);
                    cm.Parameters.AddWithValue("@padet", Convert.ToInt16(textBox2.Text));
                    cm.Parameters.AddWithValue("@pfiyat", Convert.ToInt16(textBox3.Text));
                    cm.Parameters.AddWithValue("@pacik", textBox5.Text);
                    cm.Parameters.AddWithValue("@pcate", comboBox1.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Ürün Kaydedildi");
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
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            textBox5.Clear();

        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUp.Enabled = false;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (MessageBox.Show("Güncellemekten emin misin?", "Güncelleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE tbUrun SET pname = @pname, padet=@padet, pfiyat=@pfiyat, pacik=@pacik, pcate=@pcate WHERE pid LIKE '" + lblpid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pname", textBox1.Text);
                    cm.Parameters.AddWithValue("@padet", Convert.ToInt16(textBox2.Text));
                    cm.Parameters.AddWithValue("@pfiyat", Convert.ToInt16(textBox3.Text));
                    cm.Parameters.AddWithValue("@pacik", textBox5.Text);
                    cm.Parameters.AddWithValue("@pcate", comboBox1.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Ürün başarı ile güncellendi");
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
    

