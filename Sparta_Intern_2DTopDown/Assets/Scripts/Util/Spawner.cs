using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        timer = 0f;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 1f)
        {
            Spawn();
            timer = 0f;
        }
    }

    private void Spawn()
    {
        int rand = Random.Range(0, GameManager.Instance.pool.prefabs.Length);
        GameObject monster = GameManager.Instance.pool.Get(rand);

        if(monster != null)
        {
            monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        }
    }
}
