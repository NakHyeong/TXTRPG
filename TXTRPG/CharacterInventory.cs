using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXTRPG;

namespace TXTRPG
{
    internal class CharacterInventory
    {
        public List<Item> items { get; private set; } // 아이템 리스트를 외부에서 접근할 수 있도록 프로퍼티로 제공

        public CharacterInventory() // 생성자 - 인벤토리 초기화
        {
            items = new List<Item>(); // 처음에는 빈 리스트로 초기화
        }
        public void AddItem(Item item, bool showMessage = true) // 아이템 추가 메소드
        {
            items.Add(item); // 아이템을 리스트에 추가
            if (showMessage) // 메시지를 출력할지 여부를 결정하는 매개변수
            {
                Console.WriteLine($"{item.Name} 아이템이 인벤토리에 추가되었습니다.");
            }
        }

        public void ShowInventory() // 인벤토리 상태를 출력하는 메소드
        {
            while (true) // 무한 반복 -> 사용자가 인벤토리에서 나갈 때까지
            {

                Console.Clear();
                Console.WriteLine("===== [ 인벤토리 보기 ] =====\n");
                Console.WriteLine("보유 중인 아이템을 관리합니다.");


                if (items.Count == 0) // 아이템이 없을 경우
                {
                    Console.WriteLine("인벤토리에 아이템이 없습니다.");
                }
                else // 아이템이 있을 경우
                {
                    for (int i = 0; i < items.Count; i++) // 아이템 리스트 출력
                    {
                        // 아이템 이름과 설명을 출력
                        // 예: 1. 아이템이름 - 아이템설명
                        if (items[i].IsEquipped) // 아이템이 장착되어 있는지 확인
                        {
                            Console.WriteLine($"{i + 1}. {items[i].Name} - {items[i].Description} (장착 중)");
                        }
                        else // 아이템이 장착되어 있지 않은 경우
                        {
                            Console.WriteLine($"{i + 1}. {items[i].Name} - {items[i].Description}");
                        }
                    }

                    Console.WriteLine("\n 1. 장착 관리");
                    Console.WriteLine(" 0. 나가기");
                    Console.Write("\n원하시는 행동을 입력해주세요. :  ");

                    string input = Console.ReadLine();

                    if (input == "1" && items.Count > 0) // 장착 관리 선택
                    {
                        ManagerEquipment(); // 아이템 장착 관리 메소드 호출
                    }
                    else if (input == "0")
                    {
                        break; // 인벤토리 나가기
                    }
                }
            }
        }

        private void ManagerEquipment() // 아이템 장착 관리 메소드
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== [ 아이템 장착 관리 ] =====\n");

                if (items.Count == 0)
                {
                    Console.WriteLine("인벤토리에 아이템이 없습니다.");
                }
                else
                {
                    Console.WriteLine("장착 가능한 아이템 목록:");
                    for (int i = 0; i < items.Count; i++)
                    {
                        Item item = items[i];

                        string equipMark = ""; // 장착 여부 표시
                        if (item.IsEquipped) // 아이템이 장착되어 있는지 확인
                        {
                            equipMark = "(장착 중)"; // 장착 중인 아이템 표시
                        }

                        string statInfo = ""; // 아이템의 공격력과 방어력 정보
                        if (item.Attack > 0) // 공격력이 0보다 큰 경우
                        {
                            statInfo = $"공격력 + {item.Attack}";
                        }
                        else
                        {
                            statInfo = $"방어력 + {item.Defense}"; // 방어력이 0보다 큰 경우
                        }

                        Console.WriteLine($"{i + 1}. {item.Name} | {statInfo} | {item.Description} {equipMark}");
                    }
                }
                Console.WriteLine("0. 인벤토리로 돌아가기");
                Console.Write("\n 아이템 번호를 입력하면 장착/해제를 할 수 있습니다.:   ");
                Console.Write("\n원하시는 행동을 입력해주세요. :  ");
                Console.WriteLine("");
                Console.WriteLine("=============================\n");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    break; // 아이템 장착 관리 나가기
                }

                int selected;
                if (int.TryParse(input, out selected) && selected >= 1 && selected <= items.Count) // 입력값이 숫자이고, 아이템 목록 범위 내에 있는 경우
                {
                    Item selectedItem = items[selected - 1]; // 선택한 아이템 가져오기

                    if (selectedItem.IsEquipped) // 아이템이 장착되어 있는 경우
                    {
                        selectedItem.IsEquipped = false; // 장착 해제
                        Console.WriteLine($"{selectedItem.Name} 아이템이 장착 해제되었습니다.");
                    }
                    else // 아이템이 장착되어 있지 않은 경우
                    {
                        selectedItem.IsEquipped = true; // 장착
                        Console.WriteLine($"{selectedItem.Name} 아이템이 장착되었습니다.");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                }
                Console.WriteLine("\n0을 누르면 다시 아이템 장착 관리 화면으로 돌아갑니다.");
                input = Console.ReadLine();

                if (input == "0")
                {
                    break; // 아이템 장착 관리 나가기
                }
            }
        }

    }
}


