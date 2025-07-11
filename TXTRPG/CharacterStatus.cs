using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TXTRPG;

namespace TXTRPG
{
    internal class CharacterStatus // 캐릭터 상태 클래스
    {
        public string job { get; private set; } // 캐릭터 직업, 값을 가져올 수 있지만 외부에서 변경할 수 없음(챕터 3 강의 내용자료)
        public string name { get; private set; } // 캐릭터 이름, 값을 가져올 수 있지만 외부에서 변경할 수 없음
        public int level { get; private set; } // 캐릭터 레벨, 값을 가져올 수 있지만 외부에서 변경할 수 없음
        public int gold { get; set; } // 캐릭터 소지 금액, 외부에서 값을 가져오고 변경할 수 있음(소지 금액은 외부에서 변경 가능해야 하므로 set을 public으로 설정)
        public int attack { get; private set; } // 공격력, 값을 가져올 수 있지만 외부에서 변경할 수 없음
        public int defense { get; private set; } // 방어력, 값을 가져올 수 있지만 외부에서 변경할 수 없음
        public int hp { get; set; } // 체력, 외부에서 값을 가져오고 변경할 수 있음(체력은 외부에서 변경 가능해야 하므로 set을 public으로 설정)
        public int maxHp { get; private set; } // 최대 체력, 값을 가져올 수 있지만 외부에서 변경할 수 없음

        public CharacterInventory Inventory { get; private set; } // 인벤토리를 외부에서 접근할 수 있도록 프로퍼티로 제공

        public CharacterStatus(string job) // 생성자 - 캐릭터 생성 시 직업을 받고 고정으로 설정
        {
            Inventory = new CharacterInventory(); // 인벤토리 초기화
            // 캐릭터 생성 시 직업에 따라 초기 상태 설정
            this.job = job;
            level = 1; // 초기 레벨은 1
            gold = 5000; // 초기 소지 금액은 1500(지금은 test를위해 5000으로 설정)
            attack = 10; // 기본 공격력
            defense = 5; // 기본 방어력
            hp = 100; // 기본 체력
            maxHp = 100; // 최대 체력

            Console.Clear();
            Console.WriteLine($"당신의 직업은 [{job}] 입니다.\n"); // 직업 출력

            Console.Write("캐릭터 이름을 입력하세요: "); // 캐릭터 이름 입력 받기
            name = Console.ReadLine();

            if (job == "전사")
            {
                //클론 아이템을 생성하여 인벤토리에 추가(클론은 아이템을 복사하는 메소드) 클론 관련은 튜터님한테 배운 내용
                //클론 아이템을 복사하기 위해서는 Item 클래스에 생성자가 추가되어야 함(원본 아이템을 복사할 수 있도록)
                Item weapon = CloneItem(GameItem.UnCommonSword);
                weapon.IsEquipped = true;
                Inventory.AddItem(weapon, false);
            }
            else if (job == "궁수")
            {
                Item weapon = CloneItem(GameItem.UnCommonBow);
                weapon.IsEquipped = true;
                Inventory.AddItem(weapon, false);
            }
            else if (job == "도적")
            {
                Item weapon = CloneItem(GameItem.UnCommonDagger);
                weapon.IsEquipped = true;
                Inventory.AddItem(weapon, false);
            }


            Console.WriteLine("\n캐릭터 생성 완료! 아무키나 누르면 마을로 이동합니다.");
            Console.Write(">> ");
            Console.ReadLine();

        }

        private Item CloneItem(Item item) // 아이템을 복사하는 메소드
        {
            return new Item(item.Name, item.Description, item.IsWeapon, item.IsArmor, item.Attack, item.Defense, item.Price); // 아이템의 속성을 그대로 복사하여 새로운 아이템 생성
        }
        public void SetGold(int newGold) // 소지 금액을 설정하는 메소드
        {
            gold = newGold; // 소지 금액 업데이트
        }
        public void DecreaseGold(int amount) // 소지 금액을 감소시키는 메소드
        {
            gold -= amount; // 소지 금액에서 지정된 금액을 감소
        }

        public void RestoreHP()
        {
            hp = maxHp; // 체력을 최대 체력으로 설정하여 전부 회복
        }


        public void ShowStatus() // 캐릭터 상태를 출력하는 메소드
        {
            while (true) // 무한 반복 -> 사용자가 상태를 확인하고 나갈 때까지
            {
                Console.Clear();
                Console.WriteLine("===== [ 캐릭터 상태 보기 ] =====\n");

                int totalattack = attack;
                int totaldefanse = defense;

                foreach (Item item in Inventory.items) // 인벤토리의 아이템을 순회
                {
                    if (item.IsEquipped) // 아이템이 장착되어 있는 경우
                    {
                        totalattack += item.Attack; // 공격력 증가
                        totaldefanse += item.Defense; // 방어력 증가
                    }
                }


                Console.WriteLine($"레벨 : {level}");
                Console.WriteLine($"이름 : {name}");
                Console.WriteLine($"직업 : {job}");
                Console.WriteLine($"공격력 : {totalattack}( +{totalattack - attack} )");
                Console.WriteLine($"방어력 : {totaldefanse}( +{totaldefanse - defense} )");
                Console.WriteLine($"체력 : {hp} / { maxHp} ");
                Console.WriteLine($"Gold : {gold}");


                Console.WriteLine("\n0을 누르면 마을 화면으로 돌아갑니다.");
                Console.Write(">> ");
                if (Console.ReadLine() == "0")
                {
                    break; // 사용자가 0을 입력하면 상태 보기 종료
                }

                }

        }
    }
}

