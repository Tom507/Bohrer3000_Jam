using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCleaner : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "BackgroundMap")
        {
            Debug.Log("Remove Map");
            Destroy(col.gameObject);
        }
    }

}
