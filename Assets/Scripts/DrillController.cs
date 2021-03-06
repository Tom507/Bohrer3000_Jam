using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DrillController : MonoBehaviour {
    public float constantSpeed = 1f;
    public int xp = 0;
    public float health = 100f;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start() {
        this.rb = GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Enter" + " ore trigger");
        if (other.gameObject.tag.Equals("Ore")) {
            rb.AddForce(new Vector3(0,30,0));//bounce back
            health -= 10f;
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        //constant force downwards
        if (rb.velocity.sqrMagnitude < constantSpeed) {
            rb.AddForce(new Vector3(0,-constantSpeed,0));
        }
    }

    private void OnGUI() {
        Label l = new Label() {
            name = "health?"
        };
    }
}
