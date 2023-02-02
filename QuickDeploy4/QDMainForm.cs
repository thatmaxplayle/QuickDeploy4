using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuickDeploy4.Data;
using QuickDeploy4.UI;

namespace QuickDeploy4
{
    public partial class QDMainForm : Form
    {
        public static QDMainForm Instance;

        public QDMainForm()
        {
            InitializeComponent();

            Instance = this;
            

        }

        private void QDMainForm_Load(object sender, EventArgs e)
        {
            DeploymentDataManager.Instance.OnDeploymentAdded += this.Instance_OnDeploymentAdded;
            RefreshDeployments();
        }

        private void Instance_OnDeploymentAdded(Data.Models.DeploymentModel deployment)
        {
            this.Invoke(RefreshDeployments);
        }

        void RefreshDeployments()
        {
            if (!DeploymentDataManager.deployments.Any())
            {
                flpDeployments.Controls.Clear();
                flpDeployments.Controls.Add(new Label
                {
                    Text = "There are no currently available deployments.",
                    Size = new Size(500, 100)
                });
            }
            else
            {
                flpDeployments.Controls.Clear();
                flpDeployments.Controls.Add(new Label
                {
                    Text = $"There are currently {DeploymentDataManager.deployments.Count()} available deployments.",
                    Size = new Size(500, 40)
                });

                foreach (var deployment in DeploymentDataManager.deployments)
                {
                    flpDeployments.Controls.Add(new DeploymentCard(deployment));
                }

            }
        }
    }
}
