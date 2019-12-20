using DrappingServiceRoutine.RequestDto;
using DrappingServiceRoutine.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace DrappingServiceRoutine
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DrappingServiceRoutine : IDrappingServiceRoutine
    {
        public IsFileExistResponseDto IsFileExist(IsFileExistRequestDto isfileexistdto)
        {
            List<string> imagelist = new List<string>();
            var imagelist2 = isfileexistdto.ImageName;
            #region comment Serial Working
            //foreach (var img in isfileexistdto.ImageName)
            //{
            //    string path = isfileexistdto.DestinationPath;
            //    path = path +"\\" + img;
            //    if (!System.IO.File.Exists(path))
            //    {
            //        imagelist.Add(img);
            //    }
            //}
            #endregion

            #region parallel Working
            Parallel.ForEach(imagelist2.Cast<string>(), currentElement =>
            {
                string path = isfileexistdto.DestinationPath;
                path = path +"\\" +currentElement;
                if (!System.IO.File.Exists(path))
                {
                    lock (this)
                    {
                        imagelist.Add(currentElement.ToString());
                    }
                }
            });
            #endregion
            return new IsFileExistResponseDto()
            {
                ImageNameToBeDrapped = imagelist,
            };
        }

        public DrapImageResponseDto DrapImage(DrapImageRequestDto drapimagerequestdto)
        {
            SaveFileResponceDto result;
            do
            {                
                SaveFileRequestDto savefile = new SaveFileRequestDto();
                savefile.SourcePath = drapimagerequestdto.SourcePath;
                savefile.DrappedImageByte = drapimagerequestdto.DrappedImageByte ;
                result = SaveImage(savefile);
            } while (!result.IsSaved);

            return new DrapImageResponseDto()
            {
                SavedImagePath = result.SavedImagePath,
                IsSuccess = result.IsSaved
            };

        }

        public SaveFileResponceDto SaveImage(SaveFileRequestDto savefilerequestdto)
        {
            string filepath = string.Empty;
            int count = 0; 
            do
            {
            string filename = savefilerequestdto.SourcePath;
            string path = @"\\172.16.10.203\d\DrappedImage";
            filepath = path + filename;
            System.IO.File.WriteAllBytes(filepath,savefilerequestdto.DrappedImageByte);
            count++;
            if (count > 3)
            {
                return new SaveFileResponceDto()
                {
                    IsSaved = false,
                    SavedImagePath = null,
                };
            }
            }while(!System.IO.File.Exists(filepath));
            return new SaveFileResponceDto()
            {
                IsSaved = true ,
                SavedImagePath = filepath,
            };
        }

    }
}
