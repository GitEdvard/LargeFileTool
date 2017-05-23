using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Molmed.LargeFileTool.Data.Exceptions
{
    public class OpenManifestException : ApplicationException
    {
        public OpenManifestException()
        {

        }

        public OpenManifestException(string message)
            : base(message)
        {

        }
    }
}
