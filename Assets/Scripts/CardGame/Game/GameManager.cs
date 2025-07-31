using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//턴제 카드게임의 총관리 코드
public class GameManager : MonoBehaviour
{
    int turn = 1; //몇 턴인지 확인
    int maxTurn=6; //최대 턴 (엔딩까지 몇턴인가)
    [HideInInspector]
    public int Hp; // 게임에서 사용되는 플레이어 체력
    [HideInInspector]
    public int PHp = 5; // 플레이어의 최대체력
    public GameObject SelectUI; // 공격 or 드로우 선택 UI
    public GameObject AttackUI; // 공격 선택 후, 실제로 공격을 하기위한 UI
    public GameObject DefeatUI; // 패배하고나서 이후의 UI
    public GameObject Canvas; // 카드 뽑을 UI
    private GameObject selectedObject; //선택될 몬스터
    bool Attack = false; //공격버튼을 눌렀을 때
    bool Attacking = false; // 실제로 몬스터를 카드로 공격할 때
    bool Draw = false; // 드로우 버튼을 눌렀을 때

    public MoleculeSpawner Spawner; //몬스터 스폰

    private float lastDrawButtonClickTime = 0f; // 마지막 클릭 시간 저장
    private const float debounceTime = 0.2f; // 0.2초 내의 중복 클릭 무시

    private Dictionary<GameObject, int> Monsters = new Dictionary<GameObject, int>(); // 몬스터가 소환되면 들어갈 딕셔너리 <몬스터, 위치>

    private List<GameObject> SettingCard = new List<GameObject>(); // 카드가 세팅되면 들어갈 리스트

    GameObject pos; // 원래 실험실의 위치
    GameObject PlayerPos; // vr카메라의 위치

