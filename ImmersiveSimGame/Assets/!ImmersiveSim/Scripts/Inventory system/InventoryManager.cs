using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //--Toggeling inventory
    public GameObject inventoryObject;
    public MouseLook mouseLook;
    //public PlayerMovement playerMovement;
    public GameObject selectedBackground;

    //--Moving items
     public Image selected;
    public Image dragSelected;

    //--Specifies specific slots
    public List<Transform> inventoryHolders = new List<Transform>();
    [HideInInspector] public List<InventorySlot> inventory = new List<InventorySlot>();
    [HideInInspector] public List<InventorySlot> armor = new List<InventorySlot>();
    [HideInInspector] public List<InventorySlot> hotbar = new List<InventorySlot>();

    //--Other
    public Transform weaponHolder;
    public List<GameObject> itemsInInventory = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        //Specifies specific slots
        foreach (Transform child in inventoryHolders[0])
        {
            inventory.Add(child.GetComponent<InventorySlot>());
        }
        foreach (Transform child in inventoryHolders[1])
        {
            armor.Add(child.GetComponent<InventorySlot>());
        }
        foreach (Transform child in inventoryHolders[2])
        {
            hotbar.Add(child.GetComponent<InventorySlot>());
        }

        //adds all existing items to inventory
        foreach (Transform child in weaponHolder)
        {
            AddToInventory(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Turns inventory UI off and on
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryObject.activeSelf == true)
            {
                //Inventory disable
                inventoryObject.SetActive(false);

                mouseLook.enabled = true;
                //playerMovement.enabled = true;
                selectedBackground.SetActive(true);

                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                //Inventory enable
                inventoryObject.SetActive(true);

                mouseLook.enabled = false;
                //playerMovement.enabled = false;
                selectedBackground.SetActive(false);

                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void AddToInventory(GameObject itemGO)
    {
        Item item = itemGO.GetComponent<ItemTag>().type;
        bool filled = false;
        foreach(InventorySlot slot in inventory)
        {
            if(slot.slot == null)
            {
                slot.slot = item;
                filled = true;
                itemsInInventory.Add(itemGO);
                break;
            }
        }

        if(!filled)
        {
            foreach (InventorySlot slot in armor)
            {
                if (slot.slot == null)
                {
                    slot.slot = item;
                    filled = true;
                    itemsInInventory.Add(itemGO);
                    break;
                }
            }
        }

        if (!filled)
        {
            foreach (InventorySlot slot in hotbar)
            {
                if (slot.slot == null)
                {
                    slot.slot = item;
                    filled = true;
                    itemsInInventory.Add(itemGO);
                    break;
                }
            }
        }

    }

    public void RemoveFromInventory(Item item)
    {

    }

    #region Event system dragging
    public void SelectSlot(Image slot)
    {
        selected = slot;
    }

    public void DeselectSlot()
    {
        selected = null;
    }

    public void EndDragSlot(Image slot)
    {
        dragSelected = slot;
    }
    #endregion
}
