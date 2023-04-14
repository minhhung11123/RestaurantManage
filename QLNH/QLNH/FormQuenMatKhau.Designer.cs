namespace QLNH
{
    partial class FormQuenMatKhau
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
            this.btnHT = new System.Windows.Forms.Button();
            this.txtUserNameFP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPass2FP = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHT
            // 
            this.btnHT.BackColor = System.Drawing.Color.Transparent;
            this.btnHT.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHT.ForeColor = System.Drawing.Color.Black;
            this.btnHT.Location = new System.Drawing.Point(429, 290);
            this.btnHT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHT.Name = "btnHT";
            this.btnHT.Size = new System.Drawing.Size(237, 47);
            this.btnHT.TabIndex = 40;
            this.btnHT.Text = "Hoàn Tất";
            this.btnHT.UseVisualStyleBackColor = false;
            this.btnHT.Click += new System.EventHandler(this.btnHT_Click);
            // 
            // txtUserNameFP
            // 
            this.txtUserNameFP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserNameFP.Location = new System.Drawing.Point(429, 151);
            this.txtUserNameFP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserNameFP.Name = "txtUserNameFP";
            this.txtUserNameFP.Size = new System.Drawing.Size(237, 32);
            this.txtUserNameFP.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RosyBrown;
            this.label5.Location = new System.Drawing.Point(244, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 33);
            this.label5.TabIndex = 38;
            this.label5.Text = "Tài khoản:";
            // 
            // txtPass2FP
            // 
            this.txtPass2FP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass2FP.Location = new System.Drawing.Point(429, 242);
            this.txtPass2FP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPass2FP.Name = "txtPass2FP";
            this.txtPass2FP.Size = new System.Drawing.Size(237, 32);
            this.txtPass2FP.TabIndex = 36;
            this.txtPass2FP.UseSystemPasswordChar = true;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(429, 197);
            this.txtNewPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(237, 32);
            this.txtNewPass.TabIndex = 37;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.RosyBrown;
            this.label4.Location = new System.Drawing.Point(231, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 33);
            this.label4.TabIndex = 34;
            this.label4.Text = "Mật khẩu 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RosyBrown;
            this.label3.Location = new System.Drawing.Point(192, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 33);
            this.label3.TabIndex = 35;
            this.label3.Text = "Mật khẩu mới:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(235, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 48);
            this.label1.TabIndex = 33;
            this.label1.Text = "QUÊN MẬT KHẨU";
            // 
            // FormQuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLNH.Properties.Resources._0_83oELz_ho5O2iyNt;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHT);
            this.Controls.Add(this.txtUserNameFP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPass2FP);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormQuenMatKhau";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnHT;
        private System.Windows.Forms.TextBox txtUserNameFP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPass2FP;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}