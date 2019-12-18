using System.ComponentModel;

namespace GoatAutoCAD.form {
    partial class SelectByLayer {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.clb = new System.Windows.Forms.CheckedListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // clb
            //
            this.clb.FormattingEnabled = true;
            this.clb.Location = new System.Drawing.Point(12, 11);
            this.clb.Name = "clb";
            this.clb.Size = new System.Drawing.Size(119, 148);
            this.clb.TabIndex = 0;
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(166, 25);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 31);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定\r\n";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // SelectByLayer
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 214);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.clb);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SelectByLayer";
            this.Text = "SelectByLayer";
            this.Load += new System.EventHandler(this.SelectByLayer_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb;
        private System.Windows.Forms.Button btnOk;
    }
}