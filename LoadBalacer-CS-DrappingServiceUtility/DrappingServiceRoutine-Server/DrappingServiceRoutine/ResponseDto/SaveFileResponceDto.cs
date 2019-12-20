using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DrappingServiceRoutine.ResponseDto
{
    [DataContract]
    public class SaveFileResponceDto
    {
        string savedimagepath = string.Empty;
        bool issaved = true;
        
        [DataMember]
        public bool IsSaved
        {
            get { return issaved; }
            set { issaved = value; }
        }

        [DataMember]
        public string SavedImagePath 
        {
            get { return savedimagepath; }
            set { savedimagepath = value; }
        }
    }
}