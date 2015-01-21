using System;
using MvcStory.Models;

namespace MvcStory.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<StoryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoryDbContext context)
        {
            context.Stories.AddOrUpdate(i => i.Title,
        new Story
        {
            Title = "When Harry Met Sally",
            ReleaseDate = DateTime.Now,   //Parse("2015-1-30")
            Text = "Romantic Comedy Romantic Comedy Romantic Comedy Romantic Comedy Romantic Comedy",
            Rating = 3
          
        },

         new Story
         {
             Title = "Ghostbusters ",
             ReleaseDate = DateTime.Parse("1-13-2015"),
             Text = "Comedy Comedy Comedy Comedy Comedy Comedy",
             Rating = 3

         },

         new Story
         {
             Title = "Ghostbusters 2",
             ReleaseDate = DateTime.Parse("2-01-2015"),
             Text = "Comedy bababababababababababbababab",
             Rating = 3

         },

       new Story
       {
           Title = "Rio Bravo",
           ReleaseDate = DateTime.Now, //Parse("2015-1-30"),
           Text = "Western Gang Western GangWestern GangWestern GangWestern Gang ",
           Rating = 3

       }
   );
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
        }
    }
}
