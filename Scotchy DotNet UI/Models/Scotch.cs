using Note.Model;
using Price.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tasting.Model;
using User.Model;
using WishList.Model;

namespace Scotch.Model
{
    public class ScotchDTO
    {
        public string _id { get; set; }
        [Display(Name = "Distiller")]
        public string distillerName { get; set; }
        [Display(Name = "Expression")]
        public string flavor { get; set; }
        [Display(Name = "Age")]
        public int? age { get; set; }
        [Display(Name = "Added")]
        public DateTime added { get; set; }
        [Display(Name = "Style")]
        public string style { get; set; }
        [Display(Name = "Region")]
        public string region { get; set; }
        [Display(Name = "In Stock")]
        public bool inStock { get; set; }
        [Display(Name = "Creator")]
        public CreatorDTO creator { get; set; }
        [Display(Name = "Bottling Notes")]
        public string bottlingNotes { get; set; }
        [Display(Name = "Comment")]
        public string comment { get; set; }
        [Display(Name = "Notes")]
        public IList<NoteDTO> notes { get; set; }
        [Display(Name = "Tasting Notes")]
        public IList<TastingDTO> tastings { get; set; }
        [Display(Name = "Wish Lists")]
        public IList<string> wishLists { get; set; }
        [Display(Name = "Prices")]
        public IList<PriceDTO> prices { get; set; }
        [Display(Name = "Dram")]
        public string dramName { get; set; }
        [Display(Name = "Rating")]
        public int rating { get; set; }
    }
}
