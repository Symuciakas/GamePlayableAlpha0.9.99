namespace Game
{
    partial class TalkingToVendor
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
            this.dgvYourItems = new System.Windows.Forms.DataGridView();
            this.dgvVendorsItems = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYourItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorsItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvYourItems
            // 
            this.dgvYourItems.AllowUserToAddRows = false;
            this.dgvYourItems.AllowUserToDeleteRows = false;
            this.dgvYourItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvYourItems.Location = new System.Drawing.Point(12, 25);
            this.dgvYourItems.Name = "dgvYourItems";
            this.dgvYourItems.ReadOnly = true;
            this.dgvYourItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvYourItems.Size = new System.Drawing.Size(558, 125);
            this.dgvYourItems.TabIndex = 0;
            // 
            // dgvVendorsItems
            // 
            this.dgvVendorsItems.AllowUserToAddRows = false;
            this.dgvVendorsItems.AllowUserToDeleteRows = false;
            this.dgvVendorsItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVendorsItems.Location = new System.Drawing.Point(12, 174);
            this.dgvVendorsItems.Name = "dgvVendorsItems";
            this.dgvVendorsItems.ReadOnly = true;
            this.dgvVendorsItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvVendorsItems.Size = new System.Drawing.Size(558, 125);
            this.dgvVendorsItems.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Your Items";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "VendorsItems";
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(12, 305);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(276, 43);
            this.btnSell.TabIndex = 4;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(294, 305);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(276, 43);
            this.btnBuy.TabIndex = 5;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // TalkingToVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 353);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvVendorsItems);
            this.Controls.Add(this.dgvYourItems);
            this.MaximumSize = new System.Drawing.Size(600, 392);
            this.MinimumSize = new System.Drawing.Size(600, 392);
            this.Name = "TalkingToVendor";
            this.Text = "TalkingToVendor";
            this.Load += new System.EventHandler(this.TalkingToVendor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYourItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorsItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvYourItems;
        private System.Windows.Forms.DataGridView dgvVendorsItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnBuy;
    }
}