using System.Runtime.CompilerServices;

namespace Stack___Queue_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            BracketCheker(input);
        }

        static void BracketCheker(string bracket)
        {
            Stack<char> stack = new Stack<char>();

            char[] check = bracket.ToCharArray();

            for (int i = 0; i < check.Length; i++) stack.Push(check[i]);

            while (stack.Count > 0)
            {
                char c = stack.Peek();

                foreach (char item in stack)
                {
                    switch (c)
                    {
                        case ')':
                            if (item == '(')
                            {
                                stack.Pop();
                                break;
                            }
                            else
                                continue;
                        case '}':
                            if (item == '{')
                            {
                                stack.Pop();
                                break;
                            }
                            else
                                continue;
                        case ']':
                            if (item == '[')
                            {
                                stack.Pop();
                                break;
                            }
                            else
                                continue;
                        default:
                            if (item == '(' || item == '{' || item == '[')
                            {
                                continue;
                            }
                            else
                            {
                                stack.Pop();
                                break;
                            }
                    }
                }
                break;
            }
            if (stack.Count == 0)
                Console.WriteLine("모든 괄호가 잘 맞습니다.");
            else
                Console.WriteLine("괄호가 맞지 않습니다.");
        }
    }
}