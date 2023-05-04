﻿using System;
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
        private Scene currentScene;
        private MainMenuScene mainMenuScene;

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
            mainMenuScene = new MainMenuScene(this);

            currentScene = mainMenuScene;
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

        }
    }
}
