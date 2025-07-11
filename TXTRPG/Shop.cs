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
        private List<Item> shopItems; // 상점 아이템 리스트
        private CharacterStatus playerStatus; // 플레이어 상태
        private CharacterInventory playerInventory; // 플레이어 인벤토리
        private HashSet<string> purchasedItemsNames; // 구매한 아이템 이름을 저장하는 해시셋(중복 방지) 튜더님에게 배운 내용
        public void RegisterPurchasedItem(string itemName)
        {
            purchasedItemsNames.Add(itemName); // 구매한 아이템 이름을 해시셋에 추가
        }

        public Shop(CharacterStatus playerStatus, CharacterInventory playerInventory)
        {
            this.playerStatus = playerStatus;
            this.playerInventory = playerInventory;
            shopItems = new List<Item>(GameItem.AllItem); // GameItem 클래스에서 모든 아이템을 가져옴
            purchasedItemsNames = new HashSet<string>();  // 구매한 아이템 이름을 저장할 해시셋 초기화(중복 방지)
        }
        public void ShowShop()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== [ 상점 ] =====\n");
                Console.WriteLine("상점에서 아이템을 구매할 수 있습니다.\n");
                Console.WriteLine($"보유 골드: {playerStatus.gold} G\n");

                Console.WriteLine("구매 가능한 아이템 목록:");
                for (int i = 0; i < shopItems.Count; i++)
                {
                    Item item = shopItems[i];
                    string status = purchasedItemsNames.Contains(item.Name) ? "구매완료" : $"{item.Price} G";
                    Console.WriteLine($"{i + 1}. {item.Name} | {item.Description} | {status}");
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
            if (purchasedItemsNames.Contains(item.Name))
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
                purchasedItemsNames.Add(item.Name);

                Console.WriteLine($"'{item.Name}'을 구매했습니다!");
                Console.WriteLine($"남은 골드: {playerStatus.gold} G");
            }

            WaitForZero();
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
