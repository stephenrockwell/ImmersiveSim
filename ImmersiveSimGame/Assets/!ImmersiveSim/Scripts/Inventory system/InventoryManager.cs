using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //references
    public GameObject inventory;
    public MouseLook mouseLook;
    public PlayerMovement playerMovement;
    public GameObject selectedBackground;

    public Image selected;
    public Image dragSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Turns inventory UI off and on
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(inventory.activeSelf == true)
            {
                //Inventory disable
                inventory.SetActive(false);

                mouseLook.enabled = true;
                playerMovement.enabled = true;
                selectedBackground.SetActive(true);

                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                //Inventory enable
                inventory.SetActive(true);

                mouseLook.enabled = false;
                playerMovement.enabled = false;
                selectedBackground.SetActive(false);

                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

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
}
