using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColumnProps.Model
{
    public class ColumnPropsDTO
    {
        public string fieldName { get; set; }
        public string header { get; set; }
        public bool sortable { get; set; }
        public bool filterable { get; set; }
        public string dataType { get; set; }
        public string styleClass { get; set; }
    }
}
