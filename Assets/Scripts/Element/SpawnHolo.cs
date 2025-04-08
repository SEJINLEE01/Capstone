using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHolo : MonoBehaviour
{
    public GameObject Holo;
    public Transform HandTransform;
    private GameObject holo;
    private Vector3 v;
    void Awake(){
        v = new Vector3(1,0,0);
        holo=Instantiate(Holo, HandTransform.position + v, Quaternion.identity);
        holo.SetActive(false);
    }
    public void Spawn(){
        if (holo.activeSelf) {  holo.SetActive(false); }
        else { holo.SetActive(true); }
    }
}
