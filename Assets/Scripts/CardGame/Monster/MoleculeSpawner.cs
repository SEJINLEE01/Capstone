using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeSpawner : MonoBehaviour
{
    public GameObject[] SmallMolcule; // ��������
    public GameObject[] MiddleMolcule; // �߰�����
    public GameObject[] LargeMolcule; // ū����

    // ���ڰ� ��ȯ�� �� �ִ� ��ġ�� (Transform �迭�� ���� ��ġ ��� ����)
    public Transform[] spawnPoints;
    [HideInInspector]
    public bool[] isSpawned;
    public int S, M, L; // inspector���� ��ȯ�ϴ� ���ͼ��� ���� �� �ְ�
    
    private Queue<GameObject> Monsters = new Queue<GameObject>();
    private void Start()
    {
        isSpawned = new bool[spawnPoints.Length];
        for(int i=0;i<isSpawned.Length;i++)
            isSpawned[i] = false;

        for (int i = 0; i < S; i++)
        {
            SpawnSmall();
        }
        for (int i = 0; i < M; i++)
        {
            SpawnMiddle();
        }
        for (int i = 0; i < L; i++)
        {
            SpawnLarge();
        }
    }
    public void InitialSpawnMonster()
    {
        Monsters.Clear(); // ���Ͱ� ����ִ� ť �ʱ�ȭ
        for (int i = 0; i < isSpawned.Length; i++) // ��ġ �ʱ�ȭ
            isSpawned[i] = false;

        for (int i = 0; i < S; i++)
        {
            SpawnSmall();
        }
        for (int i = 0; i < M; i++)
        {
            SpawnMiddle();
        }
        for (int i = 0; i < L; i++)
        {
            SpawnLarge();
        }
    }

    private void SpawnSmall() // �������� ���͸� ��ȯ�ϴ� ����
    {
        int i = Random.Range(0, SmallMolcule.Length);
        Monsters.Enqueue(SmallMolcule[i]);
    }

    private void SpawnMiddle() // �߰����� ���͸� ��ȯ�ϴ� ����
    {
        int i = Random.Range(0, MiddleMolcule.Length);
        Monsters.Enqueue(MiddleMolcule[i]);
    }

    private void SpawnLarge() // ū���� ���͸� ��ȯ�ϴ� ����
    {
        int i = Random.Range(0, LargeMolcule.Length);
        Monsters.Enqueue(LargeMolcule[i]);
    }

    private bool AreAllSpawnPointsOccupied() //�ڸ��� �����ִ°� Ȯ��
    {
        foreach (bool value in isSpawned)
        {
            if (!value) // �ϳ��� false(����ִ� �ڸ�)�� ������
            {
                return false; // ��� �ڸ��� �� ���� �ʾ���
            }
        }
        return true; // ������ ��������� ��� �ڸ��� �� á��
    }

    public (GameObject monster,int? SpawnPos) SpawnMonster()
    {
        Debug.Log("���Ͱ� ������");
        if (Monsters.Count == 0)
            return (null,null);
        Debug.Log("���Ͱ� 0�������ƴ�");
        if (AreAllSpawnPointsOccupied())
        {
            Debug.Log("��� ���� �ڸ��� �� ���� ���͸� �� �̻� ������ �� �����ϴ�.");
            return (null, null); // �ڸ��� �� á���Ƿ� ��ȯ
        }

        Debug.Log("���Ͱ� ����22��");
        int i;

        do
        {
            i = Random.Range(0, spawnPoints.Length);
        } while (isSpawned[i]); //�� �ڸ��� ������ �Ǿ��ִٸ� �ٽ� �ڸ� ����

        GameObject monster = Instantiate(Monsters.Dequeue(), spawnPoints[i].position, Quaternion.identity);
        isSpawned[i] = true;
        return (monster, i);
    }

    public bool isEmpty()
    {
        return Monsters.Count == 0;
    }
}
