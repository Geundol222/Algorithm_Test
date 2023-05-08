using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Item : IUsable, IEquipable
    {
        public string image;
        public ItemType type;
        public int price { get; protected set; }
        public string name { get; protected set; }
        public string description { get; protected set; }

        public virtual bool Use() { return true; }

        public virtual void Equip() { }
    }
}
