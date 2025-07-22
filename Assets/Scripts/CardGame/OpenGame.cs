using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OpenGame : MonoBehaviour
{
    public GameObject[] Card;
    public GameObject[] SpawnPoint;

    [HideInInspector]
    public bool trigger=false;
    List<string> tagList = new List<string>
    {
        "H2","F2","N2","O2","SiO2","NH3","H2O","HCl","CO2","AlCl3","CH4","Cl2","CaF2","LiCl","MgO","NaCl","NaF"
    };
    enum CardType{
        H2,F2,N2,O2,SiO2,NH3,H2O,HCl,CO2,AlCl3,CH4,Cl2,CaF2,LiCl,MgO,NaCl,NaF
    };
    int SpawnNum = 0;

    void OnCollisionEnter(Collision collision){
        if(SpawnNum>=5) //5개까지만 넣을 수 있게
            return;

        if(collision.gameObject.layer==LayerMask.NameToLayer("Molcule")){
            string ObjectTag = collision.gameObject.tag;
            if (tagList.Contains(ObjectTag)) //리스트에 있는 태그가 있다면
            {
                
                CardType cardToSpawn =(CardType)Enum.Parse(typeof(CardType), ObjectTag);

                Destroy(collision.gameObject);  //충돌한 오브젝트 삭제
                tagList.Remove(ObjectTag); //리스트에서 제거
                Instantiate(Card[(int)cardToSpawn],SpawnPoint[SpawnNum].transform); //해당 태그의 카드소환
                SpawnNum++; //넣은 개수 표기
            }
        }
        
        if(SpawnNum==5)
            trigger=true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q)) trigger = true;
    }
}
