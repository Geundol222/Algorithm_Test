using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Item
    {
        public string name { get; set; }
        public string description { get; set; }

        public virtual bool Use() { return true; }
    }
}
