namespace ATM.UI
{
    partial class CashForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.txtAmount.Location = new System.Drawing.Point(260, 120);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(321, 38);
            this.txtAmount.TabIndex = 0;

            this.btnWithdraw.Location = new System.Drawing.Point(86, 238);
            this.btnWithdraw.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(216, 72);
            this.btnWithdraw.TabIndex = 1;
            this.btnWithdraw.Text = "Зняти";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);

            this.btnDeposit.Location = new System.Drawing.Point(325, 238);
            this.btnDeposit.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(216, 72);
            this.btnDeposit.TabIndex = 2;
            this.btnDeposit.Text = "Поповнити";
            this.btnDeposit.UseVisualStyleBackColor = true;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);

            this.btnCancel.Location = new System.Drawing.Point(564, 238);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(216, 72);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(86, 126);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(75, 31);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "Сума:";

            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(86, 60);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(232, 31);
            this.lblBalance.TabIndex = 5;
            this.lblBalance.Text = "Поточний баланс: 0";

            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(866, 430);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.btnWithdraw);
            this.Controls.Add(this.txtAmount);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.MaximizeBox = false;
            this.Name = "CashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Операції з готівкою";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblBalance;
    }
}