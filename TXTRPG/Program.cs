using System;
using TXTRPG;
namespace TXTRPG
{
    internal class Program
    {
        static void Main(string[] args)
            {
                Console.Title = "TRPG유니티(11기) 심낙형"; // 콘솔 타이틀 설정
                TitleManager titleManager = new TitleManager();    // 타이틀 매니저를 통해 게임 시작
                CharacterClass characterClass = new CharacterClass(); // 캐릭터 클래스 선택
                CharacterStatus playerStatus = new CharacterStatus(characterClass.Job); // 캐릭터 상태 생성

            VillageManager villageManager = new VillageManager(playerStatus, playerStatus.Inventory); // 마을 매니저 생성, 플레이어 상태와 인벤토리 전달 

            villageManager.EnterVillage(); // 마을에 들어가기 메소드 호출
        }
    }
}

// 타이틀 -> 캐릭터 클래스 선택 - > 상태 생성(캐릭터 상태) -> 마을 진입(빌리지 매니저) -> 상태보기(1번) <> 마을 재진입(빌리지 매니저) -> 인벤토리(2번) <> 상점(3번) <> 던전(4번) <> 게임 종료(5번) 반복
//static void Main(string[] args)
//{
//    Console.Title = "TRPG유니티(11기) 심낙형";

//    TitleManager titleManager = new TitleManager();    // 게임 타이틀
//    CharacterClass characterClass = new CharacterClass(); // 직업 선택
//    CharacterStatus playerStatus = new CharacterStatus(characterClass.Job); // 캐릭터 상태 생성

//    VillageManager villageManager = new VillageManager(playerStatus); // 마을 매니저
//    villageManager.EnterVillage();  // 마을로 진입
//}
//추가해야할것 장착해제 및 상점구현, 던전 구현, 인벤토리 아이템 사용, 아이템 장착 해제, 상점에서 아이템 구매 및 판매 기능 등
//if (playerStatus.job == "전사")
//{
//    Item UnCommonSword = new Item("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.");
//    UnCommonSword.IsEquipped = true; // 낡은 검을 장착 상태로 설정
//    playerInventory.AddItem(UnCommonSword); // 인벤토리에 낡은 검 추가
//}
//else if (playerStatus.job == "궁수")
//{
//    Item UnCommonBow = new Item("조잡한 활", "금방이라도 부러질것같은 활입니다.");
//    UnCommonBow.IsEquipped = true; // 조잡한 활을 장착 상태로 설정
//    playerInventory.AddItem(UnCommonBow); // 인벤토리에 조잡한 활 추가
//}
//else if (playerStatus.job == "도적")
//{
//    Item UnCommonDagger = new Item("녹슬은 단검", "제 성능을 발휘하지 못하고있는 단검입니다.");
//    UnCommonDagger.IsEquipped = true; // 녹슬은 단검을 장착 상태로 설정
//    playerInventory.AddItem(UnCommonDagger); // 인벤토리에 녹슬은 단검 추가
//}