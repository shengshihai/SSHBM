using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace MODEL.ViewPage
{

    public class UploadRequestImg
    {
        //private HttpPostedFileBase hpf; //文件

        //private String uploadContentType;  //文件类型

        //private String uploadFileName;   //文件名

        //private HttpContextBase context;

        //private string FilePath;

        //public UploadRequestImg(HttpContextBase context)
        //{
        //    this.context = context;
        //    if (context.Request.ContentLength < 4 * 1024 * 1024)
        //    {
        //        HttpFileCollectionBase hfc = context.Request.Files;
        //        hpf = hfc[0];
        //        uploadFileName = hpf.FileName;
        //        uploadContentType = Path.GetExtension(hpf.FileName).ToLower();
        //        //FilePath = System.AppDomain.CurrentDomain.BaseDirectory.Replace("ShengUI","Image") + "UploadFile\\";
        //        FilePath = System.AppDomain.CurrentDomain.BaseDirectory + "UploadFile\\";
        //    }
        //}
        public static string CkSave(HttpContextBase context)
        {
            //if (context.Request.ContentLength < 4 * 1024 * 1024)
            //{
            //    HttpFileCollectionBase hfc = context.Request.Files;
            //     HttpPostedFileBase hpf = hfc[0];
            //    string uploadFileName = hpf.FileName;
            //    string uploadContentType = Path.GetExtension(hpf.FileName).ToLower();
            //    //FilePath = System.AppDomain.CurrentDomain.BaseDirectory.Replace("ShengUI","Image") + "UploadFile\\";
            //   string  FilePath = System.AppDomain.CurrentDomain.BaseDirectory + "UploadFile\\";
            //}
            string callback = context.Request.QueryString["CKEditorFuncNum"];
            if (context.Request.ContentLength > 4 * 1024 * 1024)
                return "<script type=\"text/javascript\">" + "window.parent.CKEDITOR.tools.callFunction(" + callback + ",'','文件太大不支持(暂不支持大于4MB文件)！')</script>";
            HttpFileCollectionBase hfc = context.Request.Files;
            HttpPostedFileBase hpf = hfc[0];
            //FilePath = System.AppDomain.CurrentDomain.BaseDirectory.Replace("ShengUI","Image") + "UploadFile\\";
            string FilePath = System.AppDomain.CurrentDomain.BaseDirectory.Replace("ShengUI", "Image") + "UploadFile\\";

            DateTime date = DateTime.Now;
            FilePath = FilePath + "Ckeditor\\" + date.Year + "\\" + date.Month + "\\" + date.Day + "\\";

            if (hpf == null)
            {
                return "<script type=\"text/javascript\">" + "window.parent.CKEDITOR.tools.callFunction(" + callback + ",'','文件不存在或者文件太大不支持(暂不支持大于4MB文件)！')</script>";
            }
            string uploadFileName = hpf.FileName;
            string uploadContentType = Path.GetExtension(hpf.FileName).ToLower();
            if (uploadContentType != ".jpg" && uploadContentType != ".gif" && uploadContentType != ".bmp" && uploadContentType != ".png" && uploadContentType != ".jpeg")
                return "<script type=\"text/javascript\">" + "window.parent.CKEDITOR.tools.callFunction(" + callback + ",'','文件格式不正确（必须为.jpg/.gif/.bmp/.png文件）')</script>";
            if (hpf.ContentLength > 1024 * 1024)
                return "<script type=\"text/javascript\">" + "window.parent.CKEDITOR.tools.callFunction(" + callback + ",'','文件大小不得大于1024k')</script>";
            try
            {
                Common.FileUpload.FileUploadSingle(context, FilePath, out uploadFileName);
            }
            catch (Exception)
            {
                return "<script type=\"text/javascript\">" + "window.parent.CKEDITOR.tools.callFunction(" + callback + ",'','图片上传失败')</script>";
            }

            return "<script type=\"text/javascript\">" + "window.parent.CKEDITOR.tools.callFunction(" + callback + ",'" + ConfigurationHelper.AppSetting("ImageHeadUrl") + "/UploadFile/Ckeditor/" + date.Year + "/" + +date.Month + "/" + +date.Day + "/" + uploadFileName + "','')</script>";

        }
        public static string ImageSave(HttpContextBase context)
        {
            HttpFileCollectionBase hfc = context.Request.Files;
            HttpPostedFileBase hpf = hfc[0];
            string FilePath = System.AppDomain.CurrentDomain.BaseDirectory.Replace("exportimes", "Image") + "UploadFile\\";
            DateTime date = DateTime.Now;
            FilePath = FilePath + "UploadImg\\" + date.Year + "\\" + date.Month + "\\" + date.Day + "\\";
            if (hpf == null)
            {
                return "no";
            }
            string uploadFileName = hpf.FileName;
            string uploadContentType = Path.GetExtension(hpf.FileName).ToLower();
            if (uploadContentType != ".jpg" && uploadContentType != ".gif" && uploadContentType != ".bmp" && uploadContentType != ".png" && uploadContentType != ".jpeg")
                return "no";
            try
            {
                Common.FileUpload.FileUploadSingle(context, FilePath, out uploadFileName);

                ImageThumbnailMake.CompressImage(FilePath + uploadFileName, FilePath + uploadFileName + "680x680.jpg", 680, 680, 98);
                ImageThumbnailMake.CompressImage(FilePath + uploadFileName, FilePath + uploadFileName + "360x360.jpg", 360, 360, 99);
                ImageThumbnailMake.CompressImage(FilePath + uploadFileName, FilePath + uploadFileName + "150x150.jpg", 150, 150, 100);
               //ImageThumbnailMake.MakeCompressionThumbnail(680, 680, FilePath, FilePath, "2" + uploadFileName);

               //ImageThumbnailMake.MakeCompressionThumbnail(360, 360, FilePath, FilePath, "2" + uploadFileName);
               //ImageThumbnailMake.MakeCompressionThumbnail(150, 150, FilePath, FilePath, "2" + uploadFileName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return ConfigurationHelper.AppSetting("ImageHeadUrl") + "/UploadFile/UploadImg/" + date.Year + "/" + +date.Month + "/" + +date.Day + "/" + uploadFileName;
        }
        public static string OneImageSave(HttpContextBase context)
        {
           return OneImageSave(context, null, null);
        }
        public static string OneImageSave(HttpContextBase context,string mainPath)
        {
            return OneImageSave(context, mainPath, null);
        }
        public static string OneImageSave(HttpContextBase context,string mainPath,string partPath)
        {
          
            HttpFileCollectionBase hfc;
            try
            {
                hfc = context.Request.Files;
            }
            catch (Exception)
            {

                return "no";
            }
            HttpPostedFileBase hpf = hfc[0];
            string FilePath = System.AppDomain.CurrentDomain.BaseDirectory.Replace("exportimes", "Image") + "UploadFile\\";
            DateTime date = DateTime.Now;
            FilePath = FilePath + (mainPath != null ? mainPath + "\\" : "") + (partPath != null ? partPath + "\\" : "") + +date.Year + "\\" + date.Month + "\\" + date.Day + "\\";
            if (hpf == null)
            {
                return "no";
            }
            string uploadFileName = hpf.FileName;
            string uploadContentType = Path.GetExtension(hpf.FileName).ToLower();
            if (uploadContentType != ".jpg" && uploadContentType != ".gif" && uploadContentType != ".bmp" && uploadContentType != ".png" && uploadContentType != ".jpeg")
                return "no";
            try
            {
                Common.FileUpload.FileUploadSingle(context, FilePath, out uploadFileName);
                ImageThumbnailMake.ystp(FilePath + uploadFileName, FilePath + "new@" + uploadFileName);
                Common.FileOperate.DelFile(FilePath + uploadFileName);
                //ImageThumbnailMake.MakeThumbnail(FilePath + uploadFileName, FilePath + uploadFileName+"_680x680.jpg",680,680);
                //ImageThumbnailMake.MakeThumbnail(FilePath + uploadFileName, FilePath + uploadFileName + "_350x350.jpg", 359, 359);
                //ImageThumbnailMake.MakeThumbnail(FilePath + uploadFileName, FilePath + uploadFileName + "_150x150.jpg", 150, 150);
                //ImageThumbnailMake.MakeThumbnail(680, 680, FilePath, FilePath, uploadFileName);
                //ImageThumbnailMake.MakeThumbnail(359, 359, FilePath, FilePath, uploadFileName);
                //ImageThumbnailMake.MakeThumbnail(150, 150, FilePath, FilePath, uploadFileName);
            }
            catch (Exception ex)
            {
                return "no";
            }
            return ConfigurationHelper.AppSetting("ImageHeadUrl") + "/UploadFile/" + (mainPath != null ? mainPath + "/" : "") + (partPath != null ? partPath + "/" : "") + date.Year + "/" + +date.Month + "/" + +date.Day + "/" + "new@" + uploadFileName;
        }
    }
}
