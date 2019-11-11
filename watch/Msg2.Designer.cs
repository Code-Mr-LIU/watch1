namespace watch
{
    partial class Msg2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Msg2));
            this.labelX1 = new System.Windows.Forms.Label();
            this.btnQD = new System.Windows.Forms.Button();
            this.btnQX = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // \
            this.labelX1.Location = new System.Drawing.Point(-1, 22);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(348, 37);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "labelX1";
            // 
            // btnQD
            // 
            this.btnQD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQD.Location = new System.Drawing.Point(44, 78);
            this.btnQD.Name = "btnQD";
            this.btnQD.Size = new System.Drawing.Size(90, 34);
            this.btnQD.TabIndex = 1;
            this.btnQD.Text = "确定";
            this.btnQD.Click += new System.EventHandler(this.btnQD_Click);
            // 
            // btnQX
            // 
            this.btnQX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQX.Location = new System.Drawing.Point(195, 78);
            this.btnQX.Name = "btnQX";
            this.btnQX.Size = new System.Drawing.Size(90, 34);
            this.btnQX.TabIndex = 2;
            this.btnQX.Text = "取消";
            this.btnQX.Click += new System.EventHandler(this.btnQX_Click);
            // 
            // Msg2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 114);
            this.Controls.Add(this.btnQX);
            this.Controls.Add(this.btnQD);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Msg2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统提示";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelX1;
        private System.Windows.Forms.Button btnQD;
        private System.Windows.Forms.Button btnQX;
    }
}