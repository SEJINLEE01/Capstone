using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public GameObject[] Smokes;
    Vector3 initialScale;
    Vector3 zScale;
    float shrinkDuration = 3f;
    private void Start()
    {
        initialScale = Smokes[0].transform.localScale;
        zScale = new Vector3(Smokes[0].transform.localScale.x, Smokes[0].transform.localScale.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("element"))
        {
            StartCoroutine(ActiveSmoke());
        }
    }

    IEnumerator ActiveSmoke()
    {
        foreach (GameObject item in Smokes)
        {   
            item.transform.localScale = initialScale;
            item.SetActive(true);
        }

        yield return new WaitForSeconds(8f);
        float timer = 0f; // �ð� ������ ���� Ÿ�̸�
        while (timer < shrinkDuration)
        {
            // ��� �ð� ���� ��� (0���� 1����)
            float t = timer / shrinkDuration;

            // Lerp �Լ��� ����Ͽ� �������� ���������� ����
            // initialScale���� Vector3.zero (0,0,0)���� t ���� ���� ��ȭ
            
            Smokes[0].transform.localScale = Vector3.Lerp(initialScale, zScale, t);
            Smokes[1].transform.localScale = Vector3.Lerp(initialScale, zScale, t);
            Smokes[2].transform.localScale = Vector3.Lerp(initialScale, zScale, t);

            timer += Time.deltaTime; // ���� ������ �ð���ŭ Ÿ�̸� ����
            yield return null; // ���� �����ӱ��� ��ٸ�
        }
        yield return new WaitForSeconds(1f);
        foreach (GameObject item in Smokes)
        {
            item.SetActive(false);
        }
    }
}
