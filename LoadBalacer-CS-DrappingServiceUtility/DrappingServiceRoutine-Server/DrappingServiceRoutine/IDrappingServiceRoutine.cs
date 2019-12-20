using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DrappingServiceRoutine.RequestDto;
using DrappingServiceRoutine.ResponseDto;

namespace DrappingServiceRoutine
{    
    [ServiceContract]
    public interface IDrappingServiceRoutine
    {
        [OperationContract]
        IsFileExistResponseDto IsFileExist(IsFileExistRequestDto isfileexistdto);

        [OperationContract]
        DrapImageResponseDto DrapImage(DrapImageRequestDto drapimageresponsedto);

        [OperationContract]
        SaveFileResponceDto SaveImage(SaveFileRequestDto savefilerequestdto);
        
    }
   
}
