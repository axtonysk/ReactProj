using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutWebAPi.Models
{
    public class Module
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string layout_name { get; set; }
        public float width { get; set; }
        public float length { get; set; }
        public bool is_active { get; set; } = true;
        public bool is_available { get; set; } = true;

        public int warehouse_id { get; set; }
        public Warehouse warehouse { get; set; }

        public List<LayoutObject> layout_objects { get; set; }
    }
}
