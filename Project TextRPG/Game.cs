using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project_TextRPG
{
    public class Game
    {
        private bool isRunning = true;

        public Scene                   currentScene { get;  set; }
        public Dictionary<string, Scene> sceneDic { get; set; }
        BattleScene battleScene;

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
            sceneDic.Add("인벤토리", new InventoryScene(this));
            sceneDic.Add("여관", new TavernScene(this));
            sceneDic.Add("마을 밖", new MapScene(this));
            battleScene = new BattleScene(this);

            currentScene = sceneDic["메인메뉴"];
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

        public void Battle(Monster monster)
        {
            currentScene = battleScene;
            battleScene.StartBattle(monster);
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
