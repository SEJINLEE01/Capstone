using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public PlayerMove PM;
    public void ClickButton(){
        
        this.transform.root.gameObject.SetActive(false); //자신의 최상위 부모를 가져온다.
        PM.canMove = true;
    }
}
