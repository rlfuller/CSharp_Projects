using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;

namespace DVDLibrary.Data.Mock_Repo
{
    public class DVDMockRepo : IDVDRepo
    {

        public static List<DVD> _dvds = new List<DVD>
        {
            new DVD()
            {
                DVDId = 1,
                Title = "Talladega Nights",
                ReleaseDate = new DateTime(2006, 08, 06),
                MPAA = "PG-13",
                Director = "Adam McKay",
                StudioID = 1
            },
            new DVD()
            {
                DVDId = 2,
                Title = "Happy Gilmore",
                ReleaseDate = new DateTime(1996, 02, 16),
                MPAA = "R",
                Director = "Dennis Dugan"
            },
            new DVD()
            {
                DVDId = 3,
                Title = "Jurassic World",
                ReleaseDate = new DateTime(2015, 06, 12),
                MPAA = "PG-13",
                Director = "Colin Trevorrow",
                StudioID = 4
            }

        };

        private static List<MPAA> _mpaas = new List<MPAA>()
        {
            new MPAA() {MPAARating = "G", MPAADescription = "General Audiences"},
            new MPAA() {MPAARating = "PG", MPAADescription = "Parental Guidance Suggested"},
            new MPAA() {MPAARating = "PG-13", MPAADescription = "Parents Strongly Cautioned"},
            new MPAA() {MPAARating = "R", MPAADescription = "Restricted"},
            new MPAA() {MPAARating = "NC-17", MPAADescription = "No under 17 allowed"}
        };

        private static List<Studio> _studios = new List<Studio>()
        {
            new Studio() {StudioId = 1, StudioName = "MGM"},
            new Studio() {StudioId = 2, StudioName = "Universal"},
            new Studio() {StudioId = 3, StudioName = "Other"},
        };

        private static List<Actor> _actors = new List<Actor>()
        {
            new Actor() {ActorId = 1, ActorName = "Chris Pratt"},
            new Actor() {ActorId = 2, ActorName = "Will Ferrell"},
            new Actor() {ActorId = 3, ActorName = "John C Riley"},
            new Actor() {ActorId = 4, ActorName = "Adam Sandler"},
            new Actor() {ActorId = 5, ActorName = "Other"}
        };

        private static List<DVDActorDetail> _dvdActorDetails = new List<DVDActorDetail>()
        {
           
            new DVDActorDetail() {ActorId = 2, DVDId = 1},
            new DVDActorDetail() {ActorId = 3, DVDId = 1},
            new DVDActorDetail() {ActorId = 5, DVDId = 2}
        };

        public int AddDVD(DVD dvd)
        {
            int results = _dvds.Max(d => d.DVDId);

            results++;

            dvd.DVDId = results;

            _dvds.Add(dvd);

            return results;
        }

        public List<DVDActorDetail> GetActorDetails(int dvdId)
        {
            var results = new List<DVDActorDetail>();

            foreach (var actorDetail in _dvdActorDetails)
            {
                if (dvdId == actorDetail.DVDId)
                {
                    results.Add(actorDetail);
                }
            }

            return results;
        }

        public List<Actor> GetAllActors()
        {
            return _actors;
        }

        public List<DVD> GetAllDVDs()
        {
            return _dvds;
        }

        public List<MPAA> GetAllMPAA()
        {
            return _mpaas;
        }

        public List<Studio> GetAllStudios()
        {
            return _studios;
        }

        public DVD GetDVDById(int id)
        {
            var results = new DVD();

            results = _dvds.FirstOrDefault(d => d.DVDId.Equals(id));

            return results;
        }

        public List<DVD> GetDVDByTitle(string title)
        {
            var results = new List<DVD>();
            
            foreach (var item in _dvds)
            {
                if (item.Title.Contains(title))
                {
                    results.Add(item);
                }
            }

            return results;
        }

        public void RemoveDVD(int id)
        {
            var dvdToRemove = GetDVDById(id);

            _dvds.Remove(dvdToRemove);
        }
    }
}