    public static GameManager Instance { get; private set; } // 싱글톤
    void Start()
    {   
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        selectedObject = null; // 처음에 아무 몬스터도 선택되지않음을 표시
        Hp = PHp;
        PlayerPos = GameObject.Find("Camera Rig");
        pos = GameObject.Find("Lab Pos");
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop(){
        yield return new WaitForSeconds(1.0f); // 일단 스포너 기다리기 위해서 임시로 넣어놓음 튜토리얼추가되면 제거예정 
        
        Canvas.SetActive(true);
        for (int i=0;i<maxTurn;i++){ 
            SelectUI.SetActive(true);
            AttackUI.SetActive(false);
            DefeatUI.SetActive(false);
            Attack = false; // 매턴이 지나면 bool변수 모두 초기화
            Attacking = false;
            Draw = false;

            //몬스터 소환
            (GameObject spawnedMonster, int? spawnedPosition) = Spawner.SpawnMonster();
            if (spawnedMonster != null && spawnedPosition.HasValue)
                Monsters.Add(spawnedMonster, spawnedPosition.Value);

            Debug.Log("게임이 시작되었습니다 턴" + turn);
            yield return new WaitUntil(() => Attack || Draw);
            SelectUI.SetActive(false);
            if(AttackUI.activeSelf){
                Debug.Log("공격을 시도합니다.");
                //어떤 몬스터를 선택해서 공격할지
                yield return new WaitUntil(() => Attacking);
                AttackUI.SetActive(false);
            }

            Debug.Log("몬스터의 턴이 시작됩니다"); 
            foreach(GameObject monster in Monsters.Keys){ //공격할 턴이 된 몬스터들은 공격을 시도
                GameMonster monsterScript = monster.GetComponent<GameMonster>();
                monsterScript.AddTurn();
                if(monsterScript.CheckAttackTurn()){
                    monsterScript.Attack();
                    
                    HP_Update.Instance.UpdateHeartUI(Hp); // Hp UI업데이트

                    if (Hp<=0){
                        DefeatProcess();
                        yield break;
                    }
                    
                    monsterScript.ResetAttackTurn();
                }
            }
    
            yield return new WaitForSeconds(1f);
            Debug.Log("모든 턴이 끝났습니다.");
            turn++;
        }
         Debug.Log("게임이 종료되었습니다.");
    }
    
    void Initialize() // 게임을 완전히 다시리셋
    {
        ClearScene();

        Spawner.InitialSpawnMonster(); // 몬스터스포너 초기화(다시 새로운 몬스터를 추가하도록)
        SpawnAnimateCard.AnimateCard.ReInitialize(); // 덱초기화
        MyDraw.Instance.InitializeDeck(); // 드로우매니저 초기화

        selectedObject = null; // 처음에 아무 몬스터도 선택되지않음을 표시
        Hp = PHp; // 체력 초기화
        turn = 1; // 턴 초기화

        SelectUI.SetActive(false);
        AttackUI.SetActive(false);
        DefeatUI.SetActive(false);
        Attack = false; // 매턴이 지나면 bool변수 모두 초기화
        Attacking = false;
        Draw = false;
    }

    void ClearScene()
    {
        if (SettingCard.Count > 0)
        {
            for (int i = 0; i < SettingCard.Count; i++)
                Destroy(SettingCard[i]); // 씬에 남아있는 오브젝트 파괴
        }
        SettingCard.Clear(); // 코드상에서 남아있는 카드 없애기

        if (Monsters.Count > 0)
        {
            List<GameObject> SceneObject = new List<GameObject>(Monsters.Keys); // 딕셔너리에 있는 오브젝트를 안전하게 제거
            for (int i = 0; i < SceneObject.Count; i++)
                Destroy(SceneObject[i]);
        }
        Monsters.Clear(); // 코드상에 있는 몬스터 없애기

        MyDraw.Instance.DestroySceneCard();
    }
    void DefeatProcess(){ // 몬스터한테 죽었을 경우 실행될 프로세스
        Debug.Log("사망하였습니다"); // 여기서 돌아갈지 다시시작할건지를 나타내는 UI를 띄우는 로직
        DefeatUI.SetActive(true);
    }

    public void AttackButton(){ // 어택버튼을 눌렀을 때
        AttackUI.SetActive(true); // 공격로직이 들어가야함, 카드를 놓고 인식하기 까지의 과정
        Attack = true;
    }

    public void AttackingButton(){ // 카드세팅 후 실질적인 공격
        if (SettingCard.Count == 0 || selectedObject == null) //카드를 세팅하지않았다면 공격버튼을 눌러도 공격이 나가지않도록 or 몬스터를 선택하지않았다면
            return;
        
        if (Time.time - lastDrawButtonClickTime < debounceTime) //무슨 버그인지 모르겠지만 얘만 두번씩 실행되서 임의로 막음
        {
            //Debug.Log("DrawButton: 디바운스 처리됨 (중복 클릭 무시)"); 
            return;
        }

        lastDrawButtonClickTime = Time.time; // 현재 시간으로 마지막 클릭 시간 업데이트

        GameMonster Gms = selectedObject.GetComponent<GameMonster>();

        int attack = 0; // 세팅된 카드들의 공격력 합

        if (CombineManage.combineManage.CheckPossibleCombinations(SettingCard))
        {
            Debug.Log($"  - <color=yellow>카드가 조합되었습니다.</color>)");
            foreach (GameObject Card in SettingCard) // 순회가 도는동안 파괴가 되면 오류가나서 파괴와 계산을 분리
            {
                attack += Card.GetComponent<GameCard>().CalculateCombinedAttackPower();
            }
            foreach (GameObject DestroyCard in SettingCard.ToList())
            {
                Destroy(DestroyCard);
            }
            SettingCard.Clear();
        }
        else
        {
            Debug.Log($"  - <color=yellow>카드가 조합되지않고 그냥 공격합니다.</color>)");
            foreach (GameObject Card in SettingCard) // 순회가 도는동안 파괴가 되면 오류가나서 파괴와 계산을 분리
            {
                attack += Card.GetComponent<GameCard>().CalculateAttackPower();
            }
            foreach (GameObject DestroyCard in SettingCard.ToList())
            {
                Destroy(DestroyCard);
            }
            SettingCard.Clear();
        }

        Gms.Attacked(attack);
        Gms.isDie();
        SettingCard.Clear();
        Attacking = true;
    }

    public void DrawButton(){ // 드로우 버튼을 눌렀을 때
        if (Time.time - lastDrawButtonClickTime < debounceTime) //무슨 버그인지 모르겠지만 얘만 두번씩 실행되서 임의로 막음
        {
            //Debug.Log("DrawButton: 디바운스 처리됨 (중복 클릭 무시)"); 
            return;
        }

        lastDrawButtonClickTime = Time.time; // 현재 시간으로 마지막 클릭 시간 업데이트

        Debug.Log("드로우를 합니다."); // 드로우 로직이 들어가야함
        for(int i = 0; i < 5; i++)
        {
            MyDraw.Instance.Draw();
        }

        Draw = true;
    }

    public void ReStartButton(){ //다시시작

        Initialize();
        StartCoroutine(GameLoop());
        Debug.Log("게임을 다시 시작합니다");
    }
    
    public void EndButton(){ // 종료버튼
        Debug.Log("종료");
        ClearScene();
        PlayerPos.transform.position = pos.transform.position;
        Destroy(gameObject);
        //추가되어야할것 게임과 관련된 모든 오브젝트를 전부 없앤다.
    }

    public void SetSelectedObject(GameObject obj) //선택된 오브젝트
    {
        if (selectedObject != null && selectedObject != obj)
        {
            MonsterSelect prevSelect = selectedObject.GetComponent<MonsterSelect>();
            if (prevSelect != null)
                prevSelect.selectedImg.SetActive(false); // 이전 선택된 몬스터의 이미지 끄기
        }
        selectedObject = obj; // 해당 몬스터가 선택됨
        Debug.Log(selectedObject.gameObject.name);
    }

    public void MonsterDie(GameObject monster) //몬스터가 죽었을때
    {
        Spawner.isSpawned[Monsters[monster]] = false;
        Monsters.Remove(monster);
    }

    public void AddCard(GameObject card) //카드가 세팅됐을때 추가하는 로직
    {
        SettingCard.Add(card);
    }

    public void RemoveCard(GameObject card) //카드 세팅빠졌을때 제거
    {
        SettingCard.Remove(card);
    }
}
