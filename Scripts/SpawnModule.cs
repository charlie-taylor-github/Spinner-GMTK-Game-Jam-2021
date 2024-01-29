using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModule : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    int spawnTimes = 0;

    int rarity;

    void Awake()
    {
        StartCoroutine("waitToSpawn");
    }

    void Update()
    {
    }

    IEnumerator waitToSpawn()
    {
        spawnEnemies(spawnTimes);
        spawnTimes += 1;
        yield return new WaitForSeconds(60);
        StartCoroutine("waitToSpawn");

    }

    void spawnEnemies(int cycles)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            rarity = (5 * cycles) + 5;

            int rand = Random.Range(0, rarity + 1);
            if (rand == 0)
            {
                
                Vector2 pos = spawnPoints[i].position;
                var contactFilter = new ContactFilter2D { };
                var hitResults = new RaycastHit2D[4];
                var hits = Physics2D.CircleCast(pos, 1f, Vector2.zero, contactFilter, hitResults);
                if (hits == 0)
                    Instantiate(enemy, pos, Quaternion.identity);
            }
        }
    }
}
