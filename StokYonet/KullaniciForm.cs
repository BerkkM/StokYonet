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

namespace StokYonet
{
    public partial class KullaniciForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\berko\OneDrive\Belgeler\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public KullaniciForm()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != textBox5.Text)
                {
                    MessageBox.Show("Parola Eşleşmiyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bu kullanıcıyı kaydetmek ister misin?", "Kaydediliyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("Insert Into tbUser(username,fullname,password,phone)VALUES(@username,@fullname,@password,@phone)", con);
                    cm.Parameters.AddWithValue("@username", textBox1.Text);
                    cm.Parameters.AddWithValue("@fullname", textBox2.Text);
                    cm.Parameters.AddWithValue("@password", textBox3.Text);
                    cm.Parameters.AddWithValue("@phone", textBox4.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kullanıcı Kaydedildi");
                    Clear();
                }

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUp.Enabled = false;

        }

        public void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void KullaniciForm_Load(object sender, EventArgs e)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != textBox5.Text)
                {
                    MessageBox.Show("Parola Eşleşmiyor", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Güncellemekten emin misin?", "Güncelleniyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cm = new SqlCommand("UPDATE tbUser SET fullname = @fullname, password=@password, phone=@phone WHERE username LIKE '"+textBox1.Text +"' ", con);                    
                    cm.Parameters.AddWithValue("@fullname", textBox2.Text);
                    cm.Parameters.AddWithValue("@password", textBox3.Text);
                    cm.Parameters.AddWithValue("@phone", textBox4.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kullanıcı başarı ile güncellendi");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
    }

