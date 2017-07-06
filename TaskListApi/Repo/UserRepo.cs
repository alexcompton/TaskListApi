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
    public class UserRepo : IUserRepo
    {
        private MySqlConnection Connection
        {
            get
            {
                return new MySqlConnection(ConfigurationManager.ConnectionStrings["MySql"].ConnectionString);
            }
        }

        public async Task Add(UserDto user)
        {
            using (var conn = Connection)
            {
                var query = @"INSERT INTO user (firstname, lastname, username, password) 
                              VALUES (@firstname, @lastname, @username, @password);";
                conn.Open();
                await conn.ExecuteAsync(query,
                    new
                    {
                        firstname = user.firstname,
                        lastname = user.lastname,
                        username = user.username,
                        password = user.password
                    });
            }
        }

        public async Task Delete(long id)
        {
            using (var conn = Connection)
            {
                var query = @"DELETE FROM user 
                              WHERE id = @id;";
                conn.Open();
                await conn.ExecuteAsync(query, new { id = id });
            }
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            using (var conn = Connection)
            {
                var query = @"SELECT * FROM user;";
                conn.Open();
                return await conn.QueryAsync<UserDto>(query);
            }
        }

        public async Task<UserDto> GetByUsername(string username, long userid)
        {
            using (var conn = Connection)
            {
                var query = @"SELECT * 
                              FROM user 
                              WHERE username = @username;";
                conn.Open();
                var dtos = await conn.QueryAsync<UserDto>(query, new { username = username });
                return dtos.FirstOrDefault();
            }
        }

        public async Task Update(UserDto user)
        {
            using (var conn = Connection)
            {
                var query = @"UPDATE user
                              SET 
                              firstname = @firstname,
                              lastname = @lastname,
                              username = @username,
                              password = @password
                              WHERE id = @id;";
                conn.Open();
                await conn.ExecuteAsync(query, new
                {
                    firstname = user.firstname,
                    lastname = user.lastname,
                    username = user.username,
                    password = user.password,
                    id = user.id
                });
            }
        }
    }
}