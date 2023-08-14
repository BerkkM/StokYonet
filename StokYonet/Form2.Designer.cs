namespace StokYonet
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.anaPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUrun = new StokYonet.KullaniciButton();
            this.btnMstr = new StokYonet.KullaniciButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSip = new StokYonet.KullaniciButton();
            this.btnCat = new StokYonet.KullaniciButton();
            this.btnKul = new StokYonet.KullaniciButton();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.anaPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUrun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMstr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKul)).BeginInit();
            this.SuspendLayout();
            // 
            // anaPanel
            // 
            this.anaPanel.Controls.Add(this.panel2);
            this.anaPanel.Controls.Add(this.panel1);
            this.anaPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.anaPanel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.anaPanel.Location = new System.Drawing.Point(0, 0);
            this.anaPanel.Name = "anaPanel";
            this.anaPanel.Size = new System.Drawing.Size(1146, 670);
            this.anaPanel.TabIndex = 3;
            this.anaPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.anaPanel_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 648);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1146, 22);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnUrun);
            this.panel1.Controls.Add(this.btnMstr);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSip);
            this.panel1.Controls.Add(this.btnCat);
            this.panel1.Controls.Add(this.btnKul);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1146, 127);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(708, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ürün";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(568, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Müşteri";
            // 
            // btnUrun
            // 
            this.btnUrun.Image = ((System.Drawing.Image)(resources.GetObject("btnUrun.Image")));
            this.btnUrun.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnUrun.ImageHover")));
            this.btnUrun.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnUrun.ImageNormal")));
            this.btnUrun.Location = new System.Drawing.Point(692, 12);
            this.btnUrun.Name = "btnUrun";
            this.btnUrun.Size = new System.Drawing.Size(77, 57);
            this.btnUrun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnUrun.TabIndex = 2;
            this.btnUrun.TabStop = false;
            this.btnUrun.Click += new System.EventHandler(this.btnUrun_Click);
            // 
            // btnMstr
            // 
            this.btnMstr.Image = ((System.Drawing.Image)(resources.GetObject("btnMstr.Image")));
            this.btnMstr.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnMstr.ImageHover")));
            this.btnMstr.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnMstr.ImageNormal")));
            this.btnMstr.Location = new System.Drawing.Point(562, 12);
            this.btnMstr.Name = "btnMstr";
            this.btnMstr.Size = new System.Drawing.Size(77, 57);
            this.btnMstr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMstr.TabIndex = 12;
            this.btnMstr.TabStop = false;
            this.btnMstr.Click += new System.EventHandler(this.btnMstr_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(434, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Kategori";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(821, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Sipariş";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(305, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kullanıcı";
            // 
            // btnSip
            // 
            this.btnSip.Image = ((System.Drawing.Image)(resources.GetObject("btnSip.Image")));
            this.btnSip.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnSip.ImageHover")));
            this.btnSip.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnSip.ImageNormal")));
            this.btnSip.Location = new System.Drawing.Point(805, 12);
            this.btnSip.Name = "btnSip";
            this.btnSip.Size = new System.Drawing.Size(77, 57);
            this.btnSip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSip.TabIndex = 13;
            this.btnSip.TabStop = false;
            this.btnSip.Click += new System.EventHandler(this.btnSip_Click);
            // 
            // btnCat
            // 
            this.btnCat.Image = ((System.Drawing.Image)(resources.GetObject("btnCat.Image")));
            this.btnCat.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnCat.ImageHover")));
            this.btnCat.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnCat.ImageNormal")));
            this.btnCat.Location = new System.Drawing.Point(434, 12);
            this.btnCat.Name = "btnCat";
            this.btnCat.Size = new System.Drawing.Size(77, 57);
            this.btnCat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCat.TabIndex = 11;
            this.btnCat.TabStop = false;
            this.btnCat.Click += new System.EventHandler(this.kullaniciButton3_Click);
            // 
            // btnKul
            // 
            this.btnKul.Image = ((System.Drawing.Image)(resources.GetObject("btnKul.Image")));
            this.btnKul.ImageHover = ((System.Drawing.Image)(resources.GetObject("btnKul.ImageHover")));
            this.btnKul.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnKul.ImageNormal")));
            this.btnKul.Location = new System.Drawing.Point(306, 12);
            this.btnKul.Name = "btnKul";
            this.btnKul.Size = new System.Drawing.Size(77, 57);
            this.btnKul.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnKul.TabIndex = 10;
            this.btnKul.TabStop = false;
            this.btnKul.Click += new System.EventHandler(this.btnKul_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 34);
            this.label3.TabIndex = 9;
            this.label3.Text = "Stok Yönetimi";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1146, 670);
            this.Controls.Add(this.anaPanel);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.anaPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUrun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMstr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKul)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel anaPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private KullaniciButton btnUrun;
        private KullaniciButton btnSip;
        private KullaniciButton btnMstr;
        private KullaniciButton btnCat;
        private KullaniciButton btnKul;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}