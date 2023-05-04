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

            Console.Clear();
            Console.WriteLine("캐릭터 생성이 완료되었습니다!");
            Thread.Sleep(1000);
            Console.Clear();
            sb.AppendLine("캐릭터 생성이 완료되었습니다!")
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
        }
    }
}
