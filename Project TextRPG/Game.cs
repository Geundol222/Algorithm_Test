using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Game
    {
        private bool isRunning = true;

        public Scene                   currentScene { get;  set; }
        public Dictionary<string, Scene> sceneDic { get; set; }

        public void Run()
        {
            Init();

            while (isRunning)
            {
                Render();

                Update();
            }

            Release();
        }

        public void Init()
        {
            Data.Init();

            sceneDic = new Dictionary<string, Scene>();

            sceneDic.Add("메인메뉴", new MainMenuScene(this));
            sceneDic.Add("캐릭터 생성", new CreatePlayerScene(this));
            sceneDic.Add("스토리", new GameStoryScene(this));
            sceneDic.Add("마을", new TownScene(this));

            currentScene = sceneDic["메인메뉴"];
        }

        public void PlayerStat()
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
            sb.AppendLine($"GOLD : {Data.player.gold}");
            sb.AppendLine($"EXP  : {Data.player.exp}");
            sb.AppendLine("==============================");

            Console.WriteLine(sb.ToString());

            Console.Write("돌아가려면 아무키나 누르십시오.");
            Console.ReadKey();
        }

        public void TownEvent()
        {
            Random rand = new Random();

            Console.Clear();

            switch (rand.Next(0,4))
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

        public void EndGame()
        {
            Console.CursorVisible = false;
            Console.Clear();
            isRunning = false;
        }

        public void Render()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            currentScene.Render();
        }

        public void Update()
        {
            currentScene.Update();
        }

        public void Release()
        {
            Data.Release();
        }
    }
}
