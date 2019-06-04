using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightControl.Model
{
    public class tree
    {
        public int id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public IEnumerable<tree> children { get; set; } 
        public string alias { get; set; }
        public string icon { get; set; }
        public string href { get; set; }
        public bool spread { get; set; }
    }
}
