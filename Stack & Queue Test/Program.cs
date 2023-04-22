using System.Runtime.CompilerServices;
using System.Text;

namespace Stack___Queue_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //BracketCheker(input);

            string input = Console.ReadLine();
            double result = Calculator(input);
            Console.WriteLine(result);
        }

        static void BracketCheker(string bracket)
        {
            Stack<char> stack = new Stack<char>();

            char[] check = bracket.ToCharArray();

            for (int i = 0; i < check.Length; i++) stack.Push(check[i]);

            while (stack.Count > 0)
            {
                char c = stack.Pop();

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
                    break;
                }
            }
            if (stack.Count == 0)
                Console.WriteLine("모든 괄호가 잘 맞습니다.");
            else
                Console.WriteLine("괄호가 맞지 않습니다.");
        }

        static double Calculator(string input)
        {
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
                    if (calc[i] == '(')
                    {
                        opStack.Push(calc[i]);
                        continue;
                    }
                    else if (calc[i] == ')')
                    {
                        char c = ' ';
                        while (true)
                        {
                            c = opStack.Pop();
                            if (c == '(')
                                break;
                            else
                                sb.Append(c);
                        }
                        continue;
                    }

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
                if (check != '(')
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
                case '(':
                    return 1;
                default:
                    return -1;
            }
        }
    }
}