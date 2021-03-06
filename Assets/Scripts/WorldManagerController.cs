using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManagerController : MonoBehaviour {
    //generation and Stroes all ores for ez access
    //public List<Collider> oreColider;
    public List<Ore> oreList = new List<Ore>();
    private List<GameObject> generatedOres = new List<GameObject>();
    public GameObject Player;
    public GameObject Drill;
    
    // Start is called before the first frame update
    void Start() {
        //oreColider = new List<Collider>();
        stepIndex = defaultStepIndex;
    }

    // Update is called once per frame
    void Update() {
        oreGeneration();
    }

    private int nameIndex = 1;
    public float defaultStepIndex = 10f;
    private float stepIndex; //to not generte every frame
    private float heightOffset = 10f; //from drill
    private float width = 15f; //genBox x
    private float height = 5f; //genBox y
    void oreGeneration() {
        if (stepIndex < 0f) {
            stepIndex = defaultStepIndex; //reset stepIndex
            
            Vector3 generationOrigin = Drill.transform.position;
            generationOrigin.z = 0;
            generationOrigin.y -= heightOffset;
            int oreAmountToGenerate = Random.Range(0, 5);

            for (int i = 0; i < oreAmountToGenerate; i++) {
                Vector3 genPoint = new Vector3(
                    Random.Range(-width, width), 
                    Random.Range(generationOrigin.y-height, generationOrigin.y+height), 
                    0);
                Debug.Log(genPoint);

                Ore genOre = oreList[Random.Range(0, oreList.Count)];
                GameObject genObj = new GameObject(nameIndex++.ToString());

                Instantiate(genObj, genPoint, Quaternion.identity, this.transform);
            }
        } else {
            stepIndex -= 1 * Time.deltaTime;
        }
    }
}
