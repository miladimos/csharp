namespace notepad
{
    partial class frmGoto
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLineNumber = new System.Windows.Forms.TextBox();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnGotoCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line number:";
            // 
            // txtLineNumber
            // 
            this.txtLineNumber.Location = new System.Drawing.Point(15, 37);
            this.txtLineNumber.Name = "txtLineNumber";
            this.txtLineNumber.Size = new System.Drawing.Size(299, 22);
            this.txtLineNumber.TabIndex = 1;
            // 
            // btnGoto
            // 
            this.btnGoto.Location = new System.Drawing.Point(133, 78);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(75, 23);
            this.btnGoto.TabIndex = 2;
            this.btnGoto.Text = "Go to";
            this.btnGoto.UseVisualStyleBackColor = true;
            // 
            // btnGotoCancel
            // 
            this.btnGotoCancel.Location = new System.Drawing.Point(239, 78);
            this.btnGotoCancel.Name = "btnGotoCancel";
            this.btnGotoCancel.Size = new System.Drawing.Size(75, 23);
            this.btnGotoCancel.TabIndex = 2;
            this.btnGotoCancel.Text = "Cancel";
            this.btnGotoCancel.UseVisualStyleBackColor = true;
            this.btnGotoCancel.Click += new System.EventHandler(this.btnGotoCancel_Click);
            // 
            // frmGoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 141);
            this.Controls.Add(this.btnGotoCancel);
            this.Controls.Add(this.btnGoto);
            this.Controls.Add(this.txtLineNumber);
            this.Controls.Add(this.label1);
            this.Name = "frmGoto";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Go To Line";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLineNumber;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.Button btnGotoCancel;
    }
}