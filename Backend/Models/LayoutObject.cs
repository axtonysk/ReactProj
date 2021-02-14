using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutWebAPi.Models
{
    public class LayoutObject
    {
        [Key]
        public int id { get; set; }
        public string type { get; set; }
        public bool is_active { get; set; } = true;
        public bool is_rack { get; set; }

        public int module_id { get; set; }
        public Module module { get; set; }

        public Properties properties { get; set; }

        public List<Layer> layers { get; set; }
    }
}
