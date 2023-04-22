using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Stack___Queue_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("확인해볼 괄호를 입력하세요");
            string input = Console.ReadLine();
            BracketCheker(input);
            Console.ReadLine();

            Console.WriteLine("계산식을 입력하십시오.(한자리 수만 입력 가능)");
            string calc = Console.ReadLine();
            double result = Calculator(calc);
            Console.WriteLine($"계산 결과 : {result}");
            Console.ReadLine();

            Console.WriteLine("플레이어의 수를 입력하세요");
            Console.WriteLine("플레이어의 스피드는 랜덤으로 설정됩니다.");
            int people = int.Parse(Console.ReadLine());
            FasterPlayer(people);
            Console.ReadLine();

            Console.WriteLine("첫번 째 자연수 입력");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("두번 째 자연수 입력(첫번 째 수보다 작아야 합니다.)");
            int k = int.Parse(Console.ReadLine());
            int josephus = Josephus(n, k);
            Console.WriteLine($"요세푸스 문제 정답은 {josephus}번 입니다.");
            Console.ReadLine();
        }

        static void BracketCheker(string bracket)
        {
            Console.Clear();
            Stack<char> stack = new Stack<char>();

            foreach (char item in bracket)
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    stack.Push(item);
                    continue;
                }

                if (stack.Count == 0)
                    continue;
                else
                {
                    char pick = stack.Peek();

                    switch (pick)
                    {
                        case '(':
                            foreach (char check in bracket)
                            {
                                if (check == ')' && stack.Count != 0)
                                {
                                    stack.Pop();
                                    break;
                                }
                            }                            
                            break;
                        case '{':
                            foreach (char check in bracket)
                            {
                                if (check == '}' && stack.Count != 0)
                                {
                                    stack.Pop();
                                    break;
                                }
                            }
                            break;
                        case '[':
                            foreach (char check in bracket)
                            {
                                if (check == ']' && stack.Count != 0)
                                {
                                    stack.Pop();
                                    break;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            if (stack.Count == 0)
                Console.WriteLine("모든 괄호가 맞습니다.");
            else
                Console.WriteLine("괄호가 맞지 않습니다.");
        }

        static double Calculator(string input)
        {
            Console.Clear();
            Stack<string> stack = new Stack<string>();
            double op1 = 0;
            double op2 = 0;

            input = ChangeInput(input);

            for (int i = 0; i < input.Length; i++)
            {
                char item = input.ToArray()[i];

                if (item != '+' && item != '-' && item != '*' && item != '/')
                    stack.Push(item.ToString());
                else
                {
                    op2 = double.Parse(stack.Pop().ToString());
                    op1 = double.Parse(stack.Pop().ToString());

                    switch (item)
                    {
                        case '+':
                            stack.Push((op1 + op2).ToString());
                            break;
                        case '-':
                            stack.Push((op1 - op2).ToString());
                            break;
                        case '*':
                            stack.Push((op1 * op2).ToString());
                            break;
                        case '/':
                            stack.Push((op1 / op2).ToString());
                            break;
                    }
                }
            }
            return double.Parse(stack.Pop().ToString());
        }

        static string ChangeInput(string input)
        {
            Stack<char> opStack = new Stack<char>();
            StringBuilder sb = new StringBuilder();

            char[] calc = input.ToCharArray();

            for (int i = 0; i < calc.Length; i++)
            {
                if (calc[i] != '+' && calc[i] != '-' && calc[i] != '*' && calc[i] != '/')
                    sb.Append(calc[i]);
                else if (opStack.Count == 0)
                    opStack.Push(calc[i]);
                else
                {
                    if (OperatorFirst(opStack.Peek()) < OperatorFirst(calc[i]))
                    {
                        opStack.Push(calc[i]);
                    }
                    else
                    {
                        while (opStack.Count > 0)
                        {
                            if (OperatorFirst(opStack.Peek()) >= OperatorFirst(calc[i]))
                                sb.Append(opStack.Pop());
                            else
                                break;
                        }
                        opStack.Push(calc[i]);
                    }                    
                }
            }

            char check = ' ';
            while (opStack.Count > 0)
            {
                check = opStack.Pop();
                sb.Append(check);
            }

            return sb.ToString();
        }

        static int OperatorFirst(char c)
        {
            switch (c)
            {
                case '*':
                case '/':
                    return 3;
                case '+':
                case '-':
                    return 2;
                default:
                    return -1;
            }
        }

        static void FasterPlayer(int people)
        {
            Console.Clear();
            Queue<int> faster = new Queue<int>();
            List<int> list = new List<int>();

            for (int i  = 0; i < people; i++)
            {
                Player player = new Player();
                list.Add(player.Speed);
            }

            list.Sort();
            list.Reverse();

            for (int i = 0; i < list.Count; i++)
                faster.Enqueue(list[i]);

            foreach (int i in list)
            {
                faster.Dequeue();
                Console.WriteLine($"스피드가 {i}인 플레이어가 행동");
            }
        }

        static int Josephus(int n, int k)
        {
            Console.Clear();
            Queue<int> josep = new Queue<int>();

            for (int i = 1; i <= n; i++)
                josep.Enqueue(i);

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < k; j++)
                {
                    josep.Enqueue(josep.Dequeue());                    
                }
                josep.Dequeue();
            }

            return josep.Dequeue();
        }
    }
}