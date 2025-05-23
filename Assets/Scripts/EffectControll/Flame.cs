using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public GameObject frame;
    public GameObject explore;
    float destroyDelay = 3f;   // 몇 초 뒤에 파괴할지
    bool trigger = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (trigger)
            return;

        if (collision.gameObject.name.Contains("element"))
        {
            Destroy(collision.gameObject);
            trigger = true;
            GameObject f = Instantiate(frame, transform.position, Quaternion.identity*Quaternion.Euler(-90f,0f,0f));
            f.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            StartCoroutine(effectSpawn(f));
        }
    }
    IEnumerator effectSpawn(GameObject f)
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(f);
        gameObject.SetActive(false);
        GameObject e1 = Instantiate(explore, transform.position, Quaternion.identity);
        GameObject e2 = Instantiate(explore, transform.position, Quaternion.identity * Quaternion.Euler(270f, 0f, 0f));
        Destroy(e1,1.5f);
        Destroy(e2, 1.5f);
    }
}
