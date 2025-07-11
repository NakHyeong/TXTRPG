using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using TXTRPG;

namespace TXTRPG
{
    internal class VillageManager // 마을 매니저 클래스
    {
        private CharacterStatus playerStatus; // 플레이어 상태를 저장할 변수
        private CharacterInventory playerInventory; // 플레이어 인벤토리 변수
        private Shop shop; // 상점 변수
        public VillageManager(CharacterStatus playerStatus, CharacterInventory playerInventory) // 생성자 - 플레이어 상태와 인벤토리를 받아옴
        {
            this.playerStatus = playerStatus;
            this.playerInventory = playerInventory; // 플레이어 인벤토리(CharacterInventory)를 받아옴
            this.shop = new Shop(this.playerStatus, this.playerInventory); // 상점은 플레이어 상태와 인벤토리를 알아야 골드 차감 및 아이템 구매가 가능

            foreach(Item item in playerInventory.items) // 인벤토리에 있는 아이템을 상점에 등록
            {
                shop.RegisterPurchasedItem(item.Name); // 상점에 구매한 아이템 이름 등록
            }
        }
        public void EnterVillage() // 마을에 들어가는 메소드
        {
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("스파르타 마을에 오신것을 환영합니다!");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
            Console.WriteLine("");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

            while (true) // 무한 반복 -> 0 누르면 다시 메뉴로 돌아옴
            {
                Console.Clear(); // 화면 초기화
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("");
                Console.WriteLine("스파르타 마을에 오신것을 환영합니다!");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
                Console.WriteLine("");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");


                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 던전");
                Console.WriteLine("5. 게임 종료");
                Console.Write(" 원하시는 행동을 입력해주세요. :  ");

                string input = Console.ReadLine(); // 사용자 입력 받기

                if (input == "1")
                {
                    Console.WriteLine("\n [상태보기]를 선택했습니다..");
                    playerStatus.ShowStatus(); // 캐릭터 상태 보기 메소드 호출
                    // 상태보기 로직 추가
                }
                else if (input == "2")
                {
                    Console.WriteLine("\n[인벤토리]를 선택했습니다.");
                    playerInventory.ShowInventory(); // 인벤토리 메소드 호출
                    // 인벤토리 로직 추가
                }
                else if (input == "3")
                {
                    Console.WriteLine("\n[상점]을 선택했습니다.");
                    shop.ShowShop(); // 상점 메소드 호출
                    // 상점 로직 추가
                }
                else if (input == "4")
                {
                    Console.WriteLine("\n[던전]을 선택했습니다.");
                    //던전 이동 로직 추가(아직미구현)
                }
                else if (input == "5")
                {
                    Console.WriteLine("\n게임을 종료합니다...");
                    Environment.Exit(0); // 프로그램 완전히 종료 (CMD 창 닫힘)
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 1 ~ 5 으로 다시 시도해주세요.");
                }
            }
            
        }
    }
}
