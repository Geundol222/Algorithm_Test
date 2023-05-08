using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Inventory
    {
        public char icon = '▣';
        public Point point;
        public int itemIndex = 0;

        public void Search(Direction dir)
        {
            Point prevPoint = point;
            int prevIndex = itemIndex;

            switch (dir)
            {
                case Direction.Up:
                    point.y--;
                    itemIndex -= 5;
                    break;
                case Direction.Down:
                    point.y++;
                    itemIndex += 5;
                    break;
                case Direction.Left:
                    point.x--;
                    itemIndex--;
                    break;
                case Direction.Right:
                    point.x++;
                    itemIndex++;
                    break;

            }

            if (itemIndex < 0)
                itemIndex = 0;
            else if (itemIndex > 24)
                itemIndex = 24;
            else if (itemIndex > itemIndex + 5)
                Data.inventory.point.y++;

            if (Data.inventory.point.x < 0 || Data.inventory.point.x >= Data.inventoryMap.GetLength(1) ||
                Data.inventory.point.y < 0 || Data.inventory.point.y >= Data.inventoryMap.GetLength(0) ||
                itemIndex >= Data.inven.Count)
            {
                itemIndex = prevIndex;
                point = prevPoint;
            }
        }
    }
}
