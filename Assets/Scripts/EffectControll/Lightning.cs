using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Lightning : MonoBehaviour
{
    public GameObject lightning;
    float shrinkDuration = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("element"))
        {
            Destroy(collision.gameObject);
           
            GameObject l = Instantiate(lightning, transform.position + new Vector3(0f,0.5f,0f), Quaternion.identity);
            l.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Destroy(l, shrinkDuration+1f);
            StartCoroutine(ChangeScale(l));
        }
    }

    IEnumerator ChangeScale(GameObject l)
    {
        Vector3 initialScale = l.transform.localScale;
        float timer = 0f;
        while (timer < shrinkDuration)
        {
            // ��� �ð� ���� ��� (0���� 1����)
            float t = timer / shrinkDuration;

            // Lerp �Լ��� ����Ͽ� �������� ���������� ����
            // initialScale���� Vector3.zero (0,0,0)���� t ���� ���� ��ȭ
            l.transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, t);

            timer += Time.deltaTime; // ���� ������ �ð���ŭ Ÿ�̸� ����
            yield return null; // ���� �����ӱ��� ��ٸ�
        }
    }
}
