using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXTRPG;

namespace TXTRPG
{
    internal class Campfire
    {
        private CharacterStatus playerStatus;
        private CharacterInventory playerInventory;

        public Campfire(CharacterStatus status, CharacterInventory inventory)
        {
            playerStatus = status;
            playerInventory = inventory;
        }

        public void EnterCampfire()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== 캠프파이어 ===");
                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 휴식하기");
                Console.WriteLine("4. 휴식 종료하기");
                Console.Write("선택: ");

                string input = Console.ReadLine();
                if (input == "1")
                    playerStatus.ShowStatus();
                else if (input == "2")
                    playerInventory.ShowInventory();
                else if (input == "3")
                {
                    // 예: 체력 회복 기능 등
                    Console.WriteLine("휴식 중... 체력이 회복되었습니다!");
                    // playerStatus.hp += 20; // hp 증가 예시 (만약 hp set이 public이면)
                    Console.ReadLine();
                }
                else if (input == "4")
                    break; // 캠프파이어 종료
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadLine();
                }
            }
        }
    }

}
