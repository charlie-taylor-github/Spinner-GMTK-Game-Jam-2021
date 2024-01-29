using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    bool isSpawning;
    Vector2 playerPos;

    Vector2 recentModule;
    Vector2 recentModuleR = new Vector2(0, 0);
    Vector2 recentModuleL = new Vector2(0, 0);
    Vector2 recentModuleT = new Vector2(0, 0);
    Vector2 recentModuleB = new Vector2(0, 0);

    public GameObject spawnModule;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 tempPos = transform.position;

        Spawn27by27(new Vector2(tempPos.x - 180, tempPos.y - 180)); // BL
        Spawn27by27(new Vector2(tempPos.x, tempPos.y - 180)); // BC
        Spawn27by27(new Vector2(tempPos.x + 180, tempPos.y - 180)); // BR

        Spawn27by27(new Vector2(tempPos.x - 180, tempPos.y)); // CL
        Spawn27by27(new Vector2(tempPos.x, tempPos.y)); // CC
        Spawn27by27(new Vector2(tempPos.x + 180, tempPos.y)); // CR

        Spawn27by27(new Vector2(tempPos.x - 180, tempPos.y + 180)); // TL
        Spawn27by27(new Vector2(tempPos.x, tempPos.y + 180)); // TC
        Spawn27by27(new Vector2(tempPos.x + 180, tempPos.y + 180)); // TR
    }

    // Update is called once per frame
    void Update()
    {

    }



    void Spawn9by9(Vector2 pos)
    {
        recentModule = pos;
        Instantiate(spawnModule, new Vector2(pos.x - 20, pos.y - 20), Quaternion.identity); // bottom left
        Instantiate(spawnModule, new Vector2(pos.x, pos.y - 20), Quaternion.identity); // centre bottom
        Instantiate(spawnModule, new Vector2(pos.x + 20, pos.y - 20), Quaternion.identity); // centre left

        Instantiate(spawnModule, new Vector2(pos.x - 20, pos.y), Quaternion.identity); // centre left
        Instantiate(spawnModule, pos, Quaternion.identity); // centre
        Instantiate(spawnModule, new Vector2(pos.x + 20, pos.y), Quaternion.identity); // centre right

        Instantiate(spawnModule, new Vector2(pos.x - 20, pos.y + 20), Quaternion.identity); // bottom left
        Instantiate(spawnModule, new Vector2(pos.x, pos.y + 20), Quaternion.identity); // centre bottom
        Instantiate(spawnModule, new Vector2(pos.x + 20, pos.y + 20), Quaternion.identity); // centre left
    }

    void Spawn27by27(Vector2 pos)
    {
        
        Spawn9by9(new Vector2(pos.x - 60, pos.y - 60)); // BL
        Spawn9by9(new Vector2(pos.x, pos.y - 60)); // BC
        Spawn9by9(new Vector2(pos.x + 60, pos.y - 60)); // BR

        Spawn9by9(new Vector2(pos.x - 60, pos.y)); // CL
        Spawn9by9(new Vector2(pos.x, pos.y)); // CC
        Spawn9by9(new Vector2(pos.x + 60, pos.y)); // CR

        Spawn9by9(new Vector2(pos.x - 60, pos.y + 60)); // TL
        Spawn9by9(new Vector2(pos.x, pos.y + 60)); // TC
        Spawn9by9(new Vector2(pos.x + 60, pos.y + 60)); // TR
    }







    void neverCalledStorage()
    {
        Debug.Log(recentModule);
        playerPos = player.transform.position;
        if (playerPos.x > recentModuleR.x) // spawns to the right
        {
            Spawn9by9(new Vector2(recentModule.x + 60, recentModule.y));
            recentModuleR = recentModule;
        }
        if (playerPos.x <= recentModuleL.x) // spawns to the left
        {
            Spawn9by9(new Vector2(recentModule.x - 60, recentModule.y));
            recentModuleL = recentModule;
        }

        if (playerPos.y > recentModuleT.y) // spawns to the top
        {
            Spawn9by9(new Vector2(recentModule.x, recentModule.y + 60));
            recentModuleT = recentModule;
        }
        if (playerPos.y <= recentModuleB.y) // spawns to the bottom
        {
            Spawn9by9(new Vector2(recentModule.x, recentModule.y - 60));
            recentModuleB = recentModule;
        }



    }
}
