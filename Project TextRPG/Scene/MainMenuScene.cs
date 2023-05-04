using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class MainMenuScene : Scene
    {
        public MainMenuScene(Game game) : base(game) { }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" **********                   **     *******      *******       ******** ");
            sb.AppendLine("/////**///                   /**    /**////**    /**////**     **//////**");
            sb.AppendLine("    /**      *****  **   ** ******  /**   /**    /**   /**    **      // ");
            sb.AppendLine("    /**     **///**//** ** ///**/   /*******     /*******    /**         ");
            sb.AppendLine("    /**    /******* //***    /**    /**///**     /**////     /**    *****");
            sb.AppendLine("    /**    /**////   **/**   /**    /**  //**  **/**       **//**  ////**");
            sb.AppendLine("    /**    //****** ** //**  //**   /**   //**/**/**      /** //******** ");
            sb.AppendLine("    //      ////// //   //    //    //     // // //       //   ////////  ");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("=========================================================================");
            sb.AppendLine("                       게임을 시작하시겠습니까?                          ");
            sb.AppendLine("1. 예");
            sb.AppendLine("2. 아니오");
            sb.AppendLine("=========================================================================");

            Console.WriteLine(sb.ToString());
        }

        public override void Update()
        {
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
                    game.GameStart();
                    break;
                case 2:
                    break;
            }
        }
    }
}
