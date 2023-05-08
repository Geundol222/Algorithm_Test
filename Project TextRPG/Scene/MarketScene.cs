﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class MarketScene : Scene
    {
        public MarketScene(Game game) : base(game) { }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder inventory = new StringBuilder();

            inventory.AppendLine(@"       _                   ");
            inventory.AppendLine(@"     _|=|__________        ");
            inventory.AppendLine(@"    /              \       ");
            inventory.AppendLine(@"   /      SHOP      \      ");
            inventory.AppendLine(@"  /__________________\     ");
            inventory.AppendLine(@"   ||  || /--\ ||  ||      ");
            inventory.AppendLine(@"   ||[]|| | .| ||[]||      ");
            inventory.AppendLine(@" ()||__||_|__|_||__||()    ");
            inventory.AppendLine(@"( )|-|-|-|====|-|-|-|( )   ");
            inventory.AppendLine(@"^^^^^^^^^^====^^^^^^^^^^^  ");

            sb.AppendLine("당신은 상점으로 들어갑니다.");
            sb.AppendLine();
            sb.AppendLine("상점주인 : 어서옵쇼~! 물건 보시려고? 좋은거 많아요!");
            sb.AppendLine();

            Console.WriteLine(inventory.ToString());

            char[] charArr = sb.ToString().ToCharArray();

            for (int i = 0; i < charArr.Length; i++)
            {
                Console.Write(charArr[i]);
                Thread.Sleep(30);
            }

            Console.WriteLine("상점에서 무엇을 하시겠습니까?");
            Console.WriteLine("1. 구입한다.");
            Console.WriteLine("2. 판매한다.");
            Console.WriteLine("3. 아무것도 안한다.");
        }

        public override void Update()
        {
            StringBuilder sb = new StringBuilder();

            string input = Console.ReadLine();

            int command;
            if (!int.TryParse(input, out command))
            {
                Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요");
                Thread.Sleep(1000);
                return;
            }

            if (command < 1 || command > 3)
            {
                Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요");
                Thread.Sleep(1000);
                return;
            }

            switch (command)
            {
                case 1:
                    sb.AppendLine();
                    sb.AppendLine("당신 : 물건좀 보려구요");
                    sb.AppendLine();
                    sb.AppendLine("상점주인 : 예~ 감사합니다. 천천히 보세요~");
                    sb.AppendLine();
                    break;
                case 2:
                    sb.AppendLine();
                    sb.AppendLine("당신 : 물건 좀 팔고 싶은데요");
                    sb.AppendLine();
                    sb.AppendLine("상점주인 : 예~ 어떤 물건인지요~?");
                    break;
                case 3:
                    sb.AppendLine();
                    sb.AppendLine("당신 : 다음에 오겠습니다.");
                    sb.AppendLine();
                    sb.AppendLine("상점주인 : 예~ 감사합니다. 다음에 또 오세요~");
                    sb.AppendLine();
                    break;
            }

            char[] charArr = sb.ToString().ToCharArray();

            for (int i = 0; i < charArr.Length; i++)
            {
                Console.Write(charArr[i]);
                Thread.Sleep(30);
            }

            if (command == 1)
            {
                Thread.Sleep(500);
                BuyItem();
            }

            if (command == 2)
            {
                Thread.Sleep(500);
                SellItem();
            }
                
        }

        public void BuyItem()
        {
            Console.CursorVisible = false;
            game.currentScene = game.sceneDic["구매"];
        }

        public void SellItem()
        {
            Console.CursorVisible = false;
            Data.InventoryMap();
            Data.inventory.itemIndex = 0;
            game.currentScene = game.sceneDic["판매"];
        }
    }
}
