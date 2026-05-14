using ATM.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM.UI
{
    public partial class HistoryForm : Form
    {
        private string currentCardNumber;

        public HistoryForm(string cardNumber)
        {
            InitializeComponent();
            currentCardNumber = cardNumber;
            LoadHistory();
        }

        private void LoadHistory()
        {
            string[] logs = FileStorage.GetInstance().GetLogs();
            lstHistory.Items.Clear();

            foreach (string line in logs)
            {
                if (line.Contains(currentCardNumber))
                {
                    lstHistory.Items.Add(line);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
