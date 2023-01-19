using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Spawn : MonoBehaviour
{
    public GameObject Entity; //This is used to know what object to spawn
    public float SpawnTimer; //This is used to get the time for the enmies to start spawning
    public float SpawnRepeat; //This line is responsible for the repeating of the spawns
    public int numberEntities = 0;

    private void Start()
    {
            InvokeRepeating("SpawnEntity", SpawnTimer, SpawnRepeat); //Keeps on enemies spawning         
    }

    public void SpawnEntity()
    {
        Instantiate(Entity, transform.position, transform.rotation); //Instantiate is the function that is responsible for spawning enemies 
        numberEntities += 1;
    }
}
