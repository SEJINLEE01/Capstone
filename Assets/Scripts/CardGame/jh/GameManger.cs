using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManger : MonoBehaviour
{
    public Image HPimg;
    public float MaxHP = 100f;
    public float HP;
    public float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cardselect()
    {
        HP -= damage;
        HPimg.fillAmount = HP/MaxHP;
    }


}
