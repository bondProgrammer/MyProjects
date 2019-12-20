using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrappingTestLoadBalancer.DrappingServiceRoutine;
using System.IO;
using System.Threading;
namespace DrappingTestLoadBalancer
{
    class Program
    {
        public Dictionary<string, bool> drappingimagestatus = new Dictionary<string, bool>();
        static void Main(string[] args)
        {   
            // initialization of objects 
            List<string> pendingdrapimage;
            do
            {
            Program p = new Program();
            //check for file existance   
             pendingdrapimage = new List<string>();
            foreach (string s in Directory.GetFiles(@"D:\images", "*.png").Select(Path.GetFileName))
                pendingdrapimage.Add(s);
            IsFileExistRequestDto isfileexistrequestdto = new IsFileExistRequestDto();
            isfileexistrequestdto.ImageName = pendingdrapimage.ToArray();
            DrappingServiceRoutine.DrappingServiceRoutineClient proxy = new DrappingServiceRoutine.DrappingServiceRoutineClient();
            isfileexistrequestdto.DestinationPath = @"D:\DrappedImage";
            IsFileExistResponseDto isfileexistresponcedto = proxy.IsFileExist(isfileexistrequestdto);
            foreach (var img in isfileexistresponcedto.ImageNameToBeDrapped)
            {
                p.drappingimagestatus.Add(img, false);
            }
            Console.WriteLine("child thread starting =>");
            Thread thread = new Thread(() => p.LoadAssignment(p.drappingimagestatus));
            thread.Start();
             //check whether each image is successfully written into destination
            foreach (string s in Directory.GetFiles(@"D:\images", "*.png").Select(Path.GetFileName))
                pendingdrapimage.Add(s);              
            } while (pendingdrapimage != null);
            Console.WriteLine("Main Thread Terminating <=");
            Console.ReadKey();
           
        }
        public void LoadAssignment(object drappingimagestatus)
        {
            DrappingServiceRoutine.DrappingServiceRoutineClient proxy = new DrappingServiceRoutine.DrappingServiceRoutineClient();
            Dictionary<string, bool> drappingimagestatusNew = (Dictionary<string, bool>)drappingimagestatus;
            
        }
    }
}
