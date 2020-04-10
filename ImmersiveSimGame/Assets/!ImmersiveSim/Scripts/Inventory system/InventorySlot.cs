using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image image;
    public Item slot;
    public InventoryManager manager;
    public Sprite emptySprite;

    private int indexNumber;
    private bool isBeingDragged;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
        startPos = this.transform.position;
        indexNumber = transform.GetSiblingIndex();
    }

    void Update()
    {
        //sets position of image
        if(isBeingDragged == true)
        {
            transform.position = Vector3.Lerp(startPos, Input.mousePosition, .2f);
            
        }
        else
        {
            if(transform.position != startPos)
            {
                transform.position = startPos;
            }
        }
        
        //sets sprite for image if it exists;
        if (slot != null)
        {
            if(image.sprite != slot.artwork)
            {
                image.sprite = slot.artwork;
            }
        }
        else
        {
            if (image.sprite != emptySprite)
            {
                image.sprite = emptySprite;
            }
        }
    }

    public void StartDrag()
    {
        if(slot != null)
        {
            isBeingDragged = true;
            transform.SetSiblingIndex(0);
        }
    }

    public void EndDrag()
    {
        isBeingDragged = false;
        transform.SetSiblingIndex(indexNumber);
        Item selectedSlot = manager.dragSelected.gameObject.GetComponent<InventorySlot>().slot;

        //checks if the the area the item was dropped is empty
        if (manager.dragSelected != null)
        {
            //checks if sprite is empty
            if(manager.dragSelected.sprite = emptySprite)
            {
                //Moves Item
                manager.dragSelected.gameObject.GetComponent<InventorySlot>().slot = slot;
                ResetSlot();
            }
            else
            {
                //Swaps items
                Item tempSlot = slot;

                slot = selectedSlot;
                manager.dragSelected.gameObject.GetComponent<InventorySlot>().slot = tempSlot;
            }
        }
        //Resets position
        transform.position = startPos;
    }

    public void ResetSlot()
    {
        slot = null;
        transform.position = startPos;
    }
}
