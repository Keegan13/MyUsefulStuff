using System;
using System.Reflection;


namespace MyUsefulStuff
{
    public  static partial class WebPankakes
    {
        /// <summary>
        /// Return MIME type of file
        /// </summary>
        /// <remarks>
        /// Requires: Microsoft.Win32.Registry.dll
        /// Source: https://www.ryadel.com/en/get-file-content-mime-type-from-extension-asp-net-mvc-core/
        /// application/octet-stream
        /// </remarks>
        /// <param name="fileNameOrExtension">File full path</param>
        /// <returns>string MIME type of <param name="fileNameOrExtension">File full path</param> </returns>
        public static string GetMimeTypeByWindowsRegistry(string fileNameOrExtension)
        {
            string mimeType = "application/unknown";
            string ext = (fileNameOrExtension.Contains(".")) ? System.IO.Path.GetExtension(fileNameOrExtension).ToLower() : "." + fileNameOrExtension;
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null) mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
    }
}

