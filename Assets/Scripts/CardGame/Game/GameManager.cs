using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//턴제 카드게임의 총관리 코드
public class GameManager : MonoBehaviour
{
    int turn = 1; //몇 턴인지 확인
    int maxTurn=10; //최대 턴 (엔딩까지 몇턴인가)
    [HideInInspector]
    public int Hp; // 게임에서 사용되는 플레이어 체력
    int PHp = 3; // 플레이어의 최대체력
    public GameObject SelectUI; // 공격 or 드로우 선택 UI
    public GameObject AttackUI; // 공격 선택 후, 실제로 공격을 하기위한 UI
    public GameObject DefeatUI; // 패배하고나서 이후의 UI
    private GameObject selectedObject; //선택될 몬스터
    bool Attack = false; //공격버튼을 눌렀을 때
    bool Attacking = false; // 실제로 몬스터를 카드로 공격할 때
    bool Draw = false; // 드로우 버튼을 눌렀을 때

    public MyDraw mydraw; //드로우

    private float lastDrawButtonClickTime = 0f; // 마지막 클릭 시간 저장
    private const float debounceTime = 0.2f; // 0.2초 내의 중복 클릭 무시

    public List<GameObject> Monsters = new List<GameObject>(); // 몬스터를 관리하는 리스트 사실상 사용하는 것은 오브젝트의 GameMonster스크립트가 될거임 (임시로 public)
    GameObject pos; // 원래 실험실의 위치
    GameObject PlayerPos; // vr카메라의 위치

    public static GameManager Instance { get; private set; } // 싱글톤
    void Start()
    {   
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Hp = PHp;
        PlayerPos = GameObject.Find("Camera Rig");
        pos = GameObject.Find("Lab Pos");
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop(){
        for(int i=0;i<maxTurn;i++){ 
            SelectUI.SetActive(true);
            AttackUI.SetActive(false);
            DefeatUI.SetActive(false);
            Attack = false; // 매턴이 지나면 bool변수 모두 초기화
            Attacking = false;
            Draw = false;
            
            //몬스터 소환


            Debug.Log("게임이 시작되었습니다 턴" + turn);
            yield return new WaitUntil(() => Attack || Draw);
            SelectUI.SetActive(false);
            if(AttackUI.activeSelf){
                Debug.Log("공격을 시도합니다.");
                //어떤 몬스터를 선택해서 공격할지
                yield return new WaitUntil(() => Attacking);
                AttackUI.SetActive(false);
            }

            Debug.Log("몬스터의 턴이 시작됩니다"); // 몬스터들의 몇턴뒤 공격하고 그런로직이 들어가야함
            // 여기에다가 몬스터들의 턴관리 로직이 들어가야함
            foreach(GameObject monster in Monsters){ //공격할 턴이 된 몬스터들은 공격을 시도
                GameMonster monsterScript = monster.GetComponent<GameMonster>();
                monsterScript.AddTurn();
                if(monsterScript.CheckAttackTurn()){
                    monsterScript.Attack();
                    Debug.Log("남은체력 : " + Hp); 
                    if(Hp<=0){
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
    void DefeatProcess(){ // 몬스터한테 죽었을 경우 실행될 프로세스
        Debug.Log("사망하였습니다"); // 여기서 돌아갈지 다시시작할건지를 나타내는 UI를 띄우는 로직
        DefeatUI.SetActive(true);
    }

    public void AttackButton(){ // 어택버튼을 눌렀을 때
        AttackUI.SetActive(true); // 공격로직이 들어가야함, 카드를 놓고 인식하기 까지의 과정
        Attack = true;
    }

    public void AttackingButton(){ // 카드세팅 후 실질적인 공격
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
        mydraw.Draw();
        mydraw.PrintRemainingDeck();
        Draw = true;
    }

    public void ReStartButton(){
        turn = 1; // 턴 초기화
        Hp = PHp; // Hp초기화
        StartCoroutine(GameLoop());
        Debug.Log("게임을 다시 시작합니다");
    }
    
    public void EndButton(){
        Debug.Log("종료");
        PlayerPos.transform.position = pos.transform.position;
        Destroy(gameObject);
    }

    public void SetSelectedObject(GameObject obj) //선택된 오브젝트
    {
        selectedObject = obj; // 여기서 선택됐을때 로직 짜면 될듯
        Debug.Log("선택된 오브젝트: " + obj.name);
    }
}
