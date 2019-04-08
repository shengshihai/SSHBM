using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common.ToolsHelper
{
    public class DataTableToCsv
    {
        /// <summary>
        /// DataTableToCsv
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fileName">文件名称，不用后缀</param>
        /// <remarks>
        /// 文件格式
        ///每条记录占一行 
        ///以逗号为分隔符 
        ///逗号前后的空格会被忽略 
        ///字段中包含有逗号，该字段必须用双引号括起来 
        ///字段中包含有换行符，该字段必须用双引号括起来 
        ///字段前后包含有空格，该字段必须用双引号括起来 
        ///字段中的双引号用两个双引号表示 
        ///字段中如果有双引号，该字段必须用双引号括起来 
        ///第一条记录，可以是字段名 
        /// </remarks>
        public static void TableToCsv(DataTable dt, string fileName)
        {


            if (dt.Columns.Count > 0)
            {
                dt.Columns["UploadTime"].ColumnName = "时间";
                dt.Columns["AgCI1"].ColumnName = "测点";
                dt.Columns["AgCI2"].ColumnName = "测试成果";
            }
            //string stmp = Assembly.GetExecutingAssembly().Location;
            //stmp = stmp.Substring(0, stmp.LastIndexOf('\\'));//删除文件名
            fileName = ConfigurationManager.AppSettings["Path"] + fileName + ".csv";
            //string curPath = Directory.GetCurrentDirectory();
            string savePath = ConfigurationManager.AppSettings["Path"];
            string saveFile = fileName;
            //创建路径和文件
            FileStream fs;
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            if (!File.Exists(saveFile))
            {
                fs = new FileStream(saveFile, FileMode.CreateNew, FileAccess.ReadWrite);
            }
            else
            {
                File.Delete(saveFile);
                fs = new FileStream(saveFile, FileMode.CreateNew, FileAccess.ReadWrite);
            }
            //StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            //写标题
            int iColCount = dt.Columns.Count;
            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dt.Columns[i]);
                //sw.Write(dt.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                    //sw.Write("|");
                }
            }
            sw.Write(sw.NewLine);

            //写内容
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                        sw.Write(dr[i].ToString());
                    //sw.Write(dr[i].ToString());
                    else
                        sw.Write("\"\"");
                    //sw.Write("");
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                        //sw.Write("|");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        public static void ListToCsv<T>(List<T> entitys, string fileName)
        {
            DataTable dt = ListToDataTable(entitys);

           
            //string stmp = Assembly.GetExecutingAssembly().Location;
            //stmp = stmp.Substring(0, stmp.LastIndexOf('\\'));//删除文件名
            fileName = ConfigurationManager.AppSettings["Path"] + fileName + ".csv";
            //string curPath = Directory.GetCurrentDirectory();
            string savePath = ConfigurationManager.AppSettings["Path"];
            string saveFile = fileName;
            //创建路径和文件
            FileStream fs;
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            if (!File.Exists(saveFile))
            {
                fs = new FileStream(saveFile, FileMode.CreateNew, FileAccess.ReadWrite);
            }
            else
            {
                File.Delete(saveFile);
                fs = new FileStream(saveFile, FileMode.CreateNew, FileAccess.ReadWrite);
            }
            //StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            //写标题
            int iColCount = dt.Columns.Count;
            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dt.Columns[i]);
                //sw.Write(dt.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                    //sw.Write("|");
                }
            }
            sw.Write(sw.NewLine);

            //写内容
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                        sw.Write(dr[i].ToString());
                    //sw.Write(dr[i].ToString());
                    else
                        sw.Write("\"\"");
                    //sw.Write("");
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                        //sw.Write("|");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        public static DataTable ListToDataTable<T>(List<T> entitys)
        {

            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                return new DataTable();
            }

            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable("dt");
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }

            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);

                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }

    }
}
