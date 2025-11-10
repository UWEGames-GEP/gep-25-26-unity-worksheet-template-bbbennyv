using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<string> items = new List<string>();
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        
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
        InsertionSort(items);
    }

    public void AddItemToInventory(string itemName)
    {
        items.Add(itemName);
    }

    public void RemoveItemToInventory(string itemName)
    {
        items.Remove(itemName);
    }


    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        itemManager collision = hit.gameObject.GetComponent<itemManager>();
        if (collision != null)
        {
            items.Add(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }

    public void InsertionSort(List<string> item)
    {
       
        int n = item.Count;
        for (int i = 1; i < n; i++)
        {
            string key = item[i];
            int j = i - 1;

            while (j >= 0 && string.Compare(item[j],key,StringComparison.OrdinalIgnoreCase)>0)
            {
                item[j+1] = item[j];
                j--;
            }
            item[j + 1] = key;
        }



    }

}
