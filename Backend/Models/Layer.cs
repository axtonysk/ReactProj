using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutWebAPi.Models
{
    public class Layer
    {
        [Key]
        public int id { get; set; }
        public int layer_level_no { get; set; }
        public bool is_active { get; set; } = true;
        public bool is_available { get; set; } = true;

        public int layout_object_id { get; set; }
        public LayoutObject layout_object { get; set; }
    }
}
