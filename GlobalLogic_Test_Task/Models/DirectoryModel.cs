using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalLogic_Test_Task.Models
{
    public class DirectoryModel
    {
        public string Name { get; set; }
        public string DateCreated { get; set; }
        public IEnumerable<FileModel> Files { get; set; }

    }
}
