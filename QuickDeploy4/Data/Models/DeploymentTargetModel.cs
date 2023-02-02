using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        public bool CheckPreconditions(out string ?error)
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

            if (!source.Exists)
            {
                error = $"Source directory ({source.FullName}) does not exist.";
                return false;
            }

            if (!destination.Exists)
            {
                error = $"Destination directory ({destination.FullName}) does not exist.";
                return false;
            }

            if (dt == EDeploymentType.Folder)
            {
                if (!source.GetDirectories().Any(x => x.Name.ToLower().Trim() == this.ResourceName.ToLower().Trim()))
                {
                    error = $"Directory \"{this.ResourceName}\" does not exist in source directory.";
                    return false;
                }
            }
            else if (dt == EDeploymentType.File)
            {
                if (!source.GetFiles().Any(x => x.Name.ToLower().Trim() == this.ResourceName.ToLower().Trim()))
                {
                    error = $"File \"{this.ResourceName}\" does not exist in source directory.";
                    return false;
                }
            }
            else if (dt == EDeploymentType.EnsureFile)
            {
                if (!File.Exists(this.ResourceName))
                {
                    error = $"Ensure file \"{this.ResourceName}\" cannot be found by the file system.";
                    return false;
                }
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
