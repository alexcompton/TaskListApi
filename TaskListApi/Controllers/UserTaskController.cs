using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TaskListApi.Core.Service;
using TaskListApi.Models;

namespace TaskListApi.Controllers
{
    public class UserTaskController : ApiController
    {
        IUserTaskService service;

        public UserTaskController(IUserTaskService service)
        {
            this.service = service;
        }

        [Authorize]
        public async Task<UserTask> GetById(int id)
        {
            var userId = long.Parse(RequestContext.Principal.Identity.Name);
            return await service.GetByID(id,userId);
        }

        [Authorize]
        public async Task<IEnumerable<UserTask>> Get()
        {
            var userId = long.Parse(RequestContext.Principal.Identity.Name);
            return await service.GetAll(userId);
        }

        [Authorize]
        public async Task Post([FromBody]UserTask task)
        {
            task.userid = long.Parse(RequestContext.Principal.Identity.Name);
            await service.Add(task);
        }

        [Authorize]
        public async Task Put([FromBody]UserTask task)
        {
            task.userid = long.Parse(RequestContext.Principal.Identity.Name);
            await service.Update(task);
        }

        [Authorize]
        public async Task Delete(int id)
        {
            var userId = long.Parse(RequestContext.Principal.Identity.Name);
            await service.Delete(id,userId);
        }
    }
}