using DropBinWpf.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropBinWpf.DataAccess
{
    public class FolderInfoContext : DbContext
    {
        public DbSet<FolderInfo>? FolderInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Documents\DataBases\LearnEFCore.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
