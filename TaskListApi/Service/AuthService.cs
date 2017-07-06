using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TaskListApi.Dto;

namespace TaskListApi.Service
{
    /// <summary>
    /// 
    /// This is a dummy auth service that just reads directly from the database, 
    /// this isn't how I would do this in production code
    /// I was having difficulty getting the following tutorials working:
    /// 
    /// https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/authentication-filters
    /// https://docs.microsoft.com/en-us/aspnet/identity/overview/extensibility/implementing-a-custom-mysql-aspnet-identity-storage-provider
    ///  
    /// 
    /// so essentially I hacked away at this module:
    /// https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/basic-authentication
    /// 
    /// </summary>
    public static class AuthService
    {
        private static MySqlConnection Connection
        {
            get
            {
                return new MySqlConnection(ConfigurationManager.ConnectionStrings["MySql"].ConnectionString);
            }
        }

        // new tuple sytax wasn't really working for me, its new it might not be that solid yet, idk
        // https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#tuples
        public static Tuple<bool, UserDto> IsValidCredentials(string username, string password)
        {
            var validUsers = new List<UserDto>();

            using (var conn = Connection)
            {
                var query = @"SELECT * FROM user;";
                conn.Open();
                validUsers = conn.Query<UserDto>(query).ToList();
            }

            if(validUsers.Count == 0) return new Tuple<bool, UserDto>(false, null);
            var user = validUsers.FirstOrDefault(u => u.username == username);

            return new Tuple<bool, UserDto>((user != null && user.password == password), user);
        }
    }
}