using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Player
    {
        Random rand = new Random();

        public char icon = '★';
        public string image;
        public string description;
        public Point point;

        public string name { get; set; }
        public string className { get; protected set; }
        public int curHp { get; set; }
        public int maxHp { get; protected set; }
        public int curMp { get; set; }
        public int maxMp { get; protected set; }
        public int speed { get; protected set; }
        public int level { get; protected set; }
        public int gold { get; protected set; }
        public int ap { get; protected set; }
        public int dp { get; protected set; }
        public float exp { get; set; }
        public int deathCount { get; protected set; }

        public Player()
        {
            className = "초보자";
            level = 10;
            exp = 0;
            maxHp = rand.Next(50, 100);
            maxMp = rand.Next(20, 50);
            curHp = maxHp;
            curMp = maxMp;
            speed = rand.Next(1, 11);
            ap = rand.Next(5, 10);
            dp = rand.Next(1, 5);
            gold = 100;
            deathCount = 0;
        }

        public void GetGold(int gold) { this.gold += gold; }

        public void LooseGold(int gold) { this.gold -= gold; }

        public void GetAp(int ap) { this.ap += ap; }

        public void LooseAp(int ap) { this.ap -= ap; }

        public void GetDp(int dp) { this.dp += dp; }

        public void LooseDp(int dp) { this.dp -= dp; }

        public void Move(Direction dir)
        {
            Point prevPos = point;

            switch (dir)
            {
                case Direction.Up:
                    point.y--;
                    break;
                case Direction.Down:
                    point.y++;
                    break;
                case Direction.Left:
                    point.x--;
                    break;
                case Direction.Right:
                    point.x++;
                    break;
            }
            if (!Data.map[point.y, point.x])
            {
                point = prevPos;
            }
        }

        public void GetItem(Item item)
        {
            Data.inven.Add(item);
        }

        public void Equip(Item item)
        {
            item.Equip();
        }

        public void UseItem(Item item)
        {
            if (item.Use())
            {
                Data.itemCount[Data.inventory.itemIndex]--;
                if (Data.itemCount[Data.inventory.itemIndex] < 1)
                {
                    Data.inven.Remove(item);
                    Data.itemCount.Remove(Data.inventory.itemIndex);
                    Data.inventory.itemIndex = 0;
                    Data.inventory.point.x = 0;
                    Data.inventory.point.y = 0;
                }
            }
            else
            {
                return;
            }
        }

        public void Attack(Monster monster)
        {
            Console.WriteLine($"{name}이(가) {monster.name}을 공격합니다!");
            Thread.Sleep(1000);
            monster.TakeDamage(ap);
        }

        public void Deffence(Monster monster)
        {
            Console.WriteLine("당신은 방어태세를 취했습니다.");
            Thread.Sleep(1000);
            dp += 3;
            Console.WriteLine("방어력이 약간 증가했습니다.");
            Thread.Sleep(1000);

            monster.Attack(this);

            dp -= 3;
        }

        public void TakeDamage(int damage, Monster monster)
        {
            Console.WriteLine($"{name}은 {monster.name}에게 공격 받았습니다.");
            Thread.Sleep(1000);

            if (damage > dp)
            {
                curHp -= damage - dp;
                Console.WriteLine($"{name}은 {damage - dp}의 데미지를 받았습니다.");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine($"{name}이 너무 단단합니다!! 데미지를 입지 않았습니다.");
                Thread.Sleep(1000);
            }

            if (curHp < 0)
            {
                Console.WriteLine($"{name}이 쓰러졌다!");
                deathCount++;
                Thread.Sleep(1000);
            }
        }

        public void PlayerDead()
        {
            StringBuilder sb = new StringBuilder();

            Console.Clear();
            Console.WriteLine("당신은 더 이상 싸울 힘이 없습니다.");
            Thread.Sleep(1000);
            Console.WriteLine("당신은 결국 쓰러져 버렸습니다.");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("잠시후...");
            Thread.Sleep(1000);
            Console.Clear();

            Data.player.curHp = Data.player.maxHp;
            sb.AppendLine("여관 주인 : 괜찮아요?");
            sb.AppendLine();
            sb.AppendLine("당신 : 여기가 어디지..");
            sb.AppendLine();
            sb.AppendLine("여관 주인 : 마을 밖에 쓰러져있는걸 내가 데려 왔어요.");
            sb.AppendLine();
            sb.AppendLine("당신 : ...");
            sb.AppendLine();
            if (Data.player.deathCount == 1)
            {
                sb.AppendLine("여관 주인 : 이번엔 처음이니까 그냥 구해줬지만 다음에는 여관 사용료를 내야해요");
                sb.AppendLine("안그래도 작은 여관에 매번 쓰러질때 마다 무료로 구해줄 수는 없으니까요");
                sb.AppendLine();
                sb.AppendLine("당신 : ... 네 감사합니다.");
                sb.AppendLine();

                char[] charArr = sb.ToString().ToCharArray();

                for (int i = 0; i < charArr.Length; i++)
                {
                    Console.Write(charArr[i]);
                    Thread.Sleep(30);
                }
                Thread.Sleep(1000);
                Console.WriteLine("처음으로 쓰러졌을 때는 여관 사용료를 내지 않아도 됩니다.");
                Thread.Sleep(1000);
                Console.WriteLine("당신은 다시 마을로 돌아갑니다.");
                Thread.Sleep(2000);
            }
            else
            {
                sb.AppendLine("여관 주인 : 또 쓰러져버렸네요 이번에는 여관사용료를 내줘야겠어요");
                sb.AppendLine("그래도 안쓰러우니 대신 원래 사용료 보단 할인해드릴게요");
                sb.AppendLine();
                sb.AppendLine("당신 : ... 네 감사합니다.");
                sb.AppendLine();

                char[] charArr = sb.ToString().ToCharArray();

                for (int i = 0; i < charArr.Length; i++)
                {
                    Console.Write(charArr[i]);
                    Thread.Sleep(30);
                }
                Thread.Sleep(1000);
                Console.WriteLine("처음이 아니면 여관 사용료를 내야 합니다.");
                Thread.Sleep(1000);
                Data.player.gold -= 20;
                Console.WriteLine($"당신은 여관 사용료 20골드를 낸 후 다시 마을로 돌아갑니다.");
                Thread.Sleep(2000);
            }

        }

        public void PlayerLevelUp()
        {
            Console.Clear();
            if (exp >= 100)
            {
                Console.Clear();
                Console.WriteLine("축하합니다! 레벨업 하였습니다!");
                Thread.Sleep(1000);
                level++;
                Console.WriteLine($"현재 레벨 : {level}");
                Thread.Sleep(1000);
                Console.WriteLine("스탯 변화");
                Thread.Sleep(1000);
                Console.WriteLine("==============================");
                Console.WriteLine($"HP : {maxHp} + {level * 5}");
                maxHp += level * 5;
                Console.WriteLine($"MP : {maxMp} + {level * 2}");
                maxMp += level * 2;
                Console.WriteLine($"AP : {ap} + {level + 5}");
                ap += level + 5;
                Console.WriteLine($"DP : {dp} + {level + 1}");
                dp += level + 1;
                if (speed >= 10)
                    Console.WriteLine("스피드는 10이 Max입니다. 더이상 오르지 않습니다.");
                else
                {
                    Console.WriteLine($"Speed : {speed} + 1");
                    speed++;
                }                
                Console.WriteLine("==============================");
                exp = 0;

                Console.WriteLine();
                Console.WriteLine("계속하려면 아무키나 누르십시오.");
                Console.ReadKey();
            }
            else
                return;
        }

        public bool PlayerClassUp()
        {
            if (level >= 10 && className == "초보자")
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("축하합니다 진급 자격을 얻었습니다.");
                Thread.Sleep(1000);
                Console.WriteLine("이제 마을에 진급 선택지가 생겼습니다. 진급하려면 해당 선택지를 선택해주세요");
                Thread.Sleep(2000);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
