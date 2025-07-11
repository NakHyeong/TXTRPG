using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXTRPG;

namespace TXTRPG
{
    internal class Shop
    {
        public List<Item> shopItems { get; private set; }  // 상점 아이템 리스트를 외부에서 접근할 수 있도록 프로퍼티로 제공
        private CharacterStatus playerStatus; // 플레이어 상태
        private CharacterInventory playerInventory; // 플레이어 인벤토리
        //private HashSet<string> purchasedItemsNames; // 구매한 아이템 이름을 저장하는 해시셋(중복 방지) 튜더님에게 배운 내용, 근데 응용방법을 이해못해 사용을 못하겠음.
        public void RegisterPurchasedItem(string itemName) // 
        {
            //purchasedItemsNames.Add(itemName); // 구매한 아이템 이름을 해시셋에 추가
        }

        public Shop(CharacterStatus playerStatus, CharacterInventory playerInventory)
        {
            this.playerStatus = playerStatus;
            this.playerInventory = playerInventory;
            shopItems = new List<Item>(GameItem.AllItem); // GameItem 클래스에서 모든 아이템을 가져옴
            //purchasedItemsNames = new HashSet<string>();  // 구매한 아이템 이름을 저장할 해시셋 초기화(중복 방지)
        }
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== [ 상점 메뉴 ] =====\n");
                Console.WriteLine($"보유 골드: {playerStatus.gold}G\n");
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 마을로 돌아가기");
                Console.Write("\n원하시는 행동을 입력해주세요 ");
                Console.WriteLine(">> ");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    ShowBuyMenu(); // 아이템 구매 메뉴 호출
                }
                else if (input == "2")
                {
                    ShowSellMenu();
                }
                else if (input == "0")
                {
                    break; // 마을로 돌아가기
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    WaitForZero();
                }
            }
        }
        public void ShowBuyMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== [ 아이템 구매 ] =====\n");
                Console.WriteLine($"보유 골드: {playerStatus.gold} G\n");

                Console.WriteLine("구매 가능한 아이템 목록:");
                for (int i = 0; i < shopItems.Count; i++)
                {
                    Item item = shopItems[i];
                    string status;
                    if (item.IsPurchased) // 아이템이 이미구매된 경우
                    {
                        status = "구매완료"; // 이미 구매한 아이템
                    }
                    else
                    {
                        status = $"{item.Price} G"; // 구매 가능한 아이템
                    }
                    Console.WriteLine($"{i + 1}. {item.Name} | {item.Description} | {status}"); // 아이템 번호, 이름, 설명, 가격 출력
                }
                Console.WriteLine("구매할 아이템 번호를 입력하세요: ");
                Console.WriteLine("\n0. 나가기");
                Console.WriteLine(">> ");
                Console.WriteLine("");
                Console.WriteLine("=========================");

                string input = Console.ReadLine();

                if (input == "0") // 나가기 선택
                {
                    Console.WriteLine("상점을 나갑니다.");
                    break; // 상점 종료
                }

                if (!int.TryParse(input, out int selectedItem) || selectedItem < 1 || selectedItem > shopItems.Count)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    WaitForZero();
                    continue;
                }

                BuyItem(shopItems[selectedItem - 1]);

            }
        }
        private void BuyItem(Item item)
        {
            if (item.IsPurchased)
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
            else if (playerStatus.gold < item.Price)
            {
                Console.WriteLine("골드가 부족합니다.");
            }
            else
            {
                playerStatus.DecreaseGold(item.Price); // 골드 차감
                playerInventory.AddItem(item); // 인벤토리에 추가
                item.IsPurchased = true; // 아이템 구매 상태를 true로 설정
                //purchasedItemsNames.Add(item.Name);

                Console.WriteLine($"'{item.Name}'을 구매했습니다!");
                Console.WriteLine($"남은 골드: {playerStatus.gold} G");
            }

            WaitForZero();
        }

        private void ShowSellMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== [ 아이템 판매 ] =====\n");

                if (playerInventory.items.Count == 0)
                {
                    Console.WriteLine("판매할 아이템이 없습니다.");
                    WaitForZero();
                    return; // 판매할 아이템이 없으면 메뉴 종료
                }
                for (int i = 0; i < playerInventory.items.Count; i++) // 인벤토리 아이템 출력
                {
                    Item item = playerInventory.items[i]; // 아이템을 가져옴
                    Console.WriteLine($"{i + 1}. {item.Name} - {item.Description} 판매가: {(int)(item.Price * 0.85)} G"); // 판매가는 원래 가격의 85%로 설정
                }

                Console.WriteLine("0. 나가기");
                Console.WriteLine("판매할 아이템 번호를 입력해주세요.");
                Console.Write(">> ");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    Console.WriteLine("상점으로 돌아갑니다.");
                    break; // 상점으로 돌아감
                }
                if (!int.TryParse(input, out int selectedItem) || selectedItem < 1 || selectedItem > playerInventory.items.Count)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    WaitForZero(); // 잘못된 입력 시 다시 입력 받기
                    continue; // 잘못된 입력 시 다시 입력 받기
                }
                Item selectedItemObj = playerInventory.items[selectedItem - 1]; // 선택한 아이템 가져오기
                SellItem(selectedItemObj); // 아이템 판매 메소드 호출
            }
        }
        private void SellItem(Item item)
        {
            int sellPrice = (int)(item.Price * 0.85); // 판매가는 원래 가격의 85%로 설정
            if (item.IsEquipped)
            {
                item.IsEquipped = false; // 아이템이 장착되어 있다면 장착 해제
                Console.WriteLine($"'{item.Name}'은, 판매되어 자동으로 해제되었습니다."); // 아이템이 장착되어 있다면 장착 해제
            }
            playerInventory.items.Remove(item); // 인벤토리에서 아이템 제거
            playerStatus.SetGold(playerStatus.gold + sellPrice); // 플레이어의 골드 증가
            item.IsPurchased = false; // 아이템 구매 상태를 false로 설정
            Console.WriteLine($"'{item.Name}' 아이템을 판매했습니다. 판매가: {sellPrice} G");
            Console.WriteLine($"현재 골드: {playerStatus.gold} G");
            WaitForZero(); // 판매 후 0을 누르면 상점으로 돌아감

         }
        private void WaitForZero()
        {
            while (true) // 
            {
                Console.WriteLine("0을 누르면 상점으로 돌아갑니다.");
                Console.Write(">> ");
                if (Console.ReadLine() == "0")
                {
                    break; // 0을 누르면 상점으로 돌아감
                }
            }
        }
    }
}
