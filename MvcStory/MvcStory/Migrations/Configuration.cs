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
         // ReleaseDate = DateTime.Parse("1989-1-11"),
            Text = "Romantic Comedy Romantic Comedy Romantic Comedy Romantic Comedy Romantic Comedy",
          //  Price = 7.99M
        },

         new Story
         {
             Title = "Ghostbusters ",
        //   ReleaseDate = DateTime.Parse("1984-3-13"),
             Text = "Comedy Comedy Comedy Comedy Comedy Comedy",
        //     Price = 8.99M
         },

         new Story
         {
             Title = "Ghostbusters 2",
       //    ReleaseDate = DateTime.Parse("1986-2-23"),
             Text = "Comedy bababababababababababbababab",
         //    Price = 9.99M
         },

       new Story
       {
           Title = "Rio Bravo",
      //   ReleaseDate = DateTime.Parse("1959-4-15"),
           Text = "Western Gang Western GangWestern GangWestern GangWestern Gang ",
         //  Price = 3.99M
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
