using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_ionic_molcule : MonoBehaviour
{
    [HideInInspector]
    public bool isActive = false;
    public GameObject molcule;

    Molcule_Ionic_Trigger trigger;
    private float elapsedTime = 0f; // 경과 시간
    private float duration = 1.5f; // 이동 시간 

    private void Start()
    {
        trigger = GetComponent<Molcule_Ionic_Trigger>();
    }
    void Update()
    {
        if (isActive)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > duration)
            {
                trigger.enabled = false;
                foreach (GameObject atom in trigger.EnterAtom)
                {
                    Destroy(atom);
                }
                foreach (GameObject atom in trigger.Atom)
                {
                    Destroy(atom);
                }
                Instantiate(molcule, transform.position + new Vector3(0, 0.5f, 0), Quaternion.Euler(0, 90f, 0));
                GetComponent<eMove_Trigger>().enabled = false;
                GetComponent<Make_ionic_molcule>().enabled = false;
                GetComponent<After_Generator>().enabled = true;
            }
        }
    }
}
