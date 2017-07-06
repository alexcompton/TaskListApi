using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApi.Core.Util;
using TaskListApi.Dto;
using TaskListApi.Models;

namespace TaskListApi.Builder
{
    public class UserTaskBuilder : ObjectBuilderBase<UserTask, UserTaskDto>
    {
        public override UserTask ToObject(UserTaskDto obj)
        {
            return new UserTask
            {
                id = obj.id,
                title = obj.title,
                completedate = obj.completedate,
                userid = obj.userid,
                taskcomplete = obj.taskcomplete,
                insertdate = obj.insertdate
            };
        }

        public override UserTaskDto ToObject(UserTask obj)
        {
            return new UserTaskDto
            {
                id = obj.id,
                title = obj.title,
                completedate = obj.completedate,
                userid = obj.userid,
                taskcomplete = obj.taskcomplete,
                insertdate = obj.insertdate
            };
        }
    }
}