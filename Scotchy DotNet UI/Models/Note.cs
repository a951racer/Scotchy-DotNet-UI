using System;
using System.ComponentModel.DataAnnotations;

namespace Note.Model
{
    public class NoteDTO
    {
        public string _id { get; set; }
        [Display(Name = "Note")]
        public string note { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateAdded { get; set; }
        [Display(Name = "Dram")]
        public string dramName { get; set; }
    }
}
