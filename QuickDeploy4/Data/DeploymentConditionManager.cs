using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickDeploy4.Data.Models;

namespace QuickDeploy4.Data
{
    public class DeploymentConditionManager
    {

        private static DeploymentConditionManager i;
        public static DeploymentConditionManager Instance => i ??= new();

        List<DeploymentTargetModel> models = new List<DeploymentTargetModel>();

        

    }
}
