namespace ATM.UI
{
    partial class MainForm
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
            this.btnCash = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Location = new System.Drawing.Point(50, 30);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(100, 31);
            this.lblCardNumber.TabIndex = 0;
            this.lblCardNumber.Text = "Картка: ";

            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(50, 80);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(100, 31);
            this.lblBalance.TabIndex = 1;
            this.lblBalance.Text = "Баланс: ";

            this.btnCash.Location = new System.Drawing.Point(50, 150);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(200, 60);
            this.btnCash.TabIndex = 2;
            this.btnCash.Text = "Готівка";
            this.btnCash.UseVisualStyleBackColor = true;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);

            this.btnTransfer.Location = new System.Drawing.Point(300, 150);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(200, 60);
            this.btnTransfer.TabIndex = 3;
            this.btnTransfer.Text = "Переказ";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);

            this.btnPayments.Location = new System.Drawing.Point(50, 240);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(200, 60);
            this.btnPayments.TabIndex = 4;
            this.btnPayments.Text = "Платежі";
            this.btnPayments.UseVisualStyleBackColor = true;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);

            this.btnHistory.Location = new System.Drawing.Point(300, 240);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(200, 60);
            this.btnHistory.TabIndex = 5;
            this.btnHistory.Text = "Історія";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);

            this.btnExit.Location = new System.Drawing.Point(175, 330);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 60);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Вихід";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(560, 430);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnPayments);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnCash);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblCardNumber);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Головне меню";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblCardNumber;
    }
}