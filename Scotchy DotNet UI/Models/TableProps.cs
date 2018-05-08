using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColumnProps.Model;

namespace TableProps.Model
{
    public class TablePropsDTO
    {
        public int pageSize { get; set; }
        public bool detailsButton { get; set; }
        public bool editButton { get; set; }
        public bool deleteButton { get; set; }
        public bool newButton { get; set; }
        public bool filterButton { get; set; }
        public string showDetails { get; set; }
        public string newItem { get; set; }
        public string editItem { get; set; }
        public string deleteItem { get; set; }
        public IList<ColumnPropsDTO> columns { get; set; }
    }
}
