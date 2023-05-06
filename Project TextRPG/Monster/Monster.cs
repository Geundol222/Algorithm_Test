﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public abstract class Monster
    {
        public char icon = '⊙';
        public string image;
        public string name { get; set; }
        public Point point;

        public int curHp { get; set; }
        public int maxHp { get; set; }
        public int ap { get; set; }
        public int dp { get; set; }
        public int speed { get; set; }
        public int gold { get; set; }
        public int exp { get; set; }

        public abstract void MoveAction();

        protected void Move(Direction dir)
        {
            Point prevPoint = point;

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
                point = prevPoint;
        } 

        public void Attack(Player player)
        {
            Console.WriteLine($"{name}이(가) {player.name}을 공격합니다!");
            Thread.Sleep(1000);
            player.TakeDamage(ap, this);
        }

        public void TakeDamage(int damage)
        {
            Console.WriteLine($"{name}은 {Data.player.name}에게 공격 받았습니다.");
            Thread.Sleep(1000);

            if (damage > dp)
            {
                curHp -= damage - dp;
                Console.WriteLine($"{name}은 {damage-dp}의 데미지를 받았습니다.");
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
                Thread.Sleep(1000);
            }
        }
    }
}