using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApi.Core.Util;
using TaskListApi.Dto;
using TaskListApi.Models;

namespace TaskListApi.Builder
{
    public class UserBuilder : ObjectBuilderBase<User, UserDto>
    {
        public override User ToObject(UserDto obj)
        {
            return new User
            {
                id = obj.id,
                firstname = obj.firstname,
                lastname = obj.lastname,
                username = obj.username,
                password = obj.password,
                insertdate = obj.insertdate
            };
        }

        public override UserDto ToObject(User obj)
        {
            return new UserDto
            {
                id = obj.id,
                firstname = obj.firstname,
                lastname = obj.lastname,
                username = obj.username,
                password = obj.password,
                insertdate = obj.insertdate
            };
        }
    }
}