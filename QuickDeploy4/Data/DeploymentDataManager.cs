using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using QuickDeploy4.Data.Models;
using QuickDeploy4.UI.Windows;

namespace QuickDeploy4.Data
{
    public class DeploymentDataManager
    {

        static DeploymentDataManager i;
        public static DeploymentDataManager Instance => i ??= new();

        public static Dictionary<DeploymentModel, List<DeploymentTargetModel>> deployments = new();

        public async void LoadDeployments()
        {
            WorkingDialog.Instance.CrsThrdShow();
            WorkingDialog.Instance.TaskUpdate("Loading deployments...");
            var depls = new List<DeploymentModel>();
            using (var db = Database.Instance.GetConnection())
            {
                depls = db.Query<DeploymentModel>("select * from Deployments", new DynamicParameters()).ToList();
                WorkingDialog.Instance.TaskUpdate($"Loaded {deployments.Count} deployments.");
            }

            WorkingDialog.Instance.TaskUpdate("Pairing deployment instances with their resources...");
            foreach (var depl in depls)
            {
                await Task.Delay(200);
                WorkingDialog.Instance.TaskUpdate($"Scanning deployment resources for deployment: " + depl.Name);

                using (var db = Database.Instance.GetConnection())
                {
                    var res = db.Query<DeploymentTargetModel>("select * from DeploymentTargets where DeploymentId = @Id", depl).ToList();
                    {
                        if (deployments.ContainsKey(depl))
                        {
                            deployments[depl] ??= new();
                            deployments[depl].AddRange(res);
                        }
                        else
                        {
                            deployments.Add(depl, new List<DeploymentTargetModel>());
                            deployments[depl] ??= new();
                            deployments[depl].AddRange(res);
                        }

                        this.OnDeploymentAdded?.Invoke(depl);

                        await Task.Delay(200);
                        WorkingDialog.Instance.TaskUpdate($"Found {res.Count} targets for deployment \"{depl.Name}\"");
                    }
                }

            }
        }

        public delegate void DeploymentAdded(DeploymentModel deployment);
        public event DeploymentAdded OnDeploymentAdded;
    }
}
