namespace Karma.Services.Migrations
{
    using AutoMapper;
    using DataObjects;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Karma.Services.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MobileQuest, Quest>();
                cfg.CreateMap<Quest, MobileQuest>()
                    .ForMember(dst => dst.ActorId, map => map.MapFrom(x => x.Actor.Id))
                    .ForMember(dst => dst.CreatorId, map => map.MapFrom(x => x.Creator.Id));
            });
        }

        protected override void Seed(Karma.Services.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Badges.AddOrUpdate(
                p => p.Title,
                new Badge { Title = "First Quest Done" }
                );
        }
    }
}
