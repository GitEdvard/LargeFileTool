using System;

namespace LargeFileTool.Data.Exceptions
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
