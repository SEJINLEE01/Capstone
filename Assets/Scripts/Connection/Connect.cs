using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviour
{
    public GameObject Effect;
    public GameObject isEffect;
    bool isSpawn = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ar"&&!isSpawn)
        {
            isEffect = Instantiate(Effect, collision.transform.position, collision.transform.rotation);
            isSpawn = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Destroy(isEffect);
        isSpawn = false;
    }
}
