using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DrappingServiceRoutine.RequestDto
{
    [DataContract]
    public class IsFileExistRequestDto
    {
        [DataMember]
        public List<string> ImageName { get; set; }

        [DataMember]
        public string DestinationPath { get; set; }
    }
}