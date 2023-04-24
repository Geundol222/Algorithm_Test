﻿using System.Reflection.Metadata.Ecma335;

namespace PriorityQueue_Test
{
    internal class Program
    {
        // 1. 우선순위 큐 구현
        // 2. 힙 정력 기술면접 준비
        // (힙, 추가, 삭제, 완전이진트리 배열표현)
        // 0. 응급실 만들기 (골든타임을 입력받아서 급한 환자부터 치료하는 응급실)
        // 0. 중간값 구하기 (최대값, 최소값)
        // (ex. 숫자가 10000개 숫자 중 정렬 시켰을 때 중간에 있는 값 찾기 == 5000 번째 큰 수 찾기)
        static void Main(string[] args)
        {
            Emergency();
        }

        static void Emergency()
        {
            PriorityQueue<string, int> patient = new PriorityQueue<string, int>();
            List<string> name = new List<string>();
            List<int> goldenTime = new List<int>();

            while (true)
            {
                Console.Write("환자의 이름을 입력하세요 : ");
                string nameInput = Console.ReadLine();
                name.Add(nameInput);
                Console.WriteLine();
                Console.Write("환자의 골든타임을 입력하세요 : ");
                int timeInput = int.Parse(Console.ReadLine());
                goldenTime.Add(timeInput);

                Console.Clear();
                Console.WriteLine("환자의 정보가 저장 되었습니다.");
                Console.Write("계속 입력하시겠습니까? (y/n)");
                string input = Console.ReadLine();

                if (input == "y" || input == "Y")
                    continue;
                else if (input == "n" || input == "N")
                    break;
            }

            Console.Clear();

            for (int i = 0; i < name.Count; i++)
                patient.Enqueue(name[i], goldenTime[i]);

            int num = 1;
            while (patient.Count > 0)
            {
                string queue = patient.Dequeue();
                Console.WriteLine($"치료가 급한 {num} 번째 환자는 {queue}입니다.");
                num++;
            }
        }
    }
}