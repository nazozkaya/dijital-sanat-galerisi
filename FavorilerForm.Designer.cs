using System;

namespace WindowsFormsApp6
{
    partial class FavorilerForm
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
            this.dgvFavoriler = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFavorilerdenKaldır = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFavoriler)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFavoriler
            // 
            this.dgvFavoriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFavoriler.Location = new System.Drawing.Point(48, 12);
            this.dgvFavoriler.Name = "dgvFavoriler";
            this.dgvFavoriler.RowHeadersWidth = 51;
            this.dgvFavoriler.RowTemplate.Height = 24;
            this.dgvFavoriler.Size = new System.Drawing.Size(717, 337);
            this.dgvFavoriler.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ana Sayfa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFavorilerdenKaldır
            // 
            this.btnFavorilerdenKaldır.Location = new System.Drawing.Point(597, 355);
            this.btnFavorilerdenKaldır.Name = "btnFavorilerdenKaldır";
            this.btnFavorilerdenKaldır.Size = new System.Drawing.Size(168, 55);
            this.btnFavorilerdenKaldır.TabIndex = 3;
            this.btnFavorilerdenKaldır.Text = "Favorileri Kaldır";
            this.btnFavorilerdenKaldır.UseVisualStyleBackColor = true;
            this.btnFavorilerdenKaldır.Click += new System.EventHandler(this.btnFavorilerdenKaldir_Click);
            // 
            // FavorilerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFavorilerdenKaldır);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvFavoriler);
            this.Name = "FavorilerForm";
            this.Text = "FavorilerForm";
            this.Load += new System.EventHandler(this.FavorilerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFavoriler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            AnaSayfaForm anaForm = new AnaSayfaForm(kullaniciId);
            anaForm.Show();
            this.Close();
        }
        

        private System.Windows.Forms.DataGridView dgvFavoriler;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFavorilerdenKaldır;
    }
     





}