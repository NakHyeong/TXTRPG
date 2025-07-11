using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXTRPG;

namespace TXTRPG
{
    internal class TitleManager
    {
            public TitleManager()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("");
                    Console.WriteLine("  스파르타 마을에 온것을 환영합니다.!");
                    Console.WriteLine("");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                    Console.WriteLine("1. 게임 시작");
                    Console.WriteLine("2. 게임 종료");
                    Console.WriteLine("\n 1번을 눌러주세요! \n ");

                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("\n게임을 시작합니다...");
                        // 게임 시작 로직 추가
                        break; //while 탈출 → 이후 Main()에서 VillageManager 호출
                    }
                    else if (input == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("\n게임을 종료합니다...");
                        Environment.Exit(0); // 프로그램 완전히 종료 (CMD 창 닫힘)
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다. 1 또는 2를 입력해주세요.");
                    }

                    Console.WriteLine("\n 엔터를 누르면 다시 타이틀로 돌아갑니다.");
                    Console.ReadLine(); // 여기서 멈췄다가 엔터치면 다시 while 처음으로 돌아감
                }
            }

        }
    }

