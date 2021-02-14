using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutWebAPi.Models
{
    public class Warehouse
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string display_value { get; set; }
        public bool is_active { get; set; } = true;
        public bool is_available { get; set; } = true;

        public List<Module> modules { get; set; }
    }
}
