using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public abstract class GameMonster : MonoBehaviour
{
    protected int molecular_mass; // 분자량(체력)
    protected int MaxHp; //체력바를 위한 변수
    protected int cohesion; // 결합력(공격력)
    protected int attack_turn; // 공격까지 몇턴 기다리는가
    protected int turn; // 지난 턴수
    protected int turnUI;
    public Image HPimg;
    public TextMeshProUGUI Hptxt;


    // + 공통되는 함수
    public void Attack(){
        GameManager.Instance.Hp = GameManager.Instance.Hp - cohesion;
    }
    
    public void Attacked(int molecular) //카드들의 원자량합을 공격으로 받음
    {
        molecular_mass -= molecular;
        Debug.Log("남은 체력은 :" + molecular_mass);
        HPimg.fillAmount = molecular_mass * 1.0f / MaxHp;
        Hptxt.text = molecular_mass + "/" + MaxHp;
    }

    public void AddTurn(){
        turn++;
        turnUI--;
    }
    public void ResetAttackTurn(){
        turn = 0;
        turnUI = attack_turn;
    }

    public bool CheckAttackTurn(){
        return (attack_turn == turn);
    }

    public void isDie()
    {
        if (molecular_mass <= 0)
        {
            GameManager.Instance.MonsterDie(this.gameObject);
            Destroy(gameObject);
        }
    }
}
