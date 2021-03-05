using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManagerController : MonoBehaviour {
    //generation and Stroes all ores for ez access
    public List<Collider> oreColider;
    public List<GameObject> oreList = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start() {
        oreColider = new List<Collider>();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
