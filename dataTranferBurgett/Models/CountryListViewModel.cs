using System.Collections.Generic;

namespace dataTranferBurgett.Models
{
    public class CountryListViewModel : CountryViewModel
    {
        public List<Country> Countries { get; set; }

        private List<Game> games;
        public List<Game> Games {
            get => games;
            set {
                games = value;
                games.Insert(0,
                    new Game { GameID = "all", Name = "All" });
            }
        }
        private List<Sport> sports;
        public List<Sport> Sports
        {
            get => sports;
            set
            {
                sports = value;
                sports.Insert(0,
                    new Sport { SportID = "all", Name = "All" });
            }
        }
        private List<Category> categories;
        public List<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                categories.Insert(0,
                    new Category { CategoryId = "all", Name = "All" });
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
