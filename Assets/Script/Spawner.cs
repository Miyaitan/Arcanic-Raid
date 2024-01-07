using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform Player;
    private float spawnTime = 5f;
    private float itemSpawnTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", spawnTime, spawnTime);
        InvokeRepeating("ItemSpawner", itemSpawnTime, itemSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    [SerializeField] public GameObject[] objects;
    [SerializeField] public GameObject[] items;

    public void SpawnRandomEnemy()
    {
        int spawnPointX;
        int spawnPointY;
        do
        {
            spawnPointX = Random.Range(-28, 28);
            spawnPointY = Random.Range(-14, 14);
        } while (spawnPointX > -6 && spawnPointX < 6 || spawnPointY > -3 && spawnPointY < 3 || (Player.transform.position.x + spawnPointX) > 28 || (Player.transform.position.x + spawnPointX) < -28 || (Player.transform.position.y + spawnPointY) > 28 || (Player.transform.position.y + spawnPointY) < -28);

        Vector3 spawnPosition = new Vector3(Player.transform.position.x + spawnPointX, Player.transform.position.y + spawnPointY, 0);

        Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)], spawnPosition, Quaternion.identity);
    }

    public void ItemSpawner()
    {
        int spawnPointX;
        int spawnPointY;
        int random = Random.Range(0, 100);

        if(random <= 10)
        {
            
            spawnPointX = Random.Range(-28, 28);
            spawnPointY = Random.Range(-28, 28);

            Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, 0);


            Instantiate(items[UnityEngine.Random.Range(0, objects.Length - 1)], spawnPosition, Quaternion.identity);
        }
    }
}
