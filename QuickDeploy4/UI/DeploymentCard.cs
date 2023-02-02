using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuickDeploy4.Data.Models;

namespace QuickDeploy4.UI
{
    public partial class DeploymentCard : UserControl
    {
        DeploymentModel deployment;
        List<DeploymentTargetModel> targets;

        public DeploymentCard(KeyValuePair<DeploymentModel, List<DeploymentTargetModel>> val)
        {
            this.deployment = val.Key;
            this.targets = val.Value;

            InitializeComponent();
        }

        private void DeploymentCard_Load(object sender, EventArgs e)
        {
            lblDeploymentName.Text = deployment.Name;
            lblDeploymentDescription.Text = deployment.Description;

            int fileCount = targets.Count(x => x.GetDeploymentType() == Data.Enum.EDeploymentType.File);
            int folderCount = targets.Count(x => x.GetDeploymentType() == Data.Enum.EDeploymentType.Folder);
            lblOverview.Text = $"{fileCount} file{(fileCount != 1 ? "s" : "")} • {folderCount} folder{(folderCount != 1 ? "s" : "")}";
        }
    }
}
