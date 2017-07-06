using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaskListApi.Models;

namespace TaskListApi.Core.Service
{
    public interface IUserTaskService
    {
        Task Add(UserTask t);
        Task<IEnumerable<UserTask>> GetAll(long userid);
        Task<UserTask> GetByID(long id, long userid);
        Task Delete(long id, long userid);
        Task Update(UserTask t);
    }
}