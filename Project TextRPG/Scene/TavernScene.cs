using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class TavernScene : Scene
    {
        public TavernScene(Game game) : base(game) { }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder tavern = new StringBuilder();

            Console.Clear();

            tavern.AppendLine("        (");
            tavern.AppendLine("");
            tavern.AppendLine("           )");
            tavern.AppendLine("         ( _   _._");
            tavern.AppendLine("          |_|-'_~_`-._");
            tavern.AppendLine("      _.-'-_~_-~_-~-_`-._");
            tavern.AppendLine("  _.-'_~-_~-_-~-_~_~-_~-_`-._");
            tavern.AppendLine(" ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            tavern.AppendLine("   |  []  []   []   []  [] |");
            tavern.AppendLine("   |           __    ___   |");
            tavern.AppendLine(" ._|  []  []  | .|  [___]  |");
            tavern.AppendLine(" |=|________()|__|()_______|");
            tavern.AppendLine("^^^^^^^^^^^^^^^ === ^^^^^^^^^^^^^^^^^");

            sb.AppendLine("당신은 여관으로 들어갑니다.");
            sb.AppendLine();
            sb.AppendLine("여관주인 : 어서오세요! 쉬시려구요? 하룻밤에 50골드 입니다");
            sb.AppendLine();

            Console.WriteLine(tavern.ToString());

            char[] charArr = sb.ToString().ToCharArray();

            for (int i = 0; i < charArr.Length; i++)
            {
                Console.Write(charArr[i]);
                Thread.Sleep(30);
            }

            Console.WriteLine("여관에서 쉬시겠습니까? (주의! 쉴 경우 체력과 상관없이 돈은 차감됩니다!)");
            Console.WriteLine("1. 예");
            Console.WriteLine("2. 아니오");
        }

        public override void Update()
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

            switch (command)
            {
                case 1:
                    sb.AppendLine();
                    sb.AppendLine("당신 : 네 여기 50 골드요");
                    sb.AppendLine();
                    sb.AppendLine("50골드를 지불했습니다.");
                    Data.player.gold -= 50;
                    sb.AppendLine($"현재 골드 : {Data.player.gold}");
                    sb.AppendLine();
                    sb.AppendLine("여관주인 : 예~ 감사합니다. 들어오시죠");
                    sb.AppendLine();
                    if (Data.player.curHp >= Data.player.maxHp)
                    {
                        sb.AppendLine("당신은 쌩쌩한 상태로 쉬었습니다. 돈을 날렸다는 생각이 듭니다.");
                        sb.AppendLine($"현재 체력 : {Data.player.curHp} / {Data.player.maxHp}");
                    }
                    else
                    {
                        sb.AppendLine("당신은 여관에서 쉬었습니다. 체력이 전부 회복됩니다.");
                        Data.player.curHp = Data.player.maxHp;
                        sb.AppendLine($"현재 체력 : {Data.player.curHp} / {Data.player.maxHp}");
                    }
                    break;
                case 2:
                    sb.AppendLine();
                    sb.AppendLine("당신 : 아니오 다음에 오겠습니다.");
                    sb.AppendLine();
                    sb.AppendLine("당신은 마을로 돌아갑니다.");
                    break;
            }

            char[] charArr = sb.ToString().ToCharArray();

            for (int i = 0; i < charArr.Length; i++)
            {
                Console.Write(charArr[i]);
                Thread.Sleep(30);
            }

            Thread.Sleep(1000);
            game.currentScene = game.sceneDic["마을"];
        }
    }
}
