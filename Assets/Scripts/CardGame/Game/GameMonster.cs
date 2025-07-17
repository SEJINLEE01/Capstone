using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMonster : MonoBehaviour
{
    protected int molecular_mass; // 분자량(체력)
    protected int cohesion; // 결합력(공격력)
    protected int attack_turn; // 공격까지 몇턴 기다리는가
    protected int turn; // 지난 턴수

    // + 공통되는 함수

    public void Attack(){
        GameManager.Instance.Hp = GameManager.Instance.Hp - cohesion;
    }

    public void AddTurn(){
        turn++;
    }
    public void ResetAttackTurn(){
        turn = 0;
    }

    public bool CheckAttackTurn(){
        return (attack_turn == turn);
    }
}
