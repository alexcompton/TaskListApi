using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TaskListApi.Builder;
using TaskListApi.Core.Data;
using TaskListApi.Core.Service;
using TaskListApi.Core.Util;
using TaskListApi.Dto;
using TaskListApi.Models;
using TaskListApi.Repo;
using TaskListApi.Service;

namespace TaskListApi.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents(ref HttpConfiguration config)
        {
            var container = new UnityContainer();

            RegisterBuilders(ref container);
            RegisterRepos(ref container);
            RegisterServices(ref container);

            config.DependencyResolver = new App_Start.UnityResolver(container);
        }

        private static void RegisterBuilders(ref UnityContainer container)
        {
            container.RegisterType<IObjectBuilder<User, UserDto>, UserBuilder>();
            container.RegisterType<IObjectBuilder<UserTask, UserTaskDto>, UserTaskBuilder>();
        }

        private static void RegisterServices(ref UnityContainer container)
        {
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserTaskService, UserTaskService>();
        }

        private static void RegisterRepos(ref UnityContainer container)
        {
            container.RegisterType<IUserRepo, UserRepo>();
            container.RegisterType<IUserTaskRepo, UserTaskRepo>();
        }
    }
}