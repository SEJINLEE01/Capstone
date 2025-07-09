using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowExplain : MonoBehaviour
{
    public GameObject explain;
    public GameObject SpawnPoint;
    ExplainManager EM;
    
    void Start(){
        EM = GameObject.Find("ExplainManager").GetComponent<ExplainManager>();
    }
    public void Show(){
        if(EM.Showing()){
            EM.ExplainInstance = Instantiate(explain,SpawnPoint.transform.position,SpawnPoint.transform.rotation * Quaternion.Euler(0,180,0));
        }
    }
}
