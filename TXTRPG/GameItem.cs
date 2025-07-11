using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXTRPG;

namespace TXTRPG
{
    internal static class GameItem
    {
        // 직업별 기본 아이템 정의
        public static Item UnCommonSword = new Item("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", true, false, 2, 0, 600);
        public static Item UnCommonBow = new Item("조잡한 활", "금방이라도 부러질것같은 활입니다.", true, false, 2, 0, 600);
        public static Item UnCommonDagger = new Item("녹슬은 단검", "제 성능을 발휘하지 못하고있는 단검입니다.", true, false, 2, 0, 600);
        // 기본 아이템 리스트
        public static Item CommonArmor = new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", false, true, 0, 5, 1000);
        public static Item RareArmor = new Item("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", false, true, 0, 9, 2000);
        public static Item UniqueArmor = new Item("스파르타 갑옷", "스파르타 전사들이 사용했다는 전설의 갑옷입니다.", false, true, 0, 15, 3500);
        public static Item CommonAxe = new Item("청동 도끼", "어디선가 사용했던거 같은 도끼입니다.", true, false, 5, 0, 1500);
        public static Item RareSpear = new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", true, false, 7, 0, 3000);
        public static Item UniqueSpear = new Item("전설의 창", "전설 속에만 존재하는 창입니다.", true, false, 12, 0, 5000);

        // 상점용 아이템 리스트
        public static List<Item> AllItem = new List<Item>
        {
            UnCommonSword,
            UnCommonBow,
            UnCommonDagger,
            CommonArmor,
            RareArmor,
            UniqueArmor,
            CommonAxe,
            RareSpear,
            UniqueSpear

        };
    }
}

//public static string[] Names =
//        {
//            "낡은 검", "조잡한 활", "수련자 갑옷", "무쇠 갑옷", "스파르타 갑옷"
//        };

//// 아이템 설명 배열
//public static string[] Descriptions =
//        {
//            "쉽게 볼 수 있는 낡은 검입니다.",
//            "금방이라도 부러질것같은 활입니다.",
//            "수련에 도움을 주는 갑옷입니다.",
//            "무쇠로 만들어져 튼튼한 갑옷입니다.",
//            "스파르타 전사들이 사용했다는 전설의 갑옷입니다."
//        };

//// 공격력 배열
//public static int[] Attacks = { 2, 2, 0, 0, 0 };

//// 방어력 배열
//public static int[] Defenses = { 0, 0, 5, 9, 15 };

//// 가격 배열
//public static int[] Prices = { 600, 600, 1000, 2000, 3500 };

//// 구매 여부 배열
//public static bool[] Purchased = { false, false, false, false, false };
//    }