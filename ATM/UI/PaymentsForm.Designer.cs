namespace ATM.UI
{
    partial class PaymentsForm
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
            this.cmbServiceType = new System.Windows.Forms.ComboBox();
            this.txtAccountDetails = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblService = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.cmbServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceType.FormattingEnabled = true;
            this.cmbServiceType.Items.AddRange(new object[] {
            "Мобільний зв\'язок",
            "Комунальні послуги",
            "Інтернет (Провайдер)"});
            this.cmbServiceType.Location = new System.Drawing.Point(380, 100);
            this.cmbServiceType.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.cmbServiceType.Name = "cmbServiceType";
            this.cmbServiceType.Size = new System.Drawing.Size(321, 39);
            this.cmbServiceType.TabIndex = 0;

            this.txtAccountDetails.Location = new System.Drawing.Point(380, 160);
            this.txtAccountDetails.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtAccountDetails.Name = "txtAccountDetails";
            this.txtAccountDetails.Size = new System.Drawing.Size(321, 38);
            this.txtAccountDetails.TabIndex = 1;

            this.txtAmount.Location = new System.Drawing.Point(380, 220);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(321, 38);
            this.txtAmount.TabIndex = 2;

            this.btnPay.Location = new System.Drawing.Point(180, 310);
            this.btnPay.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(216, 72);
            this.btnPay.TabIndex = 3;
            this.btnPay.Text = "Оплатити";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);

            this.btnCancel.Location = new System.Drawing.Point(425, 310);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(216, 72);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(86, 103);
            this.lblService.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(155, 31);
            this.lblService.TabIndex = 5;
            this.lblService.Text = "Тип послуги:";

            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(86, 163);
            this.lblDetails.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(282, 31);
            this.lblDetails.TabIndex = 6;
            this.lblDetails.Text = "Реквізити / Номер тел.:";

            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(86, 223);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(75, 31);
            this.lblAmount.TabIndex = 7;
            this.lblAmount.Text = "Сума:";

            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(86, 40);
            this.lblBalance.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(232, 31);
            this.lblBalance.TabIndex = 8;
            this.lblBalance.Text = "Поточний баланс: 0";

            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(866, 430);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtAccountDetails);
            this.Controls.Add(this.cmbServiceType);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.MaximizeBox = false;
            this.Name = "PaymentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Платежі";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox cmbServiceType;
        private System.Windows.Forms.TextBox txtAccountDetails;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblBalance;
    }
}