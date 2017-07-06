using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaskListApi.Core.Data;
using TaskListApi.Core.Service;
using TaskListApi.Core.Util;
using TaskListApi.Dto;
using TaskListApi.Models;

namespace TaskListApi.Service
{
    public class UserTaskService : IUserTaskService
    {
        IUserTaskRepo repo;
        IObjectBuilder<UserTask, UserTaskDto> builder;

        public UserTaskService(IUserTaskRepo repo, IObjectBuilder<UserTask, UserTaskDto> builder)
        {
            this.repo = repo;
            this.builder = builder;
        }

        public async Task Add(UserTask task) => await repo.Add(builder.ToObject(task));
        public async Task Delete(long id, long userId) => await repo.Delete(id, userId);
        public async Task<IEnumerable<UserTask>> GetAll(long userid) => builder.ToList(await repo.GetAll(userid));
        public async Task<UserTask> GetByID(long id, long userid) => builder.ToObject(await repo.GetByID(id, userid));
        public async Task Update(UserTask task) => await repo.Update(builder.ToObject(task));
    }
}