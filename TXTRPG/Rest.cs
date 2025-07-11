using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXTRPG;

namespace TXTRPG
    {
        internal class Rest
        {
            private CharacterStatus playerStatus;
            private CharacterInventory playerInventory;

            public Rest(CharacterStatus status, CharacterInventory inventory)
            {
                playerStatus = status;
                playerInventory = inventory;
            }

            public void EnterRest()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("휴식하기");
                    Console.WriteLine($"500G를 내면 체력을 회복할 수있습니다. {playerStatus.gold}G\n");
                    Console.WriteLine("1. 휴식하기 (500G)");
                    Console.WriteLine("0. 마을로 돌아가기");
                    Console.Write("선택: ");

                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        if (playerStatus.gold < 500)
                        {
                            Console.WriteLine("골드가 부족합니다. (500G 필요)");
                        }
                        else
                        {
                            playerStatus.gold -= 500;
                            playerStatus.RestoreHP();
                            Console.WriteLine("휴식을 취했습니다. 체력이 전부 회복되었습니다!");
                            Console.WriteLine("500G를 사용했습니다.");
                        }
                            Console.WriteLine("\n0을 누르면 마을 화면으로 돌아갑니다.");
                    input = Console.ReadLine();
                        if (input == "0")
                        {
                            break; // 마을로 돌아가기
                        }
                    }
                    else if (input == "0")
                    {
                        break; // 마을로 돌아가기
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
