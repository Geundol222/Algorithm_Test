using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class BattleScene : Scene
    {
        private Monster monster;

        public BattleScene(Game game) : base(game) { }

        public override void Render()
        {
            Console.WriteLine();
            Console.WriteLine($"{monster.name}    {monster.curHp,3} / {monster.maxHp,3}");
            Console.WriteLine($"공격력 : {monster.ap}, 방어력 : {monster.dp}");
            Console.WriteLine(monster.image);
            Console.WriteLine();
            Console.WriteLine($"플레이어    {Data.player.curHp,3} / {Data.player.maxHp}");
            Console.WriteLine($"공격력 : {Data.player.ap}, 방어력 : {Data.player.dp}");

            Console.WriteLine();
        }

        public override void Update()
        {
            Random rand = new Random();

            Console.WriteLine("행동을 선택하세요");
            Console.WriteLine("1. 공격한다.");
            Console.WriteLine("2. 방어한다.");
            Console.WriteLine("3. 도망간다.");

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
                    AttackPriority();
                    break;
                case 2:
                    Data.player.Deffence(monster);
                    break;
                case 3:
                    RunBattle();
                    break;
            }
        }

        public void AttackPriority()
        {
            if (Data.player.speed > monster.speed)
            {
                Data.player.Attack(monster);
                if (monster.curHp < 0)
                {
                    monster.MonsterDead();
                    game.currentScene = game.sceneDic["마을 밖"];
                }                    
                else
                    monster.Attack(Data.player);
            }
            else
            {
                monster.Attack(Data.player);
                if (Data.player.curHp < 0)
                {
                    Console.Clear();
                    Console.WriteLine("당신은 더 이상 싸울 힘이 없습니다.");
                    Thread.Sleep(1000);
                    Console.WriteLine("당신은 결국 쓰러져 버렸습니다.");
                    Thread.Sleep(1000);
                    Data.player.PlayerDead();
                    game.currentScene = game.sceneDic["마을"];
                }
                else
                    Data.player.Attack(monster);
            }
        }

        public void RunBattle()
        {
            Random rand = new Random();

            int run = rand.Next(1, 11);

            if (run < Data.player.speed)
            {
                Console.WriteLine("도망칠 수 없었습니다!!");
                Thread.Sleep(1000);
                monster.Attack(Data.player);
            }
            else
            {
                Console.WriteLine("무사히 도망쳤습니다.");
                Thread.Sleep(1000);
                game.currentScene = game.sceneDic["마을"];
            }
        }

        public void StartBattle(Monster monster)
        {
            this.monster = monster;
            Data.monsters.Remove(monster);

            int count = 6;

            while (count > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{monster.name}이(가) 등장했다!");
                Thread.Sleep(20);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{monster.name}이(가) 등장했다!");
                Thread.Sleep(20);

                count--;
            }
            
        }
    }
}
