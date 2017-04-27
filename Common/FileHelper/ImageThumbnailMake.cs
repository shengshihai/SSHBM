using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Common
{
    /// <summary>
    ///pic_zip 图片缩略图生成类
    /// </summary>
    public class ImageThumbnailMake
    {
        /// <summary>
        /// 图片缩略图生成 
        /// </summary>
        public ImageThumbnailMake()
        {


        }
        /// <summary>
        /// 图片缩略图生成算法
        /// </summary>
        /// <param name="int_Width">宽度</param>
        /// <param name="int_Height">高度</param>
        /// <param name="input_ImgFile">文件路径</param>
        /// <param name="out_ImgFile">保存文件路径</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static bool MakeThumbnail(int int_Width, int int_Height, string input_ImgFile, string out_ImgFile, string filename)
        {
            System.Drawing.Image oldimage = System.Drawing.Image.FromFile(input_ImgFile + filename);
            float New_Width; // 新的宽度    
            float New_Height; // 新的高度    
            float Old_Width, Old_Height; //原始高宽    
            int flat = 0;//标记图片是不是等比    


            int xPoint = 0;//若果要补白边的话，原图像所在的x，y坐标。    
            int yPoint = 0;
            //判断图片    

            Old_Width = (float)oldimage.Width;
            Old_Height = (float)oldimage.Height;

            if ((Old_Width / Old_Height) > ((float)int_Width / (float)int_Height)) //当图片太宽的时候    
            {
                New_Height = Old_Height * ((float)int_Width / (float)Old_Width);
                New_Width = (float)int_Width;
                //此时x坐标不用修改    
                yPoint = (int)(((float)int_Height - New_Height) / 2);
                flat = 1;
            }
            else if ((oldimage.Width / oldimage.Height) == ((float)int_Width / (float)int_Height))
            {
                New_Width = int_Width;
                New_Height = int_Height;
            }
            else
            {
                New_Width = (int)oldimage.Width * ((float)int_Height / (float)oldimage.Height);  //太高的时候   
                New_Height = int_Height;
                //此时y坐标不用修改    
                xPoint = (int)(((float)int_Width - New_Width) / 2);
                flat = 1;
            }

            System.Drawing.Image.GetThumbnailImageAbort callb = null;
            // ＝＝＝缩小图片＝＝＝    
            //调用缩放算法
            System.Drawing.Image thumbnailImage = Makesmallimage(oldimage, (int)New_Width, (int)New_Height);
            Bitmap bm = new Bitmap(thumbnailImage);

            if (flat != 0)
            {
                Bitmap bmOutput = new Bitmap(int_Width, int_Height);
                Graphics gc = Graphics.FromImage(bmOutput);
                //SolidBrush tbBg = new SolidBrush(Color.White);
                //gc.FillRectangle(tbBg, 0, 0, int_Width, int_Height); //填充为白色    


                gc.DrawImage(bm, xPoint, yPoint, (int)New_Width, (int)New_Height);
                bmOutput.Save(out_ImgFile + filename + "_" + int_Width + "x" + int_Height + ".jpg");
            }
            else
            {
                bm.Save(out_ImgFile + filename + "_" + int_Width + "x" + int_Height + ".jpg");
            }

            oldimage.Dispose();

            return true;
        }
        /// <summary>
        /// 图片缩略图生成算法
        /// </summary>
        /// <param name="int_Width">宽度</param>
        /// <param name="int_Height">高度</param>
        /// <param name="input_ImgFile">文件路径</param>
        /// <param name="out_ImgFile">保存文件路径</param>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static bool MakeCompressionThumbnail(int int_Width, int int_Height, string input_ImgFile, string out_ImgFile, string filename)
        {
            System.Drawing.Image oldimage = System.Drawing.Image.FromFile(input_ImgFile + filename);
            float New_Width; // 新的宽度    
            float New_Height; // 新的高度    
            float Old_Width, Old_Height; //原始高宽    
            int flat = 0;//标记图片是不是等比    


            int xPoint = 0;//若果要补白边的话，原图像所在的x，y坐标。    
            int yPoint = 0;
            //判断图片    

            Old_Width = (float)oldimage.Width;
            Old_Height = (float)oldimage.Height;

            if ((Old_Width / Old_Height) > ((float)int_Width / (float)int_Height)) //当图片太宽的时候    
            {
                New_Height = Old_Height * ((float)int_Width / (float)Old_Width);
                New_Width = (float)int_Width;
                //此时x坐标不用修改    
                yPoint = (int)(((float)int_Height - New_Height) / 2);
                flat = 1;
            }
            else if ((oldimage.Width / oldimage.Height) == ((float)int_Width / (float)int_Height))
            {
                New_Width = int_Width;
                New_Height = int_Height;
            }
            else
            {
                New_Width = (int)oldimage.Width * ((float)int_Height / (float)oldimage.Height);  //太高的时候   
                New_Height = int_Height;
                //此时y坐标不用修改    
                xPoint = (int)(((float)int_Width - New_Width) / 2);
                flat = 1;
            }

            System.Drawing.Image.GetThumbnailImageAbort callb = null;
            // ＝＝＝缩小图片＝＝＝    
            //调用缩放算法
            System.Drawing.Image thumbnailImage = Makesmallimage(oldimage, (int)New_Width, (int)New_Height);
            Bitmap bm = new Bitmap(thumbnailImage);
          

            try
            {
                if (flat != 0)
                {
                    Bitmap bmOutput = new Bitmap(int_Width, int_Height);
                    Graphics gc = Graphics.FromImage(bmOutput);
                   

                     SolidBrush tbBg = new SolidBrush(Color.White);
                    gc.FillRectangle(tbBg, 0, 0, int_Width, int_Height); //填充为白色    
                    gc.DrawImage(bm, xPoint, yPoint, (int)New_Width, (int)New_Height);
                 
                    bmOutput.Save(out_ImgFile + filename + "_" + int_Width + "x" + int_Height + ".jpg");
                    //bmOutput.Save(out_ImgFile + filename + "_" + int_Width+"x"+int_Height+".jpg");
                }
                else
                {
                  
                    bm.Save(out_ImgFile + filename + "_" + int_Width + "x" + int_Height + ".jpg");
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                oldimage.Dispose(); 

                bm.Dispose();

            }

            return true;
        }

        /// <summary>
        /// 生成缩略图 (高清缩放)
        /// </summary>
        /// <param name="originalImage">原图片</param>
        /// <param name="width">缩放宽度</param>
        /// <param name="height">缩放高度</param>
        /// <returns></returns>
        public static Image Makesmallimage(System.Drawing.Image originalImage, int width, int height)
        {

            int towidth = 0;
            int toheight = 0;
            if (originalImage.Width > width && originalImage.Height < height)
            {
                towidth = width;
                toheight = originalImage.Height;
            }

            if (originalImage.Width < width && originalImage.Height > height)
            {
                towidth = originalImage.Width;
                toheight = height;
            }
            if (originalImage.Width > width && originalImage.Height > height)
            {
                towidth = width;
                toheight = height;
            }
            if (originalImage.Width < width && originalImage.Height < height)
            {
                towidth = originalImage.Width;
                toheight = originalImage.Height;
            }
            int x = 0;//左上角的x坐标 
            int y = 0;//左上角的y坐标 


            //新建一个bmp图片 
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板 
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            g.CompositingQuality = CompositingQuality.HighQuality;
            //设置高质量插值法 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充 
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分 
            g.DrawImage(originalImage, x, y, towidth, toheight);
            originalImage.Dispose();
            //bitmap.Dispose();
            g.Dispose();
            return bitmap;


        }

        /// <summary> 
        /// 生成缩略图 (没有补白)
        /// </summary> 
        /// <param name="originalImagePath">源图路径（物理路径）</param> 
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param> 
        /// <param name="width">缩略图宽度</param> 
        /// <param name="height">缩略图高度</param>   
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = 0;
            int toheight = 0;
            if (originalImage.Width > width && originalImage.Height < height)
            {
                towidth = width;
                toheight = originalImage.Height;
            }

            if (originalImage.Width < width && originalImage.Height > height)
            {
                towidth = originalImage.Width;
                toheight = height;
            }
            if (originalImage.Width > width && originalImage.Height > height)
            {
                towidth = width;
                toheight = height;
            }
            if (originalImage.Width < width && originalImage.Height < height)
            {
                towidth = originalImage.Width;
                toheight = originalImage.Height;
            }
            int x = 0;//左上角的x坐标 
            int y = 0;//左上角的y坐标 


            //新建一个bmp图片 
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板 
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            g.CompositingQuality = CompositingQuality.HighQuality;
         
            //设置高质量插值法 
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;  

            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充 
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分 
            g.DrawImage(originalImage, x, y, towidth, toheight);

            try
            {

                bitmap.Save(thumbnailPath);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        /// <summary>  
        /// 压缩图片  
        /// </summary>  
        /// <param name="filePath">要压缩的图片的路径</param>  
        /// <param name="filePath_ystp">压缩后的图片的路径</param>  
        public static void ystp(string filePath, string filePath_ystp)
        {
            //Bitmap  
            Bitmap bmp = null;

            //ImageCoderInfo   
            ImageCodecInfo ici = null;

            //Encoder  
            System.Drawing.Imaging.Encoder ecd = null;

            //EncoderParameter  
            EncoderParameter ept = null;

            //EncoderParameters  
            EncoderParameters eptS = null;

            try
            {
                bmp = new Bitmap(filePath);

                ici = getImageCoderInfo("image/jpeg");

                ecd = System.Drawing.Imaging.Encoder.Quality;

                eptS = new EncoderParameters(1);

                ept = new EncoderParameter(ecd, 50L);
                eptS.Param[0] = ept;
                bmp.Save(filePath_ystp, ici, eptS);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                bmp.Dispose();

                ept.Dispose();

                eptS.Dispose();
            }
        }
        /// <summary>  
        /// 获取图片编码类型信息  
        /// </summary>  
        /// <param name="coderType">编码类型</param>  
        /// <returns>ImageCodecInfo</returns>  
        private static ImageCodecInfo getImageCoderInfo(string coderType)
        {
            ImageCodecInfo[] iciS = ImageCodecInfo.GetImageEncoders();

            ImageCodecInfo retIci = null;

            foreach (ImageCodecInfo ici in iciS)
            {
                if (ici.MimeType.Equals(coderType))
                    retIci = ici;
            }

            return retIci;
        }
         /// <summary>  
         /// 无损压缩图片  
         /// </summary>  
         /// <param name="sFile">原图片</param>  
         /// <param name="dFile">压缩后保存位置</param>  
         /// <param name="dHeight">高度</param>  
         /// <param name="dWidth">宽度</param>  
         /// <param name="flag">压缩质量 1-100</param>  
         /// <returns></returns>  
         public static bool CompressImage(string sFile, string dFile, int dHeight, int dWidth, int flag)  
         {  
   
             System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);  
             ImageFormat tFormat = iSource.RawFormat;  
             int sW = 0, sH = 0;  
             //按比例缩放  
             Size tem_size = new Size(iSource.Width, iSource.Height);  
   
             if (tem_size.Width > dHeight ||tem_size.Width > dWidth)   
             {  
                 if ((tem_size.Width * dHeight) > (tem_size.Height * dWidth))  
                 {  
                     sW = dWidth;  
                     sH = (dWidth * tem_size.Height) / tem_size.Width;  
                 }  
                 else 
                 {  
                     sH = dHeight;  
                     sW = (tem_size.Width * dHeight) / tem_size.Height;  
                 }  
             }  
             else 
             {  
                 sW = tem_size.Width;  
                 sH = tem_size.Height;  
             }  
             Bitmap ob = new Bitmap(dWidth, dHeight);  
             Graphics g = Graphics.FromImage(ob);  
             g.Clear(Color.White);  
             g.CompositingQuality = CompositingQuality.HighQuality;  
             g.SmoothingMode = SmoothingMode.HighQuality;  
             g.InterpolationMode = InterpolationMode.HighQualityBicubic;  
             g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);  
             g.Dispose();  
             //以下代码为保存图片时，设置压缩质量  
             EncoderParameters ep = new EncoderParameters();  
             long[] qy = new long[1];  
             qy[0] = flag;//设置压缩的比例1-100  
             EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);  
             ep.Param[0] = eParam;  
             try 
             {  
                 ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();  
                 ImageCodecInfo jpegICIinfo = null;  
                 for (int x = 0; x < arrayICI.Length; x++)  
                 {  
                     if (arrayICI[x].FormatDescription.Equals("JPEG"))  
                     {  
                         jpegICIinfo = arrayICI[x];  
                         break;  
                     }  
                 }  
                 if (jpegICIinfo != null)  
                 {  
                     ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径  
                 }  
                 else 
                 {  
                     ob.Save(dFile, tFormat);  
                 }
                 return true;
             }
             catch
             {
                 return false;
             }
             finally
             {
                 iSource.Dispose();
                 ob.Dispose();
             }

         } 

    }

}



