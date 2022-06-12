using RightControl.Common;
using RightControl.IService;
using RightControl.Model;
using RightControl.WebApp.Areas.Admin.Controllers;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace RightControl.WebApp.Areas.SysSet.Controllers
{
    public class InfoController : BaseController
    {
        public IUserService userService { get; set; }
        // GET: SysSet/Info
        public override ActionResult Index(int? id)
        {
            base.Index(id);
            ViewBag.MaxFileUpload = Configs.GetValue("MaxFileUpload");
            ViewBag.UploadFileType = Configs.GetValue("UploadFileType");
            var _userId = Operator.UserId;
            var model = userService.GetDetail(_userId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            model.UpdateOn = DateTime.Now;
            model.UpdateBy = Operator.UserId;
            model.Id = Operator.UserId;
            var result = userService.UpdateModel(model, "UpdateOn,UpdateBy,RealName,Gender,HeadShot,Phone,Email,Remark") ? SuccessText : ErrorText;
            ViewBag.Msg = result;
            return View("Index", model);
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public JsonResult ExportFile()
        {
            uploadFile _uploadFile = new uploadFile();
            try
            {
                var file = Request.Files[0]; //获取选中文件
                var filecombin = file.FileName.Split('.');
                if (file == null || string.IsNullOrEmpty(file.FileName) || file.ContentLength == 0 || filecombin.Length < 2)
                {
                    _uploadFile.code = -1;
                    _uploadFile.src = "";
                    _uploadFile.msg = "上传出错!请检查文件名或文件内容";
                    return Json(_uploadFile);
                }

                if (!IsAllowedExtension(file))
                {
                    _uploadFile.code = -1;
                    _uploadFile.data = new { src = "" };
                    _uploadFile.msg = "检测到上传文件有问题!";
                    return Json(_uploadFile);
                }

                //定义本地路径位置
                string localPath = Server.MapPath("~/Upload/img/");
                string filePathName = string.Empty;

                string tmpName = Server.MapPath("~/Upload/img/");
                var tmp = file.FileName;
                var tmpIndex = 0;
                //判断是否存在相同文件名的文件 相同累加1继续判断  
                while (System.IO.File.Exists(tmpName + tmp))
                {
                    tmp = filecombin[0] + "_" + ++tmpIndex + "." + filecombin[1];
                }
                //不带路径的最终文件名  
                filePathName = tmp;

                if (!System.IO.Directory.Exists(localPath))
                    System.IO.Directory.CreateDirectory(localPath);

                file.SaveAs(Path.Combine(tmpName, filePathName));   //保存图片（文件夹）  

                _uploadFile.code = 0;
                _uploadFile.src = Path.Combine("/Upload/img/", filePathName); //name = Path.GetFileNameWithoutExtension(file.FileName),   // 获取文件名不含后缀名  
                _uploadFile.msg = "上传成功";
                return Json(_uploadFile);
            }
            catch (Exception)
            {
                return Json(_uploadFile, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 判断文件是否正常，防止伪造文件上传
        /// </summary>
        /// <param name="hifile"></param>
        /// <returns></returns>
        private static bool IsAllowedExtension(HttpPostedFileBase postedFile)
        {
            int fileLen = postedFile.ContentLength;
            byte[] imgArray = new byte[fileLen];
            postedFile.InputStream.Read(imgArray, 0, fileLen);
            System.IO.MemoryStream fs = new System.IO.MemoryStream(imgArray);
            System.IO.BinaryReader r = new System.IO.BinaryReader(fs);

            string fileclass = "";
            byte buffer;
            try
            {
                buffer = r.ReadByte();
                fileclass = buffer.ToString();
                buffer = r.ReadByte();
                fileclass += buffer.ToString();
            }
            catch
            {
                return false;
            }
            r.Close();
            fs.Close();

            /*文件扩展名说明 
            jpg：255216 
            bmp：6677 
            png：13780
            gif：7173 
            xls,doc,ppt：208207 
            rar：8297 
            zip：8075 
            txt：98109 
            pdf：3780 
            */
            bool ret = false;
            String[] fileType = {
            "255216",
            "6677",
            "13780",
            "7173",
            "208207",
            "8297",
            "8075",
            "98109",
            "3780"
            };
            for (int i = 0; i < fileType.Length; i++)
            {
                if (fileclass == fileType[i])
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
    }
}