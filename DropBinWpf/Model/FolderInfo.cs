using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropBinWpf.Model
{
    public class FolderInfo
    {
        [Key]
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? NewProjectPath { get; set; }
    }
}
