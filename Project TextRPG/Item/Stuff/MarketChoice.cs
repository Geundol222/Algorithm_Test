using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class MarketChoice
    {
        public Point choicePoint;
        public int choiceIndex = 0;
        public char icon = '▶';

        public void Search(Direction dir)
        {
            Point prevPoint = choicePoint;
            int prevIndex = choiceIndex;

            switch (dir)
            {
                case Direction.Up:
                    choicePoint.y--;
                    choiceIndex--;
                    Data.inventory.itemIndex--;
                    break;
                case Direction.Down:
                    choicePoint.y++;
                    choiceIndex++;
                    Data.inventory.itemIndex++;
                    break;

            }

            if (Data.inventory.itemIndex < 0)
            {
                Data.inventory.itemIndex = 0;
            }

            if (Data.inventory.itemIndex >= Data.inven.Count)
            {
                Data.inventory.itemIndex = Data.inven.Count;
            }

            if (choiceIndex >= Data.inven.Count || choiceIndex < 0)
            {
                choiceIndex = prevIndex;
                choicePoint = prevPoint;
            }
        }
    }
}
