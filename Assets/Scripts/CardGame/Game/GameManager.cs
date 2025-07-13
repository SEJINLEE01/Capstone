using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//턴제 카드게임의 총관리 코드
public class GameManager : MonoBehaviour
{
    int turn = 1; //몇 턴인지 확인
    int maxTurn=10; //최대 턴 (엔딩까지 몇턴인가)
    int Hp; // 게임에서 사용되는 플레이어 체력
    int PHp = 3; // 플레이어의 최대체력
    public GameObject SelectUI; // 공격 or 드로우 선택 UI
    public GameObject AttackUI; // 공격 선택 후, 실제로 공격을 하기위한 UI
    public GameObject DefeatUI; // 패배하고나서 이후의 UI

    bool Attack = false; //공격버튼을 눌렀을 때
    bool Attacking = false; // 실제로 몬스터를 카드로 공격할 때
    bool Draw = false; // 드로우 버튼을 눌렀을 때
    
    GameObject pos; // 원래 실험실의 위치
    GameObject PlayerPos; // vr카메라의 위치
    void Start()
    {   
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
            
            Debug.Log("게임이 시작되었습니다 턴" + turn);
            yield return new WaitUntil(() => Attack || Draw);
            SelectUI.SetActive(false);
            if(AttackUI.activeSelf){
                Debug.Log("공격을 시도합니다.");
                yield return new WaitUntil(() => Attacking);
                AttackUI.SetActive(false);
            }
            Debug.Log("몬스터의 턴이 시작됩니다"); // 몬스터들의 몇턴뒤 공격하고 그런로직이 들어가야함
            if(Hit()){ // 여기에다가 몬스터들의 턴관리 로직이 들어가야함
                DefeatProcess();
                yield break;
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

    bool Hit(){
        Debug.Log("공격을 당했습니다.");
        Hp--; // 몬스터의 공격력과 연계되는 함수가 들어와야함
        if(Hp<=0)
            return true;

        return false;
    }

    public void AttackButton(){ // 어택버튼을 눌렀을 때
        AttackUI.SetActive(true); // 공격로직이 들어가야함, 카드를 놓고 인식하기 까지의 과정
        Attack = true;
    }

    public void AttackingButton(){ // 카드세팅 후 실질적인 공격
        Attacking = true;
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

    public void DrawButton(){ // 드로우 버튼을 눌렀을 때
        Debug.Log("드로우를 합니다."); // 드로우 로직이 들어가야함
        Draw = true;
    }
}
