using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory Item")]
public class Item : ScriptableObject
{
    public string name;
    public string description;

    public Sprite artwork;
    public GameObject prefab;

    public int availbleAmmo;
    public int clipSize;
    public string ammoType;
}
