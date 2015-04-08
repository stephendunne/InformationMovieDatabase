using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCs00130835_CA2.Models
{
    internal class IMDbInitializer : DropCreateDatabaseAlways<IMDb>
    {
        protected override void Seed(IMDb context)
        {
            Actor a1 = new Actor()
            {
                Name = "Robert Mulvany",
                Age = 32,
                Gender = Sex.Male
            };
            Actor a2 = new Actor()
            {
                Name = "John Doe",
                Age = 27,
                Gender = Sex.Male
            };
            Actor a3 = new Actor()
            {
                Name = "Paul Reid",
                Age = 41,
                Gender = Sex.Male
            };
            Actor a4 = new Actor()
            {
                Name = "Jack Daniels",
                Age = 54,
                Gender = Sex.Male
            };
            Actor a5 = new Actor()
            {
                Name = "Danny Williams",
                Age = 22,
                Gender = Sex.Male
            };
            Actor a6 = new Actor()
            {
                Name = "Sarah Jones",
                Age = 25,
                Gender = Sex.Female
            };
            Actor a7 = new Actor()
            {
                Name = "Mary Dunne",
                Age = 52,
                Gender = Sex.Female
            };
            Actor a8 = new Actor()
            {
                Name = "Jessie Newton",
                Age = 33,
                Gender = Sex.Female
            };
            Actor a9 = new Actor()
            {
                Name = "Philomena Bermingham",
                Age = 46,
                Gender = Sex.Female
            };
            Actor a10 = new Actor()
            {
                Name = "Philomena Bermingham",
                Age = 36,
                Gender = Sex.Female
            };

            Movie m1 = new Movie()
            {
                Title = "The Reckoning",
                MovieGenre = Genre.Horror,
                Acting = new List<Actor>()
                {
                    a1,a3,a7
                }
            };

            Movie m2 = new Movie()
            {
                Title = "The Love Triangle",
                MovieGenre = Genre.Romance,
                Acting = new List<Actor>()
                {
                    a2,a6,a10
                }
            };

            Movie m3 = new Movie()
            {
                Title = "Good Cop, Bad Cop",
                MovieGenre = Genre.Action,
                Acting = new List<Actor>()
                {
                    a4,a5
                }
            };

            Movie m4 = new Movie()
            {
                Title = "Power Hour",
                MovieGenre = Genre.Thriller,
                Acting = new List<Actor>()
                {
                    a1,a4,a8,a9
                }
            };

            Movie m5 = new Movie()
            {
                Title = "The Expressionables",
                MovieGenre = Genre.Comedy,
                Acting = new List<Actor>()
                {
                    a1,a2,a3,a4,a5,a6,a7,a8,a9,a10
                }
            };

            context.Actors.Add(a1);
            context.Actors.Add(a2);
            context.Actors.Add(a3);
            context.Actors.Add(a4);
            context.Actors.Add(a5);
            context.Actors.Add(a6);
            context.Actors.Add(a7);
            context.Actors.Add(a8);
            context.Actors.Add(a9);
            context.Actors.Add(a10);
            context.Movies.Add(m1);
            context.Movies.Add(m2);
            context.Movies.Add(m3);
            context.Movies.Add(m4);
            context.Movies.Add(m5);
            context.SaveChanges();
            base.Seed(context);
        }
    }
        public enum Genre
        {
            Comedy, Horror, Action, Romance, Thriller
        };

        public class Movie
        {
            public int MovieId { get; set; }
            [DisplayName("Movie Title")]
            public string Title { get; set; }
            [DisplayName("Genre")]
            public Genre MovieGenre { get; set; }
            [DisplayName("Starring Actors")]
            public List<Actor> Acting { get; set; }
        }

        public enum Sex
        {
            Male,
            Female
        };

        public class Actor
        {
            public int ActorId { get; set; }
            [DisplayName("Professional Name")]
            public string Name { get; set; }
            [DisplayName("Age")]
            public int Age { get; set; }
            [DisplayName("Gender")]
            public Sex Gender { get; set; }
            [DisplayName("Filmography")]
            public List<Movie> Films { get; set; }
        }

        public class IMDb : DbContext
        {
            public DbSet<Movie> Movies { get; set; }
            public DbSet<Actor> Actors { get; set; }
            public IMDb()
                : base("IMDb")
            {
            }
        }

        
    
    

        
    
}