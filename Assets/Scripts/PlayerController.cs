using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Vector3 mousePosition;
    private Vector3 direction;
    private Rigidbody rb;
    private Rigidbody rigidbodyTrigger;

    public float movespeed = 10f;

    private bool isDrilling = false;

    private float heat = 0;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        followMouse();
        if (!isDrilling & heat > 0) {
            heat--;
        }
    }

    void followMouse() {
        //follow mouse cursor?
        mousePosition = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;
        rb.velocity = new Vector3(direction.x * movespeed, direction.y * movespeed, 0);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Entered Trigger/ore");
        isDrilling = true;
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log("Drilling");
        heat++;
        //GetComponent<OreController>().health--;//works like this?
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("Trigger Left");
        isDrilling = false;
    }
}
