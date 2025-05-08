using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class Make_Molcule : MonoBehaviour
{
    public GameObject[] electrons;
    int count = 0;
    public Molcule_Trigger trigger;
    public GameObject molcule;

    private float elapsedTime = 0f; // 경과 시간
    private float duration = 1f; // 이동 시간 (1초)
    private void Update()
    {
        count = 0;
        foreach (GameObject electron in electrons)
        { 
            if (!electron.GetComponent<cshRotate>().enabled)
            {
                count++;
            }
        }

        if (count == electrons.Length)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > duration)
            {
                GetComponent<Molcule_Trigger>().enabled = false;
                foreach (GameObject atom in trigger.EnterAtom)
                {
                    Destroy(atom);
                }
                foreach (GameObject atom in trigger.Atom)
                {
                    Destroy(atom);
                }
                Instantiate(molcule, transform.position + new Vector3(0, 0.01f, 0), Quaternion.Euler(0, 90f, 0));
                GetComponent<Make_Molcule>().enabled = false;
            }
        }
    }
}
