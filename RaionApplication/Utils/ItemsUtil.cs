// <copyright file="ItemsUtil.cs" company="RAION SOFTWARE Sp. z o.o.">
// Copyright (c) RAION SOFTWARE Sp. z o.o.. All rights reserved.
// </copyright>

namespace RaionApplication.Utils
{
    using System;
    using System.IO;
    using RaionApplication.Extensions;

    public class ItemsUtil
    {
        internal static void TryToWriteLocalFile(string text, string path)
        {
            try
            {
                var tempPath = Path.GetTempPath();
                var localFilePath = Path.Combine(tempPath, path);

                TryToCreateLocalFile(localFilePath);

                using (StreamWriter streamWriter = File.AppendText(localFilePath))
                {
                    streamWriter.WriteLine(text);
                    streamWriter.Flush();
                }
            }
            catch (WritingToLocalFileException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new WritingToLocalFileException("writing a new record-posted", ex);
            }
        }

        private static void TryToCreateLocalFile(string path)
        {
            if (!File.Exists(path))
            {
                try
                {
                    File.Create(path);
                }
                catch
                (Exception ex)
                {
                    throw new WritingToLocalFileException("creating local file", ex);
                }
            }
        }
    }
}
