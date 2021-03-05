using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManagerController : MonoBehaviour {
    //generation and Stroes all ores for ez access
    //public List<Collider> oreColider;
    public List<GameObject> oreList = new List<GameObject>();
    private List<GameObject> generativeOres = new List<GameObject>();
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start() {
        //oreColider = new List<Collider>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private float t = 10f;
    private float d = 5f;
    void oreGeneration() {
        for (int i = (int)(Random.value*9); i > 0; i--) {
            if (Random.value < 0.2f) {
                GameObject go = oreList[Random.Range(0,oreList.Count)];
                go.transform.position = Player.transform.position;
                go.transform.position += new Vector3(Random.Range(-d, d), -t, 0);
            }
        }
    }
}
