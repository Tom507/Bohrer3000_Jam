using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DrillController : MonoBehaviour {
    public float constantSpeed = 1f;
    public int xp;
    public float health;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start() {
        this.rb = GetComponent<Rigidbody>();
    }
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Enter" + " ore trigger");
        if (other.gameObject.tag.Equals("Ore")) {
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
}
