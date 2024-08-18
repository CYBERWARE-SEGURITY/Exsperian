namespace Exsperian
{
    partial class MsgWarning
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
            this.BarTor = new System.Windows.Forms.TextBox();
            this.exit = new System.Windows.Forms.Button();
            this.exec = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BarTor
            // 
            this.BarTor.BackColor = System.Drawing.Color.Gray;
            this.BarTor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BarTor.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.BarTor.Location = new System.Drawing.Point(-1, 0);
            this.BarTor.Multiline = true;
            this.BarTor.Name = "BarTor";
            this.BarTor.ReadOnly = true;
            this.BarTor.Size = new System.Drawing.Size(624, 36);
            this.BarTor.TabIndex = 0;
            this.BarTor.UseWaitCursor = true;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Red;
            this.exit.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(104, 262);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(124, 54);
            this.exit.TabIndex = 1;
            this.exit.Text = "EXIT";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // exec
            // 
            this.exec.BackColor = System.Drawing.Color.Navy;
            this.exec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exec.Location = new System.Drawing.Point(332, 262);
            this.exec.Name = "exec";
            this.exec.Size = new System.Drawing.Size(121, 54);
            this.exec.TabIndex = 2;
            this.exec.Text = "RUN";
            this.exec.UseVisualStyleBackColor = false;
            this.exec.Click += new System.EventHandler(this.exec_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Gray;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(13, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(599, 24);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "                                                            WARNING";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(8, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(609, 130);
            this.label1.TabIndex = 4;
            this.label1.Text = "THIS PROGRAM IS MALWARE THAT CAN CAUSE\r\n DAMAGE AND LOSS OF DATA TO YOUR COMPUTER" +
    ". \r\n\r\nDO YOU REALLY WANT TO RUN IT?\r\nIF NOT, CLICK \'EXIT\'";
            // 
            // MsgWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(624, 328);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.exec);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.BarTor);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MsgWarning";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MsgWarning";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BarTor;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button exec;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}