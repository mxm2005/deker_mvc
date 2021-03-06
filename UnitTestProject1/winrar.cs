﻿using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    public class winrar
    {
        #region 压缩文件

        /// <summary>

        /// 压缩文件

        /// </summary>

        /// <param name="filesPath">压缩文件及完整路径(D:\abc)</param>

        /// <param name="zipFilePath">压缩包所存完整路径(D:\a.zip或d:\a.rar)</param>

        public static void CreateZipFile(string filesPath, string zipFilePath)
        {

            if (!Directory.Exists(filesPath))
            {

                Console.WriteLine("Cannot find directory '{0}'", filesPath);

                return;

            }

            try
            {

                string[] filenames = Directory.GetFiles(filesPath);

                using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFilePath)))
                {

                    s.SetLevel(9); // 压缩级别 0-9

                    //s.Password = "123"; //Zip压缩文件密码

                    byte[] buffer = new byte[4096]; //缓冲区大小

                    foreach (string file in filenames)
                    {

                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));

                        entry.DateTime = DateTime.Now;

                        s.PutNextEntry(entry);

                        using (FileStream fs = File.OpenRead(file))
                        {

                            int sourceBytes;

                            do
                            {

                                sourceBytes = fs.Read(buffer, 0, buffer.Length);

                                s.Write(buffer, 0, sourceBytes);

                            } while (sourceBytes > 0);

                        }

                    }

                    s.Finish();

                    s.Close();

                }

            }

            catch (Exception ex)
            {

                AutoCompare.ErrorLog.SaveError(ex, "压缩文件出错！");

            }

        }

        #endregion

        #region 解压文件

        /// <summary>

        /// 解压文件

        /// </summary>

        /// <param name="zipFilePath">解压文件及完整路径(d:\a.zip或d:\a.rar)</param>

        public static void UnZipFile(string zipFilePath)
        {

            if (!File.Exists(zipFilePath))
            {

                Console.WriteLine("Cannot find file '{0}'", zipFilePath);

                return;

            }

            using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFilePath)))
            {

                ZipEntry theEntry;

                while ((theEntry = s.GetNextEntry()) != null)
                {

                    Console.WriteLine(theEntry.Name);

                    string directoryName = Path.GetDirectoryName(theEntry.Name);

                    string fileName = Path.GetFileName(theEntry.Name);

                    // create directory

                    if (directoryName.Length > 0)
                    {

                        Directory.CreateDirectory(directoryName);

                    }

                    if (fileName != String.Empty)
                    {

                        using (FileStream streamWriter = File.Create(theEntry.Name))
                        {

                            int size = 2048;

                            byte[] data = new byte[2048];

                            while (true)
                            {

                                size = s.Read(data, 0, data.Length);

                                if (size > 0)
                                {

                                    streamWriter.Write(data, 0, size);

                                }

                                else
                                {

                                    break;

                                }

                            }

                        }

                    }

                }

            }

        }

        #endregion
    }
}
