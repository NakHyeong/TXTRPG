using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXTRPG;

namespace TXTRPG
{
    internal class CharacterClass
    {
            public string Job { get; private set; }

            public CharacterClass()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("===== 직업 선택 =====");
                    Console.WriteLine("원하는 직업을 선택하세요.\n");
                    Console.WriteLine("1. 전사");
                    Console.WriteLine("2. 궁수");
                    Console.WriteLine("3. 도적");
                    Console.WriteLine("=====================");
                Console.Write("\n>> ");

                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        Job = "전사";
                        Console.WriteLine("\n당신은 전사를 선택했습니다!");
                        break;
                    }
                    else if (input == "2")
                    {
                        Job = "궁수";
                        Console.WriteLine("\n당신은 궁수를 선택했습니다!");
                        break;
                    }
                    else if (input == "3")
                    {
                        Job = "도적";
                        Console.WriteLine("\n당신은 도적을 선택했습니다!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n잘못된 입력입니다. 1~3 숫자를 입력해주세요.");
                    }

                    Console.WriteLine("\n엔터를 누르면 다시 클래스 화면으로 돌아갑니다.");
                    Console.ReadLine();
                }

                Console.WriteLine();
            }
        }
    }

