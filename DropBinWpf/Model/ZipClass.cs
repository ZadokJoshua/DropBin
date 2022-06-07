using System;
using System.IO;
using System.IO.Compression;

namespace DropBinWpf.Model
{
    public class ZipClass
    {
        public static string OriginalZippedFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static void ZipFileOperation(string confirmedPath, string FileName)
        {
            ZipFile.CreateFromDirectory(confirmedPath, Path.Combine(OriginalZippedFolderPath, $"{FileName}.zip"));
        }

        public static void ZipFileOperation(string confirmedPath, string newPath, string FileName)
        {
            string newFilePath = Path.Combine(newPath, $"{FileName}.zip");
            ZipFile.CreateFromDirectory(confirmedPath, newFilePath);
        }
    }
}
