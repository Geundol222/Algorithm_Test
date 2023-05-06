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
            sb.AppendLine();
            sb.AppendLine("============================================");
            sb.AppendLine("1. 상점가로 간다.");
            sb.AppendLine();
            sb.AppendLine("2. 마을을 돌아본다.(랜덤 이벤트)");
            sb.AppendLine();
            sb.AppendLine("3. 마을 밖으로 나간다(몬스터 출현)");
            sb.AppendLine();
            sb.AppendLine("4. 여관에서 쉰다(체력회복)");
            sb.AppendLine();
            sb.AppendLine("5. 인벤토리를 확인한다.");
            sb.AppendLine();
            sb.AppendLine("6. 스탯을 확인한다.");
            sb.AppendLine("============================================");

            Console.WriteLine(sb.ToString());
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
                    TownEvent();
                    break;
                case 3:
                    break;
                case 4:
                    game.currentScene = game.sceneDic["여관"];
                    break;
                case 5:
                    LoadInventory();
                    break;
                case 6:
                    PlayerStat();
                    break;
            }
        }

        private void PlayerStat()
        {
            StringBuilder sb = new StringBuilder();

            Console.Clear();
            sb.AppendLine($"당신({Data.player.name})의 스탯은 다음과 같습니다.");
            sb.AppendLine();
            sb.AppendLine("==============================");
            sb.AppendLine($"HP   : {Data.player.curHp} / {Data.player.maxHp}");
            sb.AppendLine($"MP   : {Data.player.curMp} / {Data.player.maxMp}");
            sb.AppendLine($"AP   : {Data.player.ap}");
            sb.AppendLine($"DP   : {Data.player.dp}");
            sb.AppendLine($"EXP  : {Data.player.exp}");
            sb.AppendLine("==============================");

            Console.WriteLine(sb.ToString());

            Console.Write("돌아가려면 아무키나 누르십시오.");
            Console.ReadKey();
        }

        private void TownEvent()
        {
            Random rand = new Random();

            Console.Clear();

            switch (rand.Next(0, 4))
            {
                case 0:
                    Console.WriteLine("Lucky! 당신은 길에서 10원짜리 동전을 주웠습니다.");
                    Data.player.gold += 10;
                    Console.WriteLine($"보유 골드 : {Data.player.gold}");
                    Thread.Sleep(2000);
                    break;
                case 1:
                    Console.WriteLine("당신은 불량배와 시비가 붙어 한 대 맞았습니다. 체력이 5 감소합니다.");
                    Data.player.curHp -= 5;
                    Console.WriteLine($"현재 체력 : {Data.player.curHp} / {Data.player.maxHp}");
                    Thread.Sleep(2000);
                    break;
                case 2:
                    // TODO : 아이템 줍기 구현
                    break;
                case 3:
                    Console.WriteLine("하루종일 마을을 돌아다녔지만 아무일도 일어나지 않았습니다.");
                    Thread.Sleep(2000);
                    break;
            }
        }

        private void LoadInventory()
        {
            Console.CursorVisible = false;
            Data.InventoryMap();
            game.currentScene = game.sceneDic["인벤토리"];
        }
    }
}
