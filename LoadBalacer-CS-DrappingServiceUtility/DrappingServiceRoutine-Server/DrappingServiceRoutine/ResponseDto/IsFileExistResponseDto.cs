using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DrappingServiceRoutine.ResponseDto
{
    [DataContract]
    public class IsFileExistResponseDto
    {
        [DataMember]
        public List<string> ImageNameToBeDrapped { get; set; }
    }
}