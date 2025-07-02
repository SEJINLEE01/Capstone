using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    public float moveSpeed = 0.8f; 
    public float stopZ = 2.0f;
    public float tutorialZ;
    public GameObject Center;
    public GameObject[] tutorial;

    [HideInInspector] 
    public bool canMove = true;
    private bool tt1 = false;
    void Update(){
        if(canMove){
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            
            if(transform.position.z<=tutorialZ && !tt1){
                tutorial[0].transform.position = Center.transform.position - new Vector3(-0.1f,0f,0.7f);
                tutorial[0].SetActive(true);
                canMove = false;
                tt1=true;
            }

            if(transform.position.z<=stopZ)
                this.enabled = false;


            
        }
    }
}
