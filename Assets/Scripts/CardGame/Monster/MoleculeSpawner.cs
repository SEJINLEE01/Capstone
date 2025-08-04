using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeSpawner : MonoBehaviour
{
    public GameObject[] SmallMolcule; // 작은분자
    public GameObject[] MiddleMolcule; // 중간분자
    public GameObject[] LargeMolcule; // 큰분자

    // 분자가 소환될 수 있는 위치들 (Transform 배열로 여러 위치 등록 가능)
    public Transform[] spawnPoints;
    [HideInInspector]
    public bool[] isSpawned;
    public int S, M, L; // inspector에서 소환하는 몬스터수를 정할 수 있게
    
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
        Monsters.Clear(); // 몬스터가 들어있던 큐 초기화
        for (int i = 0; i < isSpawned.Length; i++) // 위치 초기화
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

    private void SpawnSmall() // 작은분자 몬스터를 소환하는 로직
    {
        int i = Random.Range(0, SmallMolcule.Length);
        Monsters.Enqueue(SmallMolcule[i]);
    }

    private void SpawnMiddle() // 중간분자 몬스터를 소환하는 로직
    {
        int i = Random.Range(0, MiddleMolcule.Length);
        Monsters.Enqueue(MiddleMolcule[i]);
    }

    private void SpawnLarge() // 큰분자 몬스터를 소환하는 로직
    {
        int i = Random.Range(0, LargeMolcule.Length);
        Monsters.Enqueue(LargeMolcule[i]);
    }

    private bool AreAllSpawnPointsOccupied() //자리가 꽉차있는가 확인
    {
        foreach (bool value in isSpawned)
        {
            if (!value) // 하나라도 false(비어있는 자리)가 있으면
            {
                return false; // 모든 자리가 꽉 차지 않았음
            }
        }
        return true; // 루프를 통과했으면 모든 자리가 꽉 찼음
    }

    public (GameObject monster,int? SpawnPos) SpawnMonster()
    {
        Debug.Log("몬스터가 스폰됨");
        if (Monsters.Count == 0)
            return (null,null);
        Debug.Log("몬스터가 0마리가아님");
        if (AreAllSpawnPointsOccupied())
        {
            Debug.Log("모든 스폰 자리가 꽉 차서 몬스터를 더 이상 스폰할 수 없습니다.");
            return (null, null); // 자리가 꽉 찼으므로 반환
        }

        Debug.Log("몬스터가 스폰22됨");
        int i;

        do
        {
            i = Random.Range(0, spawnPoints.Length);
        } while (isSpawned[i]); //그 자리에 스폰이 되어있다면 다시 자리 뽑음

        GameObject monster = Instantiate(Monsters.Dequeue(), spawnPoints[i].position, Quaternion.identity);
        isSpawned[i] = true;
        return (monster, i);
    }

    public bool isEmpty()
    {
        return Monsters.Count == 0;
    }
}
