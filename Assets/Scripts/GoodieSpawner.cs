using UnityEngine;
using System.Collections;

public class GoodieSpawner : MonoBehaviour {

    Vector3 spawnPos;
    GameObject sprinkle;
    GameObject chocolate;
    
    // Use this for initialization
	void Start () {
        sprinkle = GameObject.Find("/Sprinkle");
        chocolate = GameObject.Find("Chocolate Chunk");

	
	}
	
	// Update is called once per frame
	void Update () {
        SpawnSprinkle();
	}

    void SpawnSprinkle()
    {
        spawnPos = new Vector3(Random.Range(-5.0f, 5.0f), 0.5f, Random.Range(-5.0f, 5.0f));
        Instantiate(sprinkle, spawnPos, Quaternion.identity);
    }
}
