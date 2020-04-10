using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelector : MonoBehaviour
{
    //references
    public Transform weaponHolder;
    public Image selectedSquare;
    public GameObject slotParent;
    public InventoryManager manager;
    public Vector3[] slotPositions;

    public int selectedIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        int slotNum = 0;
        foreach (InventorySlot slot in manager.hotbar)
        {
            slotPositions[slotNum] = slot.transform.position;
            slotNum++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScrollWheelSelect();
        HandleActiveItems();
    }
    public void ScrollWheelSelect()
    {
        selectedSquare.transform.position = slotPositions[selectedIndex];
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedIndex < 7)
            {
                selectedIndex++;
            }
            else
            {
                selectedIndex = 0;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedIndex > 0)
            {
                selectedIndex--;
            }
            else
            {
                selectedIndex = 7;
            }
        }
    }
    public void HandleActiveItems()
    {
        for (int i = 0; i < slotPositions.Length; i++)
        {
            if(manager.hotbar[i].slot != null)
            {
                if (i != selectedIndex)
                {
                    manager.hotbar[i].slot.prefab.SetActive(false);
                }
                else
                {
                    manager.hotbar[i].slot.prefab.SetActive(true);
                }
            }
        }
    }
}
