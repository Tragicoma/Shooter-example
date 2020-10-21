using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private GameObject[] powerups;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawningEnemies());
        StartCoroutine(Spawningbuffs());
    }

    IEnumerator SpawningEnemies()
    {
        while(true)

        {
            Instantiate(Enemy, new  Vector3(Random.Range(-5.5f,5.5f),7,0),Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator Spawningbuffs()
    {
        while(true)

        {
            int randomBuff = Random.Range(0, 3);
            Instantiate(powerups[randomBuff], new Vector3(Random.Range(-5.5f, 5.5f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);

        }

    }
}
