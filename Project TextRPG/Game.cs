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

            currentScene = sceneDic["메인메뉴"];
        }

        public void PlayerStat()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"당신({Data.player.name})의 스탯은 다음과 같습니다.");
            sb.AppendLine();
            sb.AppendLine("==============================");
            sb.AppendLine($"HP   : {Data.player.hp}");
            sb.AppendLine($"MP   : {Data.player.mp}");
            sb.AppendLine($"AP   : {Data.player.ap}");
            sb.AppendLine($"DP   : {Data.player.dp}");
            sb.AppendLine($"GOLD : {Data.player.gold}");
            sb.AppendLine($"EXP  : {Data.player.exp}");
            sb.AppendLine("==============================");

            Console.WriteLine(sb.ToString());
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
