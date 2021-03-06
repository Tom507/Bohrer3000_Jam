using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour {
    private Vector3 mousePosition;
    private Vector3 direction;
    private Rigidbody rb;
    public UnityEngine.Camera camera;

    public float movespeed = 10f;

    public bool isDrilling = false;
    
    public float heat = 0;
    public float maxHeat = 10f;
    public bool isOverHeated = false;
    public float heatUpRatio = 1f;
    public float coolDownRatio = 0.25f;
    public float damage = 0.5f;

    public GameObject lastDrilledOre;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        followMouse();
        if (!isOverHeated & heat > maxHeat) isOverHeated = true;
        //check if is overheated
        if (isOverHeated & heat < 0) isOverHeated = false;
        //default cooldown
        if (!isDrilling & heat > 0) heat -= coolDownRatio * Time.deltaTime;
    }

    void followMouse() {
        //follow mouse cursor?
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;
        rb.velocity = new Vector3(direction.x * movespeed, direction.y * movespeed, 0);
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("Entered Trigger/ore");
        isDrilling = true;
        lastDrilledOre = other.gameObject;
    }

    private void OnTriggerStay(Collider other) {
        if (!isOverHeated & other.gameObject.tag.Equals("Ore")) {
            print("Drilling");
            isDrilling = true;
            heat += heatUpRatio * Time.deltaTime;
            
            other.gameObject.GetComponent<OreController>().DoDamage(damage);
            if (other.gameObject.GetComponent<OreController>().health < 0) {
                isDrilling = false;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        //Debug.Log("Trigger Left");
        isDrilling = false;
    }
}
