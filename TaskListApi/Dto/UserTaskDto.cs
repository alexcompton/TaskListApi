using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskListApi.Dto
{
    public class UserTaskDto
    {
        public long id { get; set; }
        public string title { get; set; }
        public DateTime completedate { get; set; }
        public long userid { get; set; }
        public bool taskcomplete { get; set; }
        public DateTime? insertdate { get; set; }
    }
}