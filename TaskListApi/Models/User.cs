using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskListApi.Models
{
    public class User
    {
        public long id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime? insertdate { get; set; }
    }
}