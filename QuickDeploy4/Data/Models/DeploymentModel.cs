using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickDeploy4.Data.Models
{
    public class DeploymentModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BuildCounter { get; set; }
        public int RecursiveDirectoryCopying { get; set; }

        public string SourceDirectory { get; set; }
        public string DestinationDirectory { get; set; }
    }
}
