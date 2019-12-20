using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DrappingServiceRoutine.ResponseDto
{
    [DataContract]
    public class DrapImageResponseDto
    {
        bool issuccess = true;
        string savedimagepath = string.Empty;

        [DataMember]
        public bool IsSuccess
        {
            get { return issuccess; }
            set { issuccess = value; }
        }

        [DataMember]
        public string SavedImagePath
        {
            get { return savedimagepath; }
            set { savedimagepath = value; }
        }
    }
}