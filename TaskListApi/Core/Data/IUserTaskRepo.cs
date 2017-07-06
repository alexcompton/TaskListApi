using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaskListApi.Dto;

namespace TaskListApi.Core.Data
{
    public interface IUserTaskRepo
    {
        Task Add(UserTaskDto t);
        Task<IEnumerable<UserTaskDto>> GetAll(long id);
        Task<UserTaskDto> GetByID(long id, long userId);
        Task Delete(long id, long userId);
        Task Update(UserTaskDto t);
    }
}