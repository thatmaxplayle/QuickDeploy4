using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickDeploy4.Data.Enum
{
    public enum EDeploymentType
    {
        /// <summary>
        /// A file within the source directory, which will be copied over to the destination directory.
        /// </summary>
        File,

        /// <summary>
        /// A folder within the source directory, which will be copied (whether this is copied recursively depends on the deployment) over to the destination directory.
        /// </summary>
        Folder,

        /// <summary>
        /// An absolute file path which must exist before the deployment can be executed.
        /// </summary>
        EnsureFile
    }
}
