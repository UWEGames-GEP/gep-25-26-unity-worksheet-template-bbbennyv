using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Ref")]
    [SerializeField]public List<Item> items = new List<Item>();
    private GameManager gameManager;
    Transform worldItemsTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        worldItemsTransform = GameObject.Find("ItemManager").transform;

    }

    // Update is called once per frame
    void Update()
    {
        /*if(gameManager.State == GameManager.GameState.GAMEPLAY)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                AddItemToInventory("Bo-nana");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                RemoveItemToInventory("Bo-nana");
            }
        }*/

    }

    public void AddItemToInventory(Item item)
    {
        if(item == null) return;

        if(items.Contains(item)) return;

        items.Add(item);
         InsertionSort(items);
    }

    public void RemoveItemToInventory(Item item)
    {

        items.Remove(item);

    }



    public void RemoveItemFromInventory(Item item)
    {
            Vector3 currentpos = transform.position;
            Vector3 forward = transform.forward;

            Vector3 newpos = currentpos + forward;
            newpos += new Vector3(0, 1, 0);

            Quaternion currentrot = transform.rotation;
            Quaternion newrot = currentrot * Quaternion.Euler(0, 0, 100);

            GameObject newitem = Instantiate(item.gameObject,newpos,newrot,worldItemsTransform);
            newitem.name = item.name;
            newitem.SetActive(true);

            items.Remove(item);
            Destroy(item.gameObject);

    }


    public void RemoveItemFromInventory()
    {
        if(gameManager.IsGameplay && items.Count > 0)
        {
            Item item = items[0];

            RemoveItemFromInventory(item);

        }

    }


    public void RemoveItemFromInventory(int i)
    {
        if (i < items.Count)
        {
            Debug.Log($"the index of the remove is {i} in items");
            RemoveItemFromInventory(items[i]);

        }

    }

    public void TransferItemTo(Item item, Inventory targetInventory)
    {
        if (item == null) return;
        if (!items.Contains(item)) return;

        items.Remove(item);
        targetInventory.AddItemToInventory(item);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Item collision = hit.gameObject.GetComponent<Item>();
        if (collision != null && !items.Contains(collision))
        {
            AddItemToInventory(collision);
            collision.gameObject.SetActive(false);

        }

    }
    public void InsertionSort(List<Item> item)
    {

        for (int i = 1; i < items.Count; i++)
        {
            Item key = items[i];
            int j = i - 1;

            while (j >= 0 &&
                   string.Compare(items[j].name, key.name, StringComparison.OrdinalIgnoreCase) > 0)
            {
                items[j + 1] = items[j];
                j--;

            }

            items[j + 1] = key;

        }

    }

}
