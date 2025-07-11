using System;

namespace WindowsFormsApp6
{
    partial class AnaSayfaForm
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
            this.lblhosgeldin = new System.Windows.Forms.Label();
            this.btnEserEkle = new System.Windows.Forms.Button();
            this.btnEserListele = new System.Windows.Forms.Button();
            this.btnFavoriler = new System.Windows.Forms.Button();
            this.btnProfil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblhosgeldin
            // 
            this.lblhosgeldin.AutoSize = true;
            this.lblhosgeldin.Location = new System.Drawing.Point(83, 29);
            this.lblhosgeldin.Name = "lblhosgeldin";
            this.lblhosgeldin.Size = new System.Drawing.Size(72, 16);
            this.lblhosgeldin.TabIndex = 0;
            this.lblhosgeldin.Text = "Hoşgeldin!";
            // 
            // btnEserEkle
            // 
            this.btnEserEkle.Location = new System.Drawing.Point(12, 189);
            this.btnEserEkle.Name = "btnEserEkle";
            this.btnEserEkle.Size = new System.Drawing.Size(163, 69);
            this.btnEserEkle.TabIndex = 1;
            this.btnEserEkle.Text = "Eser Ekle";
            this.btnEserEkle.UseVisualStyleBackColor = true;
            this.btnEserEkle.Click += new System.EventHandler(this.btnEserEkle_Click);
            // 
            // btnEserListele
            // 
            this.btnEserListele.Location = new System.Drawing.Point(195, 189);
            this.btnEserListele.Name = "btnEserListele";
            this.btnEserListele.Size = new System.Drawing.Size(163, 69);
            this.btnEserListele.TabIndex = 1;
            this.btnEserListele.Text = "Eser Listele";
            this.btnEserListele.UseVisualStyleBackColor = true;
            this.btnEserListele.Click += new System.EventHandler(this.btnEserListele_Click);
            // 
            // btnFavoriler
            // 
            this.btnFavoriler.Location = new System.Drawing.Point(390, 189);
            this.btnFavoriler.Name = "btnFavoriler";
            this.btnFavoriler.Size = new System.Drawing.Size(163, 69);
            this.btnFavoriler.TabIndex = 1;
            this.btnFavoriler.Text = "Favoriler";
            this.btnFavoriler.UseVisualStyleBackColor = true;
            this.btnFavoriler.Click += new System.EventHandler(this.btnFavoriler_Click);
            // 
            // btnProfil
            // 
            this.btnProfil.Location = new System.Drawing.Point(584, 189);
            this.btnProfil.Name = "btnProfil";
            this.btnProfil.Size = new System.Drawing.Size(163, 69);
            this.btnProfil.TabIndex = 1;
            this.btnProfil.Text = "Profil";
            this.btnProfil.UseVisualStyleBackColor = true;
            this.btnProfil.Click += new System.EventHandler(this.btnProfil_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(573, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lütfen Yapmak İstediğiniz İşlemi Seçin";
            // 
            // AnaSayfaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProfil);
            this.Controls.Add(this.btnFavoriler);
            this.Controls.Add(this.btnEserListele);
            this.Controls.Add(this.btnEserEkle);
            this.Controls.Add(this.lblhosgeldin);
            this.Name = "AnaSayfaForm";
            this.Text = "AnaSayfaForm";
            this.Load += new System.EventHandler(this.AnaSayfaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnProfil_Click_1(object sender, EventArgs e)
        {
            // ProfilForm'u açıyoruz ve giriş yapan kullanıcının ID'sini geçiriyoruz
            var profilForm = new ProfilForm(girisYapanKullaniciId);

            profilForm.Show(); // Profil formunu açıyoruz
        }


        #endregion

        private System.Windows.Forms.Label lblhosgeldin;
        private System.Windows.Forms.Button btnEserEkle;
        private System.Windows.Forms.Button btnEserListele;
        private System.Windows.Forms.Button btnFavoriler;
        private System.Windows.Forms.Button btnProfil;
        private System.Windows.Forms.Label label1;
    }
}