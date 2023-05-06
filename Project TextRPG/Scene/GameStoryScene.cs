using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class GameStoryScene : Scene
    {
        public GameStoryScene(Game game) : base(game) { }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("수백년간 평화로웠던 마을에 갑자기 몬스터가 나타나기 시작했다.");
            sb.AppendLine();
            sb.AppendLine("마을사람들은 힘을 합쳐 몬스터에 대응하기 시작했고, 당신도 힘은 없지만 마을을 돕기로한다.");
            sb.AppendLine();
            sb.AppendLine("강해져서 마을을 구하고 나아가 세상도 구해보자!");

            char[] charArr = sb.ToString().ToCharArray();

            for (int i = 0;  i < charArr.Length; i++)
            {
                Console.Write(charArr[i]);
                Thread.Sleep(30);
            }
        }

        public override void Update()
        {
            Thread.Sleep(1000);

            game.currentScene = game.sceneDic["마을"];
        }
    }
}
