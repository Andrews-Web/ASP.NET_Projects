using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperManagementSystem.Models
{
    public class MyPaperViewModel
    {
        public IEnumerable<PaperInfo> Paper { get; set; }
        public IEnumerable<TopicInfo> Topic { get; set; }
    }
}