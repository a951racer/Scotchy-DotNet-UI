using System;

namespace Price.Model
{
    public class PriceDTO
    {
        public string _id { get; set; }
        public DateTime dateAdded { get; set; }
        public string location { get; set; }
        public float price { get; set; }
        public float tax { get; set; }
        public float shipping { get; set; }
        public float total { get; set; }
        public string comment { get; set; }
        public string size { get; set; }
    }
}
