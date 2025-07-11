using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXTRPG;

namespace TXTRPG
    {
        internal class Item
        {
            public string Name { get; private set; } // 아이템 이름을 가져오고 외부에서 변경할 수 없도록 설정
        public string Description { get; private set; } // 아이템 설명을 가져오고 외부에서 변경할 수 없도록 설정
        public bool IsEquipped { get; set; } // 장착 여부

        // 이후 공격력, 방어력, 가격 등도 추가할 수 있음
        public int Attack { get; private set; } // 공격력
        public int Defense { get; private set; } // 방어력
        public int Price { get; private set; } // 가격

        public bool IsWeapon {  get; private set; } // 무기 여부
        public bool IsArmor { get; private set; } // 방어구 여부

        public bool IsPurchased { get; set; } // 구매 여부

        public Item(string name, string description, bool isWeapon, bool isArmor, int attack = 0, int defense = 0, int price = 0)
            {
                Name = name; // 아이템 이름은 생성자에서 설정
            Description = description; // 아이템 이름과 설명은 생성자에서 설정
            IsWeapon = isWeapon;  // 무기 여부는 생성자에서 설정
            IsArmor = isArmor; // 방어구 여부는 생성자에서 설정
            Attack = attack; // 공격력은 기본값 0으로 설정
            Defense = defense; // 공격력과 방어력은 기본값 0으로 설정
            Price = price; // 가격은 기본값 0으로 설정
            IsEquipped = false; // 아이템 생성 시 기본적으로 장착되지 않은 상태
            IsPurchased = false; // 아이템 생성 시 기본적으로 구매되지 않은 상태
        }
        }
    }
