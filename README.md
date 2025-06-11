# UnityInventory

## 📌 기본 구성
1. 씬은 **StartScene, MainScene**으로 구성되어 있습니다.  
2. StartScene에서 총 3개의 캐릭터 중 하나의 캐릭터를 골라 생성할 수 있습니다.
3. 캐릭터별 고유 능력이 다릅니다.
4. 원하는 캐릭터가 생성되면, 해당 정보가 JSON을 이용한 직렬화를 통해 저장됩니다.
5. 캐릭터 생성 후, 장비를 착용함에 따라 능력치가 상승합니다.
6. 장비는 착용과 동시에 해당 장비 착용 여부가 실시간으로 JSON 데이터에 저장됩니다.
7. 아이템 정보 불러오기를 통해 장착해두었던 장비를 그대로 다시 불러올 수 있습니다.
8. 게임이 종료되고, 재시작 시에도 해당 데이터는 유지됩니다.

---


## 🎁 스크립트 설명

- **DataSaveLoad** <br>
싱글톤 패턴을 사용해 게임 전체에서 하나의 DataSaveLoad 인스턴스만 유지함.<br>
Awake()에서 저장할 파일 경로(characterData.json)를 설정하고, 오브젝트가 씬 전환 시 파괴되지 않도록 함.<br>
SaveCharacterData(Character character) 함수는 캐릭터 객체를 JSON 문자열로 변환해 지정된 경로에 저장함.<br>
LoadCharacterData() 함수는 저장된 JSON 파일이 있으면 읽어서 다시 Character 객체로 변환해 반환함. 없으면 null을 반환함.<br>
저장/불러오기 과정에서 경로나 데이터 상태를 Debug.Log로 출력해 디버깅 도움.<br>
아이템 관련 기능 또한 추가.<br>
즉, 캐릭터 정보를 파일에 저장하고 다시 불러올 때 편리하게 사용할 수 있는 유틸리티 클래스.<br>

- **ItemData** <br>
ItemType 열거형: 아이템 종류를 정의 (현재는 Equipable 한 종류만 있음)<br>
EquipableType 열거형: 장착 아이템의 스탯 종류 (공격, 방어, 체력, 크리티컬)<br>
ItemDataEquipable 클래스: 장착 아이템의 스탯 타입과 값 저장<br>
ItemData 클래스 (ScriptableObject):<br>
아이템의 이름, 설명, 아이콘 등 기본 정보<br>
스택 가능 여부 및 최대 스택 개수<br>
장착 아이템의 스탯 정보(equipableData) 포함<br>
게임 내에서 장착 가능한 아이템 정보를 에셋으로 만들어 관리할 수 있게 하는 구조.<br>

- **UIInventory** <br>
아이템 갯수 표시: 현재 장착된 아이템 수와 전체 아이템 수를 UI에 업데이트<br>
슬롯 초기화: 개별 슬롯에 아이템과 수량을 할당하고 상태 초기화<br>
아이템 정보 표시: 선택된 아이템의 이름, 설명, 스탯(장착 아이템일 경우) 보여주기<br>
캐릭터 상태 표시: 캐릭터의 공격력, 방어력, 체력, 크리티컬 수치를 UI에 표시<br>
장착/해제 버튼 처리: 선택한 아이템을 장착하거나 해제하고, 슬롯 상태와 UI 텍스트 갱신<br>
아이템 장착 여부 확인 및 슬롯 상태 변경: 아이템이 장착됐는지 확인하고 슬롯의 장착 상태를 업데이트<br>
즉, 인벤토리 내 아이템 관리와 UI 업데이트, 장착 기능을 담당하는 스크립트<br>

- **Character** <br>
기본 정보: 캐릭터의 직업, 이름, 경험치, 레벨, 설명 등 기본 필드 보유
기본 스탯과 현재 스탯 분리: baseAttack, baseDefense, baseHp, baseCritical는 기본 스탯, Attack, Defense, Hp, Critical는 현재 스탯 (기본 + 장착 아이템 효과)
인벤토리 관리: 캐릭터가 가진 모든 아이템 목록, equippedItems: 장착 중인 아이템 목록
아이템 장착: EquipItem(ItemData item) 중복 장착 방지, 장착 시 아이템 효과를 현재 스탯에 더함, 장착 아이템 목록에 추가
아이템 해제: UnequipItem(ItemData item) 장착 확인 후 해제, 해제 시 아이템 효과를 현재 스탯에서 뺌, 장착 아이템 목록에서 제거, 스탯 재계산
아이템 스탯 재계산: RecalculateStats(), 기본 스탯으로 초기화 후, 장착 아이템 효과를 모두 더해 현재 스탯을 새로 계산, 아이템 장착 여부 확인
IsEquipped(ItemData item) : 장착 중인지 체크, 장착 아이템이 더해주는 추가 능력치 합산
GetAddStatus(EquipableType type) : 특정 타입의 아이템 효과 합계 반환

---
