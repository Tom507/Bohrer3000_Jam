using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{

    public GameObject backgroundMap;
    public float ySpawn = -24.96f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frames
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BackgroundMap") 
        {
            Debug.Log("Spawn new Map");
           
            Instantiate(backgroundMap, new Vector3(0, ySpawn, 0), Quaternion.identity);
            ySpawn -= 24.96f;


        }
    }
}   
