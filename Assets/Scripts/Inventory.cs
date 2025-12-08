using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]public List<itemManager> items = new List<itemManager>();
    private GameManager gameManager;
    Transform worldItemsTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        Transform worldItemsTransform = GameObject.Find("ItemManager").transform;
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

    public void AddItemToInventory(itemManager item)
    {
        items.Add(item);
    }

    public void RemoveItemToInventory(itemManager item)
    {

        items.Remove(item);
    }



    public void RemoveItemFromInventory(itemManager item)
    {
        
            
            Vector3 currentpos = transform.position;
            Vector3 forward = transform.forward;

            Vector3 newpos = currentpos + forward;
            newpos += new Vector3(0, 1, 0);

            Quaternion currentrot = transform.rotation;
            Quaternion newrot = currentrot * Quaternion.Euler(0, 0, 100);

            GameObject newitem = Instantiate(item.gameObject,newpos,newrot,worldItemsTransform);
            newitem.SetActive(true);

            items.Remove(item);
            Destroy(item.gameObject);
        
        
    }


    public void RemoveItemFromInventory()
    {
        if(gameManager.getState() == "Gameplay" && items.Count > 0)
        {
            itemManager item = items[0];

            RemoveItemFromInventory(item);
        }
    }


    public void RemoveItemFromInventory(int i)
    {
        if (i < items.Count) 
        {
            RemoveItemFromInventory(items[i]);
        }
    }



    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        itemManager collision = hit.gameObject.GetComponent<itemManager>();
        if (collision != null)
        {
            items.Add(collision);
            collision.gameObject.SetActive(false);
        }
    }

    public void InsertionSort(List<itemManager> item)
    {
       
        int n = item.Count;
        for (int i = 1; i < n; i++)
        {
            string key = item[i].name;
            int j = i - 1;

            while (j >= 0 && string.Compare(item[j].name,key,StringComparison.OrdinalIgnoreCase)>0)
            {
                item[j+1].name = item[j].name;
                j--;
            }
            item[j + 1].name = key;
        }



    }

}
