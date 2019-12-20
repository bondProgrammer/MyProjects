using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DrappingServiceRoutine.RequestDto
{
    [DataContract]
    public class SaveFileRequestDto
    {

        byte[] drappedimagebyte;
        string sourcepath = string.Empty;

        [DataMember]
        public string SourcePath
        {
            get { return sourcepath; }
            set { sourcepath = value; }
        }

        [DataMember]
        public byte[] DrappedImageByte
        {
            get { return drappedimagebyte; }
            set { drappedimagebyte = value; }

        }

        
    }
}