using UnityEngine;

[CreateAssetMenu(fileName = "Ore", menuName = "ScriptableObjects/WorldObjects/OreTemplate", order = 1)]
public class Ore : ScriptableObject {
    public float health;
    public OreType type;
    public Sprite texture;
}