﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskListApi.Dto
{
    public class UserDto
    {
        public long id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime? insertdate { get; set; }
    }
}