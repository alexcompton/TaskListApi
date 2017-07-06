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
    public class UserController : ApiController
    {
        IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize]
        [Route("GetAccountInfo")]
        public async Task<User> GetAccount(string username)
        {
            var userId = long.Parse(RequestContext.Principal.Identity.Name);
            return await service.GetByUsername(username, userId);
        }

        [HttpPost]
        [Route("RegisterAccount")]
        public async Task RegisterAccount([FromBody]User user) => await service.Add(user);
        
        [HttpPut]
        [Authorize]
        [Route("UpdateAccount")]
        public async Task UpdateAccount([FromBody]User user) => await service.Update(user);
        
        [HttpDelete]
        [Authorize]
        [Route("DeleteAccount")]
        public async Task DeleteAccount(int id) => await service.Delete(id);
    }
}