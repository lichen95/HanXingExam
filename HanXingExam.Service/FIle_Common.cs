using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace HanXingExam.Service
{
    public class FIle_Common
    {
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CreateDire(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteDire(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path);
            }
        }
        
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteDireOne(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}