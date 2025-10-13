using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<string> items = new List<string>();
    public GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.State == GameManager.GameState.GAMEPLAY)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                AddItemToInventory("Bo-nana");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                RemoveItemToInventory("Bo-nana");
            }
        }


    }

    public void AddItemToInventory(string itemName)
    {
        items.Add(itemName);
    }

    public void RemoveItemToInventory(string itemName)
    {
        items.Remove(itemName);
    }



}
