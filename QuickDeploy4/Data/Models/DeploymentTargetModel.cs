using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using QuickDeploy4.Data.Enum;

namespace QuickDeploy4.Data.Models
{
    public class DeploymentTargetModel
    {

        public int Id { get; set; }
        public int DeploymentId { get; set; }

        public int Type { get; set; }
        public string ResourceName { get; set; }

        public bool CheckPreconditions(out string error)
        {
            var dt = GetDeploymentType();
            var parent = GetParent();

            if (parent == null)
            {
                error = "Parent deployment not found.";
                return false;
            }

            DirectoryInfo source = new DirectoryInfo(parent.SourceDirectory);
            DirectoryInfo destination = new DirectoryInfo(parent.DestinationDirectory);

            if (dt == EDeploymentType.Folder)
            {
                
            }

            error = null;
            return true;
        }
        public DeploymentModel? GetParent()
        {
            using (var db = Database.Instance.GetConnection())
            {
                return db.Query<DeploymentModel>("select * from Deployments where Id = " + this.DeploymentId, new DynamicParameters()).FirstOrDefault(); 
            }
        }
        public EDeploymentType GetDeploymentType() => (EDeploymentType)this.Type;
    }
}
