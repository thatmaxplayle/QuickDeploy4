using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickDeploy4.UI.Windows
{
    public partial class WorkingDialog : Form
    {
        static WorkingDialog wd;
        public static WorkingDialog Instance => wd ??= new();

        public WorkingDialog()
        {
            InitializeComponent();
        }

        private void WorkingDialog_Load(object sender, EventArgs e)
        {

        }

        public void CrsThrdShow()
        {
            this.Invoke(() => this.Show());
        }

        public void CrsThrdHide()
        {
            this.Invoke(() => this.Hide());
        }

        public async void TaskUpdate(string taskName)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(async () =>
                {
                    this.lblTaskName.Text = taskName;
                    await Task.Delay(200);
                });
            }
            else
            {
                this.lblTaskName.Text = taskName;
                await Task.Delay(200);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
