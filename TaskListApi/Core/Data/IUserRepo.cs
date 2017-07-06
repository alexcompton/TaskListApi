using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaskListApi.Dto;

namespace TaskListApi.Core.Data
{
    public interface IUserRepo
    {
        Task Add(UserDto t);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetByUsername(string username, long userid);
        Task Delete(long id);
        Task Update(UserDto t);
    }
}