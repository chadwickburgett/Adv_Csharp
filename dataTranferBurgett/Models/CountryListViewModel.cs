using System;
using System.Collections.Generic;

namespace dataTranferBurgett.Models
{
    public class CountryListViewModel : CountryViewModel
    {
        public String UserName { get; set; }
        public List<Country> Countries { get; set; }

        private List<Game> games;
        public List<Game> Games
        {
            get => games;
            set
            {
                games = new List<Game> {
                    new Game { GameID = "all", Name = "All" }
                };
                games.AddRange(value);
            }
        }

        private List<Category> categories;
        public List<Category> Categories
        {
            get => categories;
            set
            {
                categories = new List<Category> {
                    new Category { CategoryId = "all", Name = "All" }
                };
                categories.AddRange(value);
            }
        }

        private List<Sport> sports;
        public List<Sport> Sports
        {
            get => sports;
            set
            {
                sports = new List<Sport> {
                    new Sport { SportID = "all", Name = "All" }
                };
                sports.AddRange(value);
            }
        }

        public string CheckActiveGame(string g) =>
            g.ToLower() == ActiveGame.ToLower() ? "active" : "";
        public string CheckActiveCat(string c) =>
            c.ToLower() == ActiveCat.ToLower() ? "active" : "";
        public string CheckActiveSport(string s) =>
            s.ToLower() == ActiveSport.ToLower() ? "active" : "";

    }
}
