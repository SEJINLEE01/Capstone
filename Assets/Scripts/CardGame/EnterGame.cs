using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGame : MonoBehaviour
{
    public OpenGame OG;
    public GameObject GameManager;
    GameObject PlayerPos;
    GameObject GamePos;
    GameObject ManagerPos;
    void Start(){
        PlayerPos = GameObject.Find("Camera Rig");
        GamePos = GameObject.Find("Game Pos");
        ManagerPos = GameObject.Find("Manager Pos");
    }
    public void OnSelect(){
        if(OG.trigger){
            Instantiate(GameManager, ManagerPos.transform.position, Quaternion.identity);
            PlayerPos.transform.position = GamePos.transform.position;
        }
    }
}
