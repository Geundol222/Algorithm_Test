using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

            // 콘솔 글꼴 바꿔야 정상적으로 출력됨
            sb.AppendLine(@"                                                           |>>>          ");
            sb.AppendLine(@"                   _                      _                |             ");
            sb.AppendLine(@"    ____________ .' '.    _____/----/-\ .' './========\   / \            ");
            sb.AppendLine(@"   //// ////// /V_.-._\  |.-.-.|===| _ |-----| u    u |  /___\           ");
            sb.AppendLine(@"  // /// // ///==\ u |.  || | ||===||||| |T| |   ||   | .| u |_ _ _ _ _ _");
            sb.AppendLine(@" ///////-\////====\==|:::::::::::::::::::::::::::::::::::|u u| U U U U U ");
            sb.AppendLine(@" |----/\u |--|++++|..|'''''''''''::::::::::::::''''''''''|+++|+-+-+-+-+-+");
            sb.AppendLine(@" |u u|u | |u ||||||..|              '::::::::'           |===|>=== _ _ ==");
            sb.AppendLine(@" |===|  |u|==|++++|==|              .::::::::.           | T |....| V |..");
            sb.AppendLine(@" |u u|u | |u ||HH||         \|/    .::::::::::.                          ");
            sb.AppendLine(@" |===|_.|u|_.|+HH+|               .::::::::::::.                         ");
            sb.AppendLine();
            sb.AppendLine("당신은 마을에 있습니다. 행동을 선택해 주세요");
            sb.AppendLine();
            sb.AppendLine("============================================");
            if (Data.player.PlayerClassUp())
            {
                sb.AppendLine();
                sb.AppendLine("0. 진급을 하러 간다.");
            }
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
            sb.AppendLine();
            sb.AppendLine("7. 게임 종료");
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

            if (command == 0 && Data.player.level >= 10)
            {
                game.currentScene = game.sceneDic["전직"];
            }                
            else if (command < 1 || command > 7)
            {
                Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요");
                Thread.Sleep(1000);
                return;
            }

            switch (command)
            {
                case 1:
                    game.currentScene = game.sceneDic["상점"];
                    break;
                case 2:
                    TownEvent();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("당신은 마을 밖으로 나갑니다. (마을 밖은 몬스터가 출몰 합니다.)");
                    Thread.Sleep(1000);
                    LoadMap();
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
                case 7:
                    game.EndGame();
                    break;
            }

            
        }

        private void PlayerStat()
        {
            StringBuilder sb = new StringBuilder();

            Console.Clear();
            sb.AppendLine("당신의 스탯은 다음과 같습니다.");
            sb.AppendLine();
            sb.AppendLine($"{Data.player.name} : {Data.player.className}");
            sb.AppendLine("==============================");
            sb.AppendLine($"LEVEL  : {Data.player.level}");
            sb.AppendLine($"HP     : {Data.player.curHp} / {Data.player.maxHp}");
            sb.AppendLine($"MP     : {Data.player.curMp} / {Data.player.maxMp}");
            sb.AppendLine($"AP     : {Data.player.ap}");
            sb.AppendLine($"DP     : {Data.player.dp}");
            sb.AppendLine($"SPEED  : {Data.player.speed}");
            sb.AppendLine($"EXP    : {Data.player.exp}");
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
                    Data.player.GetGold(10);
                    Console.WriteLine($"보유 골드 : {Data.player.gold}");
                    Thread.Sleep(2000);
                    break;
                case 1:
                    Console.WriteLine("당신은 불량배와 시비가 붙어 한 대 맞았습니다. 체력이 5 감소합니다.");
                    Data.player.curHp -= 5;
                    Console.WriteLine($"현재 체력 : {Data.player.curHp} / {Data.player.maxHp}");
                    if (Data.player.curHp < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("당신은 결국 쓰러져 버렸습니다.");
                        Thread.Sleep(1000);
                        Data.player.PlayerDead();
                    }
                    Thread.Sleep(2000);
                    break;
                case 2:
                    Console.WriteLine("길을 걷던 당신은 반짝거리는 무언가를 발견했습니다.");
                    Thread.Sleep(1000);
                    Console.WriteLine();
                    Data.AddItem();
                    Data.ItemChecker();
                    Thread.Sleep(2000);
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

        private void LoadMap()
        {
            Console.CursorVisible = false;

            if (Data.enterOnce)
            {
                game.currentScene = game.sceneDic["마을 밖"];
            }
            else
            {
                Data.LoadLevel();
                game.currentScene = game.sceneDic["마을 밖"];
                Data.enterOnce = true;
            }
        }
    }
}
