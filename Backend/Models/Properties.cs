using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutWebAPi.Models
{
    public class Properties
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        public float x_axis { get; set; }
        public float y_axis { get; set; }
        public float max_width { get; set; }
        public float max_height { get; set; }
        public float min_width { get; set; }
        public float min_height { get; set; }

        public int layout_object_id { get; set; }
        public LayoutObject layout_object { get; set; }
    }
}
