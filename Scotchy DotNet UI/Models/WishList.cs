using System;
using System.ComponentModel.DataAnnotations;
using User.Model;
//using Scotch.Model;

namespace WishList.Model
{
    public class WishListDTO
    {
        public string _id { get; set; }
        [Display(Name = "Name")]
        public string wishListName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateAdded { get; set; }
        [Display(Name = "Created By")]
        public CreatorDTO creator { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        //public ScotchDTO[] scotches { get; set; }
    }
}
