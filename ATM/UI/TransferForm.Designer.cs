namespace ATM.UI
{
    partial class TransferForm
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
            this.txtTargetCard = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTargetCard = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.txtTargetCard.Location = new System.Drawing.Point(320, 100);
            this.txtTargetCard.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtTargetCard.Name = "txtTargetCard";
            this.txtTargetCard.Size = new System.Drawing.Size(321, 38);
            this.txtTargetCard.TabIndex = 0;

            this.txtAmount.Location = new System.Drawing.Point(320, 160);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(321, 38);
            this.txtAmount.TabIndex = 1;

            this.btnTransfer.Location = new System.Drawing.Point(180, 240);
            this.btnTransfer.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(216, 72);
            this.btnTransfer.TabIndex = 2;
            this.btnTransfer.Text = "Переказати";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);

            this.btnCancel.Location = new System.Drawing.Point(425, 240);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(216, 72);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.lblTargetCard.AutoSize = true;
            this.lblTargetCard.Location = new System.Drawing.Point(86, 103);
            this.lblTargetCard.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTargetCard.Name = "lblTargetCard";
            this.lblTargetCard.Size = new System.Drawing.Size(222, 31);
            this.lblTargetCard.TabIndex = 4;
            this.lblTargetCard.Text = "Картка отримувача:";

            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(86, 163);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(75, 31);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "Сума:";

            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(86, 40);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(232, 31);
            this.lblBalance.TabIndex = 6;
            this.lblBalance.Text = "Поточний баланс: 0";

            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(866, 430);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTargetCard);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtTargetCard);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.MaximizeBox = false;
            this.Name = "TransferForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Переказ коштів";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtTargetCard;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTargetCard;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblBalance;
    }
}