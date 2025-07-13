using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//턴제 카드게임의 총관리 코드
public class GameManager : MonoBehaviour
{
    int turn = 1; //몇 턴인지 확인
    int maxTurn=10; //최대 턴 (엔딩까지 몇턴인가)
    int Hp = 3; //플레이어 체력

    bool Attack = false; //공격버튼을 눌렀을 때
    bool Draw = false; // 드로우 버튼을 눌렀을 때
    void Start()
    {   
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop(){
        for(int i=0;i<maxTurn;i++){ 
            Attack = false;
            Draw = false;
            Debug.Log("게임이 시작되었습니다 턴" + turn);
            yield return new WaitUntil(() => Attack || Draw);
            Debug.Log("몬스터의 턴이 시작됩니다"); // 몬스터들의 몇턴뒤 공격하고 그런로직이 들어가야함
            if(Hit()){ // 여기에다가 몬스터들의 턴관리 로직이 들어가야함
                DieGameProcess();
                yield break;
            }
            yield return new WaitForSeconds(1f);
            Debug.Log("모든 턴이 끝났습니다.");
            turn++;
        }
         Debug.Log("게임이 종료되었습니다.");
    }
    void DieGameProcess(){ // 몬스터한테 죽었을 경우 실행될 프로세스
        Debug.Log("사망하였습니다"); // 여기서 돌아갈지 다시시작할건지를 나타내는 UI를 띄우는 로직
        Destroy(gameObject);
    }

    bool Hit(){
        Debug.Log("공격을 당했습니다.");
        Hp--; // 몬스터의 공격력과 연계되는 함수가 들어와야함
        if(Hp<=0)
            return true;

        return false;
    }

    public void AttackButton(){ // 어택버튼을 눌렀을 때
            Debug.Log("공격을 실행합니다."); // 공격로직이 들어가야함, 카드를 놓고 인식하기 까지의 과정
            Attack = true;
    }

    public void DrawButton(){ // 드로우 버튼을 눌렀을 때
            Debug.Log("드로우를 합니다."); // 드로우 로직이 들어가야함
            Draw = true;
    }
}
