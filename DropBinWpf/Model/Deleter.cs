using System.IO;

namespace DropBinWpf.Model
{
    public class Deleter
    {
        public static bool DeletingOperation(string path)
        {
            var binDirectory = Path.Combine(path, "bin");
            var objDirectory = Path.Combine(path, "obj");

            if (Directory.Exists(binDirectory) && Directory.Exists(objDirectory))
            {
                Directory.Delete(binDirectory);
                Directory.Delete(objDirectory);
                return true;
            }
            else if (Directory.Exists(binDirectory) && !Directory.Exists(objDirectory))
            {
                Directory.Delete(binDirectory);
                return true;
            }
            else if (!Directory.Exists(binDirectory) && Directory.Exists(objDirectory))
            {
                Directory.Delete(objDirectory);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeletingOperation(string path, FolderEnum folderEnum)
        {
            var binDirectory = Path.Combine(path, "bin");
            var objDirectory = Path.Combine(path, "obj");

            if (folderEnum == FolderEnum.Bin)
            {
                if (Directory.Exists(objDirectory))
                {
                    Directory.Delete(objDirectory);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (folderEnum == FolderEnum.Obj)
            {
                if (Directory.Exists(binDirectory))
                {
                    Directory.Delete(binDirectory);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
