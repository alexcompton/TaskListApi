using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaskListApi.Core.Data;
using TaskListApi.Dto;

namespace TaskListApi.Repo
{
    public class UserTaskRepo : IUserTaskRepo
    {
        private MySqlConnection Connection
        {
            get
            {
                return new MySqlConnection(ConfigurationManager.ConnectionStrings["MySql"].ConnectionString);
            }
        }

        public async Task Add(UserTaskDto task)
        {
            using (var conn = Connection)
            {
                var query = @"INSERT INTO usertasks (title, completedate, userid, taskcomplete) 
                              VALUES (@title, @completedate, @userid, @taskcomplete);";
                conn.Open();
                await conn.ExecuteAsync(query,
                    new
                    {
                        title = task.title,
                        completedate = task.completedate,
                        userid = task.userid,
                        taskcomplete = task.taskcomplete
                    });
            }
        }

        public async Task Delete(long id, long userid)
        {
            using (var conn = Connection)
            {
                var query = @"DELETE FROM usertasks 
                              WHERE id = @id
                              AND userid = @userid;";
                conn.Open();
                await conn.ExecuteAsync(query, new { id = id, userid = userid });
            }
        }

        public async Task<IEnumerable<UserTaskDto>> GetAll(long id)
        {
            using (var conn = Connection)
            {
                var query = @"SELECT * 
                              FROM usertasks
                              WHERE userid = @id;";
                conn.Open();
                return await conn.QueryAsync<UserTaskDto>(query, new { id = id });
            }
        }

        public async Task<UserTaskDto> GetByID(long id, long userid)
        {
            using (var conn = Connection)
            {
                var query = @"SELECT * 
                              FROM usertasks
                              WHERE id = @id
                              AND userid = @userid;";
                conn.Open();
                var dtos = await conn.QueryAsync<UserTaskDto>(query, new { id = id, userid = userid });
                return dtos.FirstOrDefault();
            }
        }

        public async Task Update(UserTaskDto task)
        {
            using (var conn = Connection)
            {
                var query = @"UPDATE usertasks
                              SET 
                              title = @title,
                              completedate = @completedate,
                              userid = @userid,
                              taskcomplete = @taskcomplete
                              WHERE id = @id;";
                conn.Open();
                await conn.ExecuteAsync(query, new
                {
                    title = task.title,
                    completedate = task.completedate,
                    userid = task.userid,
                    taskcomplete = task.taskcomplete,
                    id = task.id
                });
            }
        }
    }
}