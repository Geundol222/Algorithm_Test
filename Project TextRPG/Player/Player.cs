﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Player
    {
        public char icon = '★';
        public Point point;

        public string name { get; set; }
        public int curHp { get; set; }
        public int maxHp { get; set; }
        public int curMp { get; set; }
        public int maxMp { get; set; }
        public int speed { get; set; }
        public int level { get; set; }
        public int gold { get; set; }
        public int ap { get; set; }
        public int dp { get; set; }
        public float exp { get; set; }

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

        public void UseItem(Item item)
        {
            if (item.Use())
            {
                Data.itemCount[Data.inventory.itemIndex]--;
                if (Data.itemCount[Data.inventory.itemIndex] < 1)
                    Data.inven.Remove(item);
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
                Thread.Sleep(1000);
            }
        }
    }
}
