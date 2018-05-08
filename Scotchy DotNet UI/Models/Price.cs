using System;
using System.ComponentModel.DataAnnotations;

namespace Price.Model
{
    public class PriceDTO
    {
        public string _id { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateAdded { get; set; }
        [Display(Name = "Location")]
        public string location { get; set; }
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public float price { get; set; }
        [Display(Name = "Tax")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public float tax { get; set; }
        [Display(Name = "Shipping")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public float shipping { get; set; }
        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public float total { get; set; }
        [Display(Name = "Comment")]
        public string comment { get; set; }
        [Display(Name = "Size")]
        public string size { get; set; }
        [Display(Name = "Dram")]
        public string dramName { get; set; }
        public string scotchId { get; set; }
    }
}
