using UnityEngine;
using System.Collections;

public class GoodieSpawner : MonoBehaviour {

    Vector3 spawnPos;
    public GameObject sprinkle;
    public GameObject chocolate;
    public GameObject carrot;
    Quaternion spawnRot = Quaternion.identity;
    float sprinkleTime;
    float chocolateTime;
    float carrotTime;
    
    // Use this for initialization
	void Start () {
        //sprinkle = GameObject.Find("Sprinkle");
        //chocolate = GameObject.Find("Chocolate Chunk");
        spawnRot = Quaternion.Euler(90,0,0);
        chocolateTime = 1.0f;
        sprinkleTime = 2.5f;
        carrotTime = 7.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
        SpawnSprinkle();
        SpawnChocolate();
        SpawnCarrot();
        //Debug.Log(carrotTime);

    }

    void SpawnSprinkle()
    {
        sprinkleTime -= Time.deltaTime;
        if (sprinkleTime < 0)
        {
            spawnPos = new Vector3(Random.Range(transform.position.x-4, transform.position.x+4), transform.position.y + 5, 
                Random.Range(transform.position.x - 4, transform.position.x + 4));
            Instantiate(sprinkle, spawnPos, spawnRot);
            sprinkleTime = 2.5f;
        }
    }

    void SpawnChocolate()
    {
        chocolateTime -= Time.deltaTime;
        if (chocolateTime < 0)
        {
            spawnPos = new Vector3(Random.Range(transform.position.x - 4, transform.position.x + 4), transform.position.y + 5,
                Random.Range(transform.position.x - 4, transform.position.x + 4));
            Instantiate(chocolate, spawnPos, Quaternion.identity);
            chocolateTime = 1.0f;
        }
    }

    void SpawnCarrot()
    {
        carrotTime -= Time.deltaTime;
        if (carrotTime < 0)
        {
            //Debug.Log("Egad, Carrots!");
            spawnPos = new Vector3(Random.Range(transform.position.x - 4, transform.position.x + 4), transform.position.y + 5,
                Random.Range(transform.position.x - 4, transform.position.x + 4));
            Instantiate(carrot, spawnPos, Quaternion.identity);
            carrotTime = 7.0f;
        }
    }
}
