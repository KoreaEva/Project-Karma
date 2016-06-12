using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Karma.Services.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Karma.Services.DomainLogics.Interface;
using Karma.Services.DomainLogics;

namespace Karma.Services
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserStore<User>, UserStore<User>>();
            container.RegisterType<UserManager<User>>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<ApplicationUserManager>();

            container.RegisterType<IQuestService, QuestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}