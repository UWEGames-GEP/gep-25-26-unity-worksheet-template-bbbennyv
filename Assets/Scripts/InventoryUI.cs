using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Inventory inventory;
    public Chest activeChest;
    public bool isPlayerInventory;
    public List<GameObject> inventoryUIBtns = new List<GameObject>();

    private void OnEnable()
    {
        refreshInventory();
    }


    public void refreshInventory()
    {

        foreach (GameObject ui_btn in inventoryUIBtns)
        {
            ui_btn.SetActive(false);
        }



        for (int i = 0; i < inventory.items.Count; i++)
        {

            InventoryUIButton uibutton = inventoryUIBtns[i].GetComponent<InventoryUIButton>();
            Item item = inventory.items[i];

            uibutton.gameObject.SetActive(true);
            uibutton.SetButton(item);

        }


    }


    public void OnInventoryUIButton(int i)
    {


        if (activeChest != null && activeChest.isOpen)
        {

            if (isPlayerInventory)
                activeChest.MovePlayerItemToChest(i);
            else
                activeChest.MoveChestItemToPlayer(i);

            refreshInventory();
            return;
        }


        if (isPlayerInventory)
        {
            inventory.RemoveItemFromInventory(i);
            refreshInventory();
        }
    }

}
