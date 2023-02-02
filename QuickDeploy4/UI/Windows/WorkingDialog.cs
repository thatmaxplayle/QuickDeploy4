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

        /// <summary>
        /// Call this method to show the dialog, if you're running in a different thread. 
        /// </summary>
        /// <remarks>
        /// This method merely calls <see cref="Show"/> but, invokes it first. 
        /// </remarks>
        public void CrsThrdShow()
        {
            this.Invoke(() => this.Show());
        }

        /// <summary>
        /// Call this method to hide the dialog, if you're running in a different thread.
        /// </summary>
        /// <remarks>
        /// This method merely calls <see cref="Hide"/> but, invokes it first.
        /// </remarks>
        public void CrsThrdHide()
        {
            this.Invoke(() => this.Hide());
        }
        

        /// <summary>
        /// Update the displayed task information on the window. This method is cross-thread-compatible.
        /// </summary>
        public void TaskUpdate(string taskName)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(() =>
                {
                    this.lblTaskName.Text = taskName;
                });
            }
            else
            {
                this.lblTaskName.Text = taskName;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            //ignore this
        }
    }
}
