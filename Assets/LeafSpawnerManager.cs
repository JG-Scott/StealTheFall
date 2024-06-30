using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSpawnerManager : MonoBehaviour
{

    public float OGTime;
    public GameObject Leaf;

    public GameObject Grenade;
    public float timer;

    public float GrenadeSpawnvalue = 3;

    public int thingsSpawned;
    // Start is called before the first frame update
    void Start()
    {
        timer = OGTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0) {
            SpawnLeaf();

            timer = OGTime;
            if(OGTime > 1) {
                OGTime-=0.1f;
            }
        }
    }

    public void SpawnLeaf() {
        thingsSpawned++;
        if(thingsSpawned > 10) {
            thingsSpawned = 0;
            GrenadeSpawnvalue +=0.5f;
            if(GrenadeSpawnvalue >= 4) {
                GrenadeSpawnvalue = 4;
            }
        }
        float randomX = Random.Range(-7f, 7f);
        if(Random.Range(0f,10f) < GrenadeSpawnvalue) {
            Instantiate(Grenade,new Vector3(randomX, 6, 0),Quaternion.identity);
        } else {
            Instantiate(Leaf,new Vector3(randomX, 6, 0),Quaternion.identity);
        }
    }
}
