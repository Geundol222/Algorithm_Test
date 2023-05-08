using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class ClassUpScene : Scene
    {
        bool isChoice = false;
        bool isClassChoice = false;
        int classIndex = 0;

        public ClassUpScene(Game game) : base(game) { }

        public override void Render()
        {
            if (isClassChoice)
            {
                Console.Clear();
                Console.WriteLine($"{Data.classList[classIndex].className}를 고르셨습니다.");
                Thread.Sleep(1000);
                Console.WriteLine("해당 직업을 선택하시겠습니까? (직업은 바꿀 수 없습니다 신중하게 결정해 주십시오");
                Console.WriteLine("변경되는 스탯");
                Console.WriteLine("=======================================");
                Console.WriteLine($"HP       : {Data.player.maxHp} => {Data.classList[classIndex].maxHp}");
                Console.WriteLine($"MP       : {Data.player.maxMp} => {Data.classList[classIndex].maxMp}");
                Console.WriteLine($"AP       : {Data.player.ap} => {Data.classList[classIndex].ap}");
                Console.WriteLine($"DP       : {Data.player.dp} => {Data.classList[classIndex].dp}");
                Console.WriteLine($"SPEED    : {Data.player.speed} => {Data.classList[classIndex].speed}");
                Console.WriteLine("=======================================");
                Console.WriteLine();
                Console.WriteLine("1. 예");
                Console.WriteLine("2. 아니오");
            }
            else
            {
                if (!isChoice)
                {
                    StringBuilder sb = new StringBuilder();

                    GuildRender();

                    Console.Clear();

                    sb.AppendLine("길드장 : 어서 오게나! 진급을 하러 왔나? 음 레벨을 잘 올린거 같구만");
                    sb.AppendLine("여기 진급할 수 있는 직업들이 있으니 골라 보게!");
                    sb.AppendLine();
                    sb.AppendLine("당신은 진급을 할 수 있습니다. 직업을 고르시겠습니까?");

                    char[] charArr = sb.ToString().ToCharArray();

                    for (int i = 0; i < charArr.Length; i++)
                    {
                        Console.Write(charArr[i]);
                        Thread.Sleep(30);
                    }

                    Console.WriteLine("1. 예");
                    Console.WriteLine("2. 아니오");
                }
                else
                {
                    Console.Clear();                    
                    Console.WriteLine();
                    Console.WriteLine(Data.classList[classIndex].image);
                    Console.WriteLine($"{Data.classList[classIndex].description}");
                    Console.WriteLine("◀ Prev                                      Next ▶");
                    Console.WriteLine();
                    Console.WriteLine("방향키 오른쪽, 왼쪽 : 직업 선택");
                    Console.WriteLine("Q : 취소");
                    Console.WriteLine("Z : 확인");
                }
            }            
        }

        public override void Update()
        {
            if (isClassChoice)
            {
                string input = Console.ReadLine();

                int command;
                if (!int.TryParse(input, out command))
                {
                    Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요");
                    Thread.Sleep(1000);
                    return;
                }

                if (command < 1 || command > 2)
                {
                    Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요");
                    Thread.Sleep(1000);
                    return;
                }

                switch (command)
                {
                    case 1:
                        if (!Data.isTest)
                        {
                            ClassUpRender();
                            Console.Clear();
                            Console.WriteLine("축하합니다! 전직이 완료되었습니다!");
                            Thread.Sleep(1000);
                            Console.WriteLine($"당신의 직업은 {Data.classList[classIndex].className}입니다.");
                            Data.player = Data.classList[classIndex];
                            Thread.Sleep(2000);
                            isClassChoice = false;
                            isChoice = false;
                            game.currentScene = game.sceneDic["마을"];
                        }
                        else
                        {
                            ClassUpRender();
                            Console.Clear();
                            Console.WriteLine("전직 체험은 여기까지입니다. 실제 전직은 일어나지 않습니다.");
                            Thread.Sleep(2000);
                            isClassChoice = false;
                            isChoice = false;
                            Data.isTest = false;
                            game.currentScene = game.sceneDic["마을"];
                        }
                        return;
                    case 2:
                        isClassChoice = false;
                        game.currentScene = this;
                        break;
                }

                
            }
            else
            {
                if (!isChoice)
                {
                    StringBuilder sb = new StringBuilder();

                    string input = Console.ReadLine();

                    int command;
                    if (!int.TryParse(input, out command))
                    {
                        Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요");
                        Thread.Sleep(1000);
                        return;
                    }

                    if (command < 1 || command > 2)
                    {
                        Console.WriteLine("잘못 입력하셨습니다. 다시 입력해주세요");
                        Thread.Sleep(1000);
                        return;
                    }

                    switch (command)
                    {
                        case 1:
                            sb.AppendLine();
                            sb.AppendLine("당신 : 예 한번 보겠습니다.");
                            sb.AppendLine();
                            sb.AppendLine("길드장 : 좋아! 골라보게나!");
                            sb.AppendLine();
                            Thread.Sleep(1000);
                            isChoice = true;
                            break;
                        case 2:
                            sb.AppendLine();
                            sb.AppendLine("당신 : 아니오 다음에 오겠습니다");
                            sb.AppendLine();
                            sb.AppendLine("길드장 : 그래? 그럼 아쉽지만 다음에 보도록 하지");
                            sb.AppendLine();
                            sb.AppendLine("당신은 마을로 돌아갑니다");
                            Thread.Sleep(1000);
                            game.currentScene = game.sceneDic["마을"];
                            break;
                    }

                    char[] charArr = sb.ToString().ToCharArray();

                    for (int i = 0; i < charArr.Length; i++)
                    {
                        Console.Write(charArr[i]);
                        Thread.Sleep(30);
                    }
                }
                else
                {
                    ConsoleKeyInfo info = Console.ReadKey();

                    switch (info.Key)
                    {
                        case ConsoleKey.RightArrow:
                            if (classIndex >= Data.classList.Count - 1)
                                classIndex = Data.classList.Count - 1;
                            else
                                classIndex++;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (classIndex < 1)
                                classIndex = 0;
                            else
                                classIndex--;
                            break;
                        case ConsoleKey.Q:
                            classIndex = 0;
                            isChoice = false;
                            return;
                        case ConsoleKey.Z:
                            isClassChoice = true;
                            break;
                    }
                }
            }            
        }

        public void GuildRender()
        {
            StringBuilder guild = new StringBuilder();
            int count = 3;

            guild.AppendLine(@"                                               /\      /\");
            guild.AppendLine(@"                                               ||______||");
            guild.AppendLine(@"                                               || ^  ^ ||");
            guild.AppendLine(@"                                               \| |  | |/");
            guild.AppendLine(@"                                                |______| ");
            guild.AppendLine(@"              __                                |  __  | ");
            guild.AppendLine(@"             /  \       ________________________|_/  \_|__");
            guild.AppendLine(@"            / ^^ \     /=========================/ ^^ \===|");
            guild.AppendLine(@"           /  []  \   /=========================/  []  \==|");
            guild.AppendLine(@"          /________\ /=========================/________\=|");
            guild.AppendLine(@"       *  |        |/==========================|        |=|");
            guild.AppendLine(@"      *** | ^^  ^^ |---------------------------| ^^  ^^ |--");
            guild.AppendLine(@"     *****| []  [] |  GUILD    _____           | []  [] | |");
            guild.AppendLine(@"    *******        |          /_____\          |      * | |");
            guild.AppendLine(@"   *********^^  ^^ |  ^^  ^^  |  |  |  ^^  ^^  |     ***| |");
            guild.AppendLine(@"  ***********]  [] |  []  []  |  |  |  []  []  | ===***** |");
            guild.AppendLine(@" *************     |         @|__|__|@         |/ |*******|");
            guild.AppendLine(@"***************   ***********--=====--**********| *********");
            guild.AppendLine(@"***************___*********** |=====| **********|***********");
            guild.AppendLine(@" *************     ********* /=======\ ******** | *********");

            Console.WriteLine(guild.ToString());

            Console.Write("당신은 전직을 위해 길드로 갑니다");
            while (count > 0)
            {
                Console.Write(".");
                Thread.Sleep(1000);
                count--;
            }
        }

        public void ClassUpRender()
        {
            string image1;
            string image2;
            string image3;

            int count = 10;

            StringBuilder sb = new StringBuilder();

                                                                                                                                                                                        
                                                                                                                                                                                        
            sb.AppendLine("                        ██████                  "); 
            sb.AppendLine("                    ██████    ██                "); 
            sb.AppendLine("                  ██▒▒▒▒▒▒██    ██              "); 
            sb.AppendLine("                ██▒▒▒▒▒▒▒▒▒▒████████            "); 
            sb.AppendLine("                ██▒▒▒▒▒▒▒▒▒▒██    ▒▒██          "); 
            sb.AppendLine("          ██████  ▒▒▒▒▒▒▒▒▒▒▒▒▓▓██▒▒██          "); 
            sb.AppendLine("      ████    ██  ▒▒▒▒        ▒▒▒▒  ██          "); 
            sb.AppendLine("    ██▒▒██    ██  ▒▒      ████  ██  ██          "); 
            sb.AppendLine("  ▓▓▒▒▒▒▒▒▓▓    ▓▓▒▒      ████  ██  ██  ▓▓▓▓▓▓  "); 
            sb.AppendLine("██▒▒▒▒▒▒▒▒██    ██▒▒                ████▒▒▒▒▒▒██"); 
            sb.AppendLine("██▒▒▒▒▒▒██  ██    ██▒▒  ████████  ██  ██▒▒▒▒▒▒██"); 
            sb.AppendLine("██▒▒▒▒▒▒██  ██      ██          ██  ████▒▒▒▒▒▒██"); 
            sb.AppendLine("▒▒▓▓▓▓▓▓▒▒  ██▒▒      ▓▓▓▓▓▓▓▓▓▓      ▒▒▒▒▒▒▓▓▒▒"); 
            sb.AppendLine("      ████  ██▒▒▒▒▒▒          ██    ▒▒▒▒▒▒██    "); 
            sb.AppendLine("    ██▒▒▒▒████▒▒▒▒▒▒▒▒▒▒▒▒  ██  ██  ▒▒▒▒██      "); 
            sb.AppendLine("  ██▒▒▒▒▒▒▒▒████▒▒▒▒      ██      ██████        "); 
            sb.AppendLine("▓▓▒▒▒▒▒▒▒▒▒▒  ██▓▓▒▒        ▓▓    ▒▒▒▒▒▒        "); 
            sb.AppendLine("██▒▒▒▒██▒▒▒▒      ██▓▓      ▒▒██                "); 
            sb.AppendLine("  ████████▒▒    ██  ██▒▒▒▒▒▒▒▒██                "); 
            sb.AppendLine("          ██████    ██▒▒▒▒▒▒██████              "); 
            sb.AppendLine("          ▒▒▒▒▒▒  ▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓            "); 
            sb.AppendLine("                  ██████████████████            "); 
           
            image1 = sb.ToString();
            sb.Clear();

            sb.AppendLine("                   ▓▓▓▓▓▓                       ");
            sb.AppendLine("               ██▓▓██    ██                     ");
            sb.AppendLine("             ██▒▒▒▒▒▒██    ██                   ");
            sb.AppendLine("           ██▒▒▒▒▒▒▒▒▒▒██▓▓████                 ");
            sb.AppendLine("           ██▒▒▒▒▒▒▒▒▒▒██    ▒▒██               ");
            sb.AppendLine("         ██  ▒▒▒▒▒▒▒▒▒▒▒▒████▒▒██               ");
            sb.AppendLine("         ██  ▒▒▒▒        ▒▒▒▒  ██               ");
            sb.AppendLine("       ████  ▒▒      ▓▓▓▓  ██  ██               ");
            sb.AppendLine("     ██    ██▒▒      ████  ██  ██               ");
            sb.AppendLine("   ██      ██▒▒                ██               ");
            sb.AppendLine(" ▓▓          ██    ▓▓▓▓▓▓▓▓  ▓▓▒▒               ");
            sb.AppendLine(" ██      ▓▓    ██          ▓▓                   ");
            sb.AppendLine("   ██▒▒▒▒▒▒██    ████████████                   ");
            sb.AppendLine("   ██▒▒▒▒▒▒▒▒████        ██▒▒██                 ");
            sb.AppendLine("   ▒▒▓▓▒▒▒▒▓▓▒▒▒▒▓▓    ▓▓▒▒▒▒██                 ");
            sb.AppendLine("       ██▒▒▒▒▒▒▒▒██▒▒▓▓██████                   ");
            sb.AppendLine("         ██▒▒▒▒██▒▒██  ██                       ");
            sb.AppendLine("           ████    ██  ██                       ");
            sb.AppendLine("         ▓▓██      ██▓▓▒▒                       ");
            sb.AppendLine("       ██▒▒▒▒▒▒▒▒▒▒██                           ");
            sb.AppendLine("     ██▒▒▒▒▒▒▒▒▒▒██                             ");
            sb.AppendLine("     ██▒▒▒▒▒▒██████                             ");
            sb.AppendLine("     ▒▒██▒▒▒▒▒▒▒▒▒▒▓▓                           ");
            sb.AppendLine("         ████████████                           ");

            image2 = sb.ToString();
            sb.Clear();

            sb.AppendLine("                           ██████               ");
            sb.AppendLine("                       ██████    ██             ");
            sb.AppendLine("                     ██▒▒▒▒▒▒██    ██           ");
            sb.AppendLine("                   ██▒▒▒▒▒▒▒▒▒▒████████         ");
            sb.AppendLine("                   ██▒▒▒▒▒▒▒▒▒▒██    ▒▒██       ");
            sb.AppendLine("                 ██  ▒▒▒▒▒▒▒▒▒▒▒▒▓▓██▒▒██       ");
            sb.AppendLine("                 ██  ▒▒▒▒        ▒▒▒▒  ██       ");
            sb.AppendLine("             ██████  ▒▒      ████  ██  ██       ");
            sb.AppendLine("         ▓▓▓▓      ▓▓▒▒      ████  ██  ██       ");
            sb.AppendLine("       ██▒▒▒▒▒▒      ██                ██       ");
            sb.AppendLine("     ██▒▒▒▒▒▒▒▒    ██      ████████  ██         ");
            sb.AppendLine("     ██▒▒▒▒▒▒██████        ▒▒      ██████       ");
            sb.AppendLine("     ██▒▒▒▒▒▒██▒▒██          ▓▓▓▓▓▓▒▒▒▒▒▒▓▓     ");
            sb.AppendLine("       ██████▒▒██▒▒  ▓▓▒▒    ▒▒▒▒▒▒▒▒▒▒▒▒██     ");
            sb.AppendLine("     ██▒▒▒▒██████▒▒▒▒  ██▒▒  ▒▒▒▒▒▒▒▒▒▒▒▒██     ");
            sb.AppendLine("   ██▒▒▒▒▒▒▒▒██  ▒▒▒▒▒▒▒▒████████████████       ");
            sb.AppendLine(" ▓▓▒▒▒▒▒▒▒▒▒▒      ▒▒▒▒▒▒▒▒      ██▒▒▒▒▒▒       ");
            sb.AppendLine(" ██▒▒▒▒██▒▒▒▒      ██████      ▒▒▒▒██           ");
            sb.AppendLine("   ████████▒▒▒▒  ██      ██▒▒▒▒▒▒▒▒██           ");
            sb.AppendLine("           ██████        ██▒▒▒▒▒▒██████         ");
            sb.AppendLine("           ▒▒▒▒▒▒      ▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓       ");
            sb.AppendLine("                       ██████████████████       ");

            image3 = sb.ToString();

            while (count > 0)
            {
                Console.Clear();
                Console.WriteLine("전직 중...");
                Console.WriteLine(image1);
                Thread.Sleep(100);

                Console.Clear();
                Console.WriteLine("전직 중...");
                Console.WriteLine(image2);
                Thread.Sleep(100);

                Console.Clear();
                Console.WriteLine("전직 중...");
                Console.WriteLine(image3);
                Thread.Sleep(100);

                count--;
            }
        }
    }
}
