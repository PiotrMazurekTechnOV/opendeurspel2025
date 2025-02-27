namespace QuizUI
{
    partial class lokaalchooser
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
            this.labelwelklok = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.EnterBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelwelklok
            // 
            this.labelwelklok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelwelklok.AutoSize = true;
            this.labelwelklok.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelwelklok.Location = new System.Drawing.Point(152, 46);
            this.labelwelklok.Margin = new System.Windows.Forms.Padding(0);
            this.labelwelklok.Name = "labelwelklok";
            this.labelwelklok.Size = new System.Drawing.Size(168, 25);
            this.labelwelklok.TabIndex = 0;
            this.labelwelklok.Text = "Welk lokaal is dit?";
            this.labelwelklok.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(176, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EnterBtn
            // 
            this.EnterBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterBtn.Location = new System.Drawing.Point(167, 133);
            this.EnterBtn.Name = "EnterBtn";
            this.EnterBtn.Size = new System.Drawing.Size(130, 29);
            this.EnterBtn.TabIndex = 2;
            this.EnterBtn.Text = "Enter";
            this.EnterBtn.UseVisualStyleBackColor = true;
            this.EnterBtn.Click += new System.EventHandler(this.EnterBtn_Click);
            // 
            // lokaalchooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(484, 230);
            this.Controls.Add(this.EnterBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelwelklok);
            this.Name = "lokaalchooser";
            this.Text = "lokaalchooser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelwelklok;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button EnterBtn;
    }
}