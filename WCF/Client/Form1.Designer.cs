﻿namespace Client
{
    partial class Form1
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
            this.dgp = new System.Windows.Forms.DataGridView();
            this.dgc = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgp
            // 
            this.dgp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgp.Location = new System.Drawing.Point(12, 38);
            this.dgp.Name = "dgp";
            this.dgp.RowTemplate.Height = 24;
            this.dgp.Size = new System.Drawing.Size(380, 400);
            this.dgp.TabIndex = 0;
            this.dgp.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgp_CellMouseClick);
            // 
            // dgc
            // 
            this.dgc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgc.Location = new System.Drawing.Point(398, 38);
            this.dgc.Name = "dgc";
            this.dgc.RowTemplate.Height = 24;
            this.dgc.Size = new System.Drawing.Size(390, 400);
            this.dgc.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgc);
            this.Controls.Add(this.dgp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgp;
        private System.Windows.Forms.DataGridView dgc;
    }
}

