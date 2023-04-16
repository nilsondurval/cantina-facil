using System;
using System.Collections.Generic;
using System.Text;

namespace CantinaFacil.Shared.Kernel.Attributes
{
    public class GuidAttribute : Attribute
    {
        public string Guid { get; set; }

        public GuidAttribute(string guid)
        {
            Guid = guid;
        }
    }
}
