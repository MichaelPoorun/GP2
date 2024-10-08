using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject spawnedEnemy;

    public float timeToSpawn, spawnCountdown;

    public AudioClip spawnSound;

    public AudioSource spawnSoundSource;

    // Start is called before the first frame update
    void Start()
    {
        spawnCountdown = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountdown -= Time.deltaTime;
        if (spawnCountdown < 0 ) 
        {
            spawnCountdown = Random.Range(3, 10);

            Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
            //timeToSpawn *= 0.05; //lowers the time for enemies to spawn every time they spawn this line has an error

            spawnSoundSource.PlayOneShot(spawnSound);
        }
    }
}
