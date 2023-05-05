using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class TownScene : Scene
    {
        public TownScene(Game game) : base(game) { }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("당신은 마을에 있습니다. 행동을 선택해 주세요");

            char[] charArr = sb.ToString().ToCharArray();

            for (int i = 0; i < charArr.Length; i++)
            {
                Console.Write(charArr[i]);
                Thread.Sleep(10);
            }

            Console.WriteLine();
            Console.WriteLine("1. 상점가로 간다.");
            Console.WriteLine("2. 마을을 돌아본다.(랜덤 이벤트)");
            Console.WriteLine("3. 마을 밖으로 나간다(몬스터 출현)");
            Console.WriteLine("4. 여관에서 쉰다(체력회복)");
            Console.WriteLine("5. 인벤토리를 확인한다.");
            Console.WriteLine("6. 스탯을 확인한다.");
        }

        public override void Update()
        {
            string input = Console.ReadLine();

            int command;
            if (!int.TryParse(input, out command))
            {
                Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요");
                Thread.Sleep(1000);
                return;
            }

            switch (command)
            {
                case 1:
                    break;
                case 2:
                    game.TownEvent();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    game.PlayerStat();
                    break;
            }
        }
    }
}
