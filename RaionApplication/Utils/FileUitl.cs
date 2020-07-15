// <copyright file="FileUitl.cs" company="RAION SOFTWARE Sp. z o.o.">
// Copyright (c) RAION SOFTWARE Sp. z o.o.. All rights reserved.
// </copyright>

namespace RaionApplication.Utils
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using RaionApplication.Extensions;

    /// <remarks>
    /// https://stackoverflow.com/a/1406853
    /// https://stackoverflow.com/a/13513854
    /// </remarks>
    public class FileUitl
    {
        public static bool WaitForFile(string filename)
        {
            // This will lock the execution until the file is ready
            var task = Task.Run(() => IsFileReady(filename));
            if (task.Wait(TimeSpan.FromSeconds(10)))
            {
                return task.Result;
            }
            else
            {
                throw new WritingToLocalFileException("Access timed out");
            }
        }

        public static bool IsFileReady(string filename)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return inputStream.Length > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
