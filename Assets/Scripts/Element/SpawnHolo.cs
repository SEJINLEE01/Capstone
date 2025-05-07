using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHolo : MonoBehaviour
{
    public GameObject Holo;
    public Transform HandTransform;
    public GameObject Head;
    private GameObject HoloPrefab;

    private void Start()
    {
        HoloPrefab = Instantiate(Holo);
        HoloPrefab.SetActive(false);
    }
    private void Update()
    {
        HoloPrefab.transform.position = HandTransform.position + new Vector3(0, 0.3f, 0);
        HoloPrefab.transform.rotation = Head.transform.rotation;
    }
    public void Spawn(){
        
        if (HoloPrefab.activeSelf) { HoloPrefab.SetActive(false); }
        else { HoloPrefab.SetActive(true); }
    }
}
