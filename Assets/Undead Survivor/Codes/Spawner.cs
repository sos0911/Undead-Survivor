using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private Transform[] SpawnPointArray;
    private float       Timer;
    public  float       SpawnPeriod     = 0.2f;

    private void Awake()
    {
        SpawnPointArray = GetComponentsInChildren< Transform >();
    }

    // Update is called once per frame
    private void Update()
    {
        Timer += Time.deltaTime;

        if ( Timer > SpawnPeriod )
        {
            Spawn();
            Timer = 0.0f;
        }
    }

    // 몬스터를 스폰한다.
    private void Spawn()
    {
        GameObject enemy = GameManager.Instance.Pool.Get( Random.Range( 0, GameManager.Instance.Pool.GetPoolsSize() ) );
        enemy.transform.position = SpawnPointArray[ Random.Range( 1, SpawnPointArray.Length ) ].position;
    }
}
