using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class CreatePlayerScene : Scene
    {
        Random rand = new Random();
        public Player player = new Player();
        Queue<string> strQueue = new Queue<string>();

        public CreatePlayerScene(Game game) : base(game) 
        { 
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();            

            sb.AppendLine("  ####   ######    ######    ###     ######   ######           ######    ##        ###     ##  ##   ######  ######   ");
            sb.AppendLine(" ##  ##  ##   ##   ##       ## ##    # ## #   ##               ##   ##   ##       ## ##    ##  ##   ##      ##   ##  ");
            sb.AppendLine("##       ##   ##   ##      ##   ##     ##     ##               ##   ##   ##      ##   ##    #  #    ##      ##   ##  ");
            sb.AppendLine("##       ##  ###   #####   ##   ##     ##     #####            ##   ##   ##      ##   ##    ####    #####   ##  ###  ");
            sb.AppendLine("##       #####     ##      #######     ##     ##               ######    ##      #######     ##     ##      #####    ");
            sb.AppendLine(" ##  ##  ## ###    ##      ##   ##     ##     ##               ##        ##   #  ##   ##     ##     ##      ## ###   ");
            sb.AppendLine("  ####   ##  ###   ######  ##   ##     ##     ######           ##        ######  ##   ##     ##     ######  ##  ###  ");
            sb.AppendLine();

            Console.WriteLine(sb.ToString());

            CreateMent();

            while (strQueue.Count > 0)
            {
                Console.WriteLine(strQueue.Dequeue());
                Console.WriteLine();
                Thread.Sleep(2000);
            }
            Console.WriteLine("당신의 이름을 알려주세요 (닉네임을 제외한 나머지 능력치는 랜덤으로 설정됩니다.)");
            Console.Write("내 이름은... : ");
        }

        public void CreateComplete()
        {
            StringBuilder sb = new StringBuilder();
            int count = 4;

            Console.Clear();
            Console.WriteLine("캐릭터를 생성중입니다.");
            while (count > 0)
            {
                Console.WriteLine(".");
                Thread.Sleep(1500);
                count--;
            }
            Console.Clear();
            Console.WriteLine("캐릭터 생성이 완료되었습니다!");
            Thread.Sleep(1000);
            Console.Clear();
            sb.AppendLine($"당신{player.name}의 스탯은 다음과 같습니다.");
            sb.AppendLine($"레벨        : {player.level}");
            sb.AppendLine($"체력        : {player.hp}");
            sb.AppendLine($"마력        : {player.mp}");
            sb.AppendLine($"공격력      : {player.ap}");
            sb.AppendLine($"방어력      : {player.dp}");
            sb.AppendLine($"보유 골드   : {player.gold}");
            sb.AppendLine($"경험치      : {player.exp}");
            sb.AppendLine();
            sb.AppendLine("능력치와 이름을 확정하시겠습니까?");
            sb.AppendLine("1. 예");
            sb.AppendLine("2. 아니오");

            Console.WriteLine(sb.ToString());
        }

        private void CreateMent()
        {
            strQueue.Enqueue("                                         캐릭터 생성을 시작합니다.                                                ");
            strQueue.Enqueue("                            캐릭터 생성은 한 번만 진행되며 확정되면 바꿀 수 없습니다.                             ");
            strQueue.Enqueue("                                       신중하게 결정해 주시기 바랍니다.                                           ");
        }

        public override void Update()
        {
            string name = Console.ReadLine();

            player.name = name;
            player.exp = 0;
            player.hp = rand.Next(50, 100);
            player.mp = rand.Next(20, 50);
            player.ap = rand.Next(5, 10);
            player.dp = rand.Next(1, 5);
            player.gold = 0;
            player.level = 1;

            CreateComplete();

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
                    return;
            }
        }
    }
}
