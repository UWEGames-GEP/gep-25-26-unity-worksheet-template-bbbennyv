using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    [SerializeField] private Inventory chestInv;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private GameObject player;
    private bool playerInRange = false;

    private void Start()
    {
        if (!chestInv)
        chestInv = GetComponent<Inventory>();



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (!playerInRange) return;


        if (Input.GetKeyDown(KeyCode.Alpha1))
            MovePlayerItemToChest(0);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            MoveChestItemToPlayer(0);
    }

    public void OpenChest()
    {
        if (!playerInRange)
            return;
        Debug.Log("Open Chest");
        
    }

    public void MovePlayerItemToChest(int index)
    {
        if (!playerInRange) return;
        if (index >= playerInventory.items.Count) return;

        Item item = playerInventory.items[index];
        playerInventory.TransferItemTo(item, chestInv);
    }

    public void MoveChestItemToPlayer(int index)
    {
        if (!playerInRange) return;
        if (index >= chestInv.items.Count) return;

        Item item = chestInv.items[index];
        chestInv.TransferItemTo(item, playerInventory);
    }


}
