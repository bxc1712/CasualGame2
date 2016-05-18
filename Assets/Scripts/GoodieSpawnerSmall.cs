using UnityEngine;
using System.Collections;

public class GoodieSpawnerSmall : MonoBehaviour
{

    Vector3 spawnPos;
    public GameObject sprinkle;
    public GameObject chocolate;
    public GameObject carrot;
    Quaternion spawnRot = Quaternion.identity;
    float sprinkleTime;
    float chocolateTime;
    float carrotTime;

    // Use this for initialization
    void Start()
    {
        //sprinkle = GameObject.Find("Sprinkle");
        //chocolate = GameObject.Find("Chocolate Chunk");
        spawnRot = Quaternion.Euler(90, 0, 0);
        chocolateTime = 1.1f;
        sprinkleTime = 1.5f;
        carrotTime = 1.7f;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnSprinkle();
        SpawnChocolate();
        SpawnCarrot();
        //Debug.Log(carrotTime);

    }

    //FOLLOWING ARE HARD CODED FOR THE SMALL MAP, DO NOT USE FOR TERRAIN MAPS

    void SpawnSprinkle()
    {
        sprinkleTime -= Time.deltaTime;
        if (sprinkleTime < 0)
        {
            spawnPos = new Vector3(Random.Range(-4.5f, 4.5f), 10, Random.Range(-4.5f, 4.5f));
            Instantiate(sprinkle, spawnPos, spawnRot);
            sprinkleTime = 1.5f;
        }
    }

    void SpawnChocolate()
    {
        chocolateTime -= Time.deltaTime;
        if (chocolateTime < 0)
        {
            spawnPos = new Vector3(Random.Range(-4.5f, 4.5f), 10, Random.Range(-4.5f, 4.5f));
            Instantiate(chocolate, spawnPos, Quaternion.identity);
            chocolateTime = 1.1f;
        }
    }

    void SpawnCarrot()
    {
        carrotTime -= Time.deltaTime;
        if (carrotTime < 0)
        {
            //Debug.Log("Egad, Carrots!");
            spawnPos = new Vector3(Random.Range(-4.5f, 4.5f), 10, Random.Range(-4.5f, 4.5f));
            Instantiate(carrot, spawnPos, Quaternion.identity);
            carrotTime = 1.7f;
        }
    }
}
