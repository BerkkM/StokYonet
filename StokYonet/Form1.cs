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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\berko\OneDrive\Belgeler\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxSif_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSif.Checked == false)
                txtSif.UseSystemPasswordChar = true;
            else
                txtSif.UseSystemPasswordChar = false;
        }

        private void txtSif_TextChanged(object sender, EventArgs e)
        {

        }

        private void tblSil_Click(object sender, EventArgs e)
        {
            txtGiris.Clear();
            txtSif.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Uygulamadan Çıkmak İster Misin?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit()
                ;
            }

        
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void buttonLgn_Click(object sender, EventArgs e)
        {
            try
            {
                cm = new SqlCommand("SELECT * FROM tbUser WHERE username=@username AND password=@password",con);
                cm.Parameters.AddWithValue("@username", txtGiris.Text);
                cm.Parameters.AddWithValue("@password", txtSif.Text);
                con.Open();
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    MessageBox.Show("Hoşgeldin " + dr["fullname"].ToString() + " | ", "Erişim İzni", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2 main = new Form2();
                    this.Hide();
                    main.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Geçersiz Kullanıcı Adı ve Şifre", "Erişim Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
