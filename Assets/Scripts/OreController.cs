using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class OreController : MonoBehaviour {
    //todo: create ore functionality
    public float health;
    public OreType type;
    public Sprite oreTexture;

    public OreController(float health, OreType type, Sprite oreTexture) {
        this.health = health;
        this.type = type;
        this.oreTexture = oreTexture;
    }

    public void cast(OreController oc) {
        this.health = oc.health;
        this.oreTexture = oc.oreTexture;
        this.type = oc.type;
    }
    private void Start() {
        
    }

    private void Update() {
        if (health < 0) {
            Destroy(this.gameObject);
        }
    }

    public void DoDamage(float damage) {
        health -= damage * Time.deltaTime;
    }

    private void OnTriggerStay(Collider other) {
        
    }
}