using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTag : MonoBehaviour
{
    public Item type;
    public int itemID = 0;
    public bool inInventory = false;
    // Start is called before the first frame update
    void Start()
    {
        type.prefab = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
