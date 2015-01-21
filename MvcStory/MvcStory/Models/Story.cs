using System;
using System.Data.Entity;

namespace MvcStory.Models
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text  { get; set; }
        public String Image     
        {
            get
            {
                return "~/Content/Images/hire_asp_net_developer.png";
            }

        }       
    }

    public class StoryDbContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }

    }
}