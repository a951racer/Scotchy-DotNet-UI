using System;
using System.ComponentModel.DataAnnotations;

namespace Tasting.Model
{
    public class TastingDTO
    {
        public string _id { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime dateAdded { get; set; }
        [Display(Name = "Location")]
        public string location { get; set; }
        [Display(Name = "Rating")]
        public int rating { get; set; }
        [Display(Name = "Third Party")]
        public bool thirdParty { get; set; }
        [Display(Name = "Nose")]
        public string nose { get; set; }
        [Display(Name = "Palate")]
        public string palate { get; set; }
        [Display(Name = "Finish")]
        public string finish { get; set; }
        [Display(Name = "Comment")]
        public string comment { get; set; }
        [Display(Name = "Personal")]
        public bool personal { get; set; }
        [Display(Name = "Date")]
        public string dateAddedPretty { get; set; }
        [Display(Name = "Dram")]
        public string dramName { get; set; }
        public string scotchId { get; set; }
    }
}
