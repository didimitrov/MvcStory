﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MvcStory.Models
{
    public class Story
    {
        public Story()
        {
            ReleaseDate = DateTime.Now;
            Rating = 3;
        }

        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text  { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:DAY-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Rate")]
        [Required]
        [Range(1,6)]
        public byte Rating { get; set; }

        public string Photo { get; set; }

        //public String Image     
        //{
        //    get
        //    {
        //        return "~/Content/Images/hire_asp_net_developer.png";
        //    }

        //}       
    }

    public class StoryDbContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }

    }
}