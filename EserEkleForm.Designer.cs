namespace WindowsFormsApp6
{
    partial class EserEkleForm
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
            this.txtEserAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStokMiktari = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbResim = new System.Windows.Forms.PictureBox();
            this.cmbSatisDurumu = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSanatci = new System.Windows.Forms.TextBox();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.btnResimSec = new System.Windows.Forms.Button();
            this.btnEserEkle = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFiyat = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSanatciAdi = new System.Windows.Forms.Label();
            this.txtSanatciAdi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbResim)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEserAdi
            // 
            this.txtEserAdi.Location = new System.Drawing.Point(196, 31);
            this.txtEserAdi.Multiline = true;
            this.txtEserAdi.Name = "txtEserAdi";
            this.txtEserAdi.Size = new System.Drawing.Size(121, 22);
            this.txtEserAdi.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Eser Adı";
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(196, 87);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(121, 24);
            this.cmbKategori.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kategori";
            // 
            // txtStokMiktari
            // 
            this.txtStokMiktari.Location = new System.Drawing.Point(582, 113);
            this.txtStokMiktari.Name = "txtStokMiktari";
            this.txtStokMiktari.Size = new System.Drawing.Size(121, 22);
            this.txtStokMiktari.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Sanatçı Id";
            // 
            // dtpTarih
            // 
            this.dtpTarih.Location = new System.Drawing.Point(196, 323);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(121, 22);
            this.dtpTarih.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Yükleme Tarihi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Açıklama";
            // 
            // pbResim
            // 
            this.pbResim.Location = new System.Drawing.Point(570, 162);
            this.pbResim.Name = "pbResim";
            this.pbResim.Size = new System.Drawing.Size(203, 183);
            this.pbResim.TabIndex = 5;
            this.pbResim.TabStop = false;
            // 
            // cmbSatisDurumu
            // 
            this.cmbSatisDurumu.FormattingEnabled = true;
            this.cmbSatisDurumu.Location = new System.Drawing.Point(582, 18);
            this.cmbSatisDurumu.Name = "cmbSatisDurumu";
            this.cmbSatisDurumu.Size = new System.Drawing.Size(121, 24);
            this.cmbSatisDurumu.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(449, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Satış Durumu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(449, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "Stok Miktarı";
            // 
            // txtSanatci
            // 
            this.txtSanatci.Location = new System.Drawing.Point(196, 146);
            this.txtSanatci.Multiline = true;
            this.txtSanatci.Name = "txtSanatci";
            this.txtSanatci.Size = new System.Drawing.Size(121, 22);
            this.txtSanatci.TabIndex = 0;
            this.txtSanatci.TextChanged += new System.EventHandler(this.txtSanatci_TextChanged);
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(196, 255);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(121, 22);
            this.txtAciklama.TabIndex = 0;
            // 
            // btnResimSec
            // 
            this.btnResimSec.Location = new System.Drawing.Point(412, 217);
            this.btnResimSec.Name = "btnResimSec";
            this.btnResimSec.Size = new System.Drawing.Size(122, 78);
            this.btnResimSec.TabIndex = 7;
            this.btnResimSec.Text = "Resim Seç";
            this.btnResimSec.UseVisualStyleBackColor = true;
            this.btnResimSec.Click += new System.EventHandler(this.btnResimSec_Click);
            // 
            // btnEserEkle
            // 
            this.btnEserEkle.Location = new System.Drawing.Point(370, 353);
            this.btnEserEkle.Name = "btnEserEkle";
            this.btnEserEkle.Size = new System.Drawing.Size(164, 64);
            this.btnEserEkle.TabIndex = 8;
            this.btnEserEkle.Text = "Eser Ekle";
            this.btnEserEkle.UseVisualStyleBackColor = true;
            this.btnEserEkle.Click += new System.EventHandler(this.btnEserEkle_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(449, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 25);
            this.label8.TabIndex = 9;
            this.label8.Text = "Fiyat";
            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(582, 64);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(121, 22);
            this.txtFiyat.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(625, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 64);
            this.button1.TabIndex = 11;
            this.button1.Text = "Ana Sayfa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSanatciAdi
            // 
            this.lblSanatciAdi.AutoSize = true;
            this.lblSanatciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSanatciAdi.Location = new System.Drawing.Point(39, 197);
            this.lblSanatciAdi.Name = "lblSanatciAdi";
            this.lblSanatciAdi.Size = new System.Drawing.Size(112, 25);
            this.lblSanatciAdi.TabIndex = 12;
            this.lblSanatciAdi.Text = "Sanatçı Adı";
            // 
            // txtSanatciAdi
            // 
            this.txtSanatciAdi.Location = new System.Drawing.Point(196, 197);
            this.txtSanatciAdi.Name = "txtSanatciAdi";
            this.txtSanatciAdi.Size = new System.Drawing.Size(121, 22);
            this.txtSanatciAdi.TabIndex = 13;
            this.txtSanatciAdi.TextChanged += new System.EventHandler(this.txtSanatciAdi_TextChanged);
            // 
            // EserEkleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtSanatciAdi);
            this.Controls.Add(this.lblSanatciAdi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFiyat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnEserEkle);
            this.Controls.Add(this.btnResimSec);
            this.Controls.Add(this.cmbSatisDurumu);
            this.Controls.Add(this.pbResim);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStokMiktari);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtSanatci);
            this.Controls.Add(this.txtEserAdi);
            this.Name = "EserEkleForm";
            this.Text = "EserEkleForm";
            this.Load += new System.EventHandler(this.EserEkleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbResim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEserAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStokMiktari;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbResim;
        private System.Windows.Forms.ComboBox cmbSatisDurumu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSanatci;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.Button btnResimSec;
        private System.Windows.Forms.Button btnEserEkle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFiyat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblSanatciAdi;
        private System.Windows.Forms.TextBox txtSanatciAdi;
    }
}