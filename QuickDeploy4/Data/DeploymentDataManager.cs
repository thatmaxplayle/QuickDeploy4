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
            WorkingDialog.Instance.CrsThrdShow(); // show the "QD4 is busy" dialog 
            WorkingDialog.Instance.TaskUpdate("Loading deployments..."); // set the task (informing the user what's going on)

            var depls = new List<DeploymentModel>(); // create a list to initially fetched deployments, before we get the targets

            using (var db = Database.Instance.GetConnection()) // init new db connection
            {
                depls = db.Query<DeploymentModel>("select * from Deployments", new DynamicParameters()).ToList(); // query *only deployments* from the database
                WorkingDialog.Instance.TaskUpdate($"Loaded {deployments.Count} deployments."); // tell the user how many we found
            }

            WorkingDialog.Instance.TaskUpdate("Pairing deployment instances with their resources..."); // pair deployment to targets, which are stored in a different table

            foreach (var depl in depls) // iterate through fetched deployments, grabbing targets for each 
            {
                WorkingDialog.Instance.TaskUpdate($"Scanning deployment resources for deployment: " + depl.Name); // tell the user what we're doing

                using (var db = Database.Instance.GetConnection()) 
                {
                    var res = db.Query<DeploymentTargetModel>("select * from DeploymentTargets where DeploymentId = @Id", depl).ToList(); // get all targets associated with given deployment id
                    {
                        if (deployments.ContainsKey(depl)) // this shouldn't ever be the case but nice to confirm. 
                        {
                            deployments[depl] ??= new();
                            deployments[depl].AddRange(res); // add all targets to data manager
                        }
                        else
                        {
                            deployments.Add(depl, new List<DeploymentTargetModel>()); // create a new entry for the deployment, and list of targets
                            deployments[depl] ??= new();
                            deployments[depl].AddRange(res);
                        }

                        this.OnDeploymentAdded?.Invoke(depl); // invoke the event, which is subscribed to on the UI to update the deployments list

                        await Task.Delay(200);// wait time to wait for the DB to unlock.
                        WorkingDialog.Instance.TaskUpdate($"Found {res.Count} targets for deployment \"{depl.Name}\"");
                    }
                }

            }
        }

        public delegate void DeploymentAdded(DeploymentModel deployment);
        public event DeploymentAdded OnDeploymentAdded;
    }
}
