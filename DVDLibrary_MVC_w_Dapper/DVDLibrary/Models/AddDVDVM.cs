using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DVDLibrary.Models
{
    public class AddDVDVM
    {
        public DVD DvdToAdd { get; set; }
        
        public List<SelectListItem> StudioNameSelectList { get; set; }
        public int StudioSelectedValue { get; set; }

        public List<SelectListItem> MPAASelectList { get; set; }
        public string MPAASelectedValue { get; set; }

        public List<SelectListItem> ActorSelectList { get; set; }
        public List<int> ActorSelectedValues { get; set; }

        public AddDVDVM()
        {
            DvdToAdd = new DVD();
            StudioNameSelectList = new List<SelectListItem>();
            MPAASelectList = new List<SelectListItem>();
            ActorSelectList = new List<SelectListItem>();
            ActorSelectedValues = new List<int>();
        }

        public void CreateStudioList(List<Studio> studios)
        {
            StudioNameSelectList = new List<SelectListItem>();

            foreach (var studio in studios)
            {
                StudioNameSelectList.Add(
                    new SelectListItem
                    {
                        Text = studio.StudioName,
                        Value = studio.StudioId.ToString()
                    }
                );
            }
        }

       
        public void CreateMPAAList(List<MPAA> mpaas)
        {
            MPAASelectList = new List<SelectListItem>();

            foreach (var mpaa in mpaas)
            {
                MPAASelectList.Add(
                    new SelectListItem
                    {
                        Text = mpaa.MPAARating,
                        Value = mpaa.MPAARating
                    }
                );
            }
        }

        // This should be a ListBox on the View, so the user can select multiple Actors.
        public void CreateActorList(List<Actor> actors)
        {
            ActorSelectList = new List<SelectListItem>();

           foreach (var actor in actors)
            {
                ActorSelectList.Add(
                    new SelectListItem
                    {
                        Text = actor.ActorName,
                        Value = actor.ActorId.ToString()
                    }
                );

            }
        }
    }
}