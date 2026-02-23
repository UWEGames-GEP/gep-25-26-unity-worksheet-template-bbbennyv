using Assets.Scripts;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    [Header("ref")]
    [SerializeField] private Inventory chestInv;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] GameManager gameManager;
    [SerializeField] private GameObject player;
    [Header("UI")]
    [SerializeField] private InventoryUI playerUI;
    [SerializeField] private InventoryUI chestUI;
    private bool playerInRange = false;

    public bool isOpen {get;private set;}
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

    public void ToggleChest()
    {
        if (!playerInRange)
            return;
        if (gameManager.IsInventory)
            return;
        isOpen = !isOpen;
        if (isOpen)
        {
            playerUI.activeChest = this;
            chestUI.activeChest = this;

            playerUI.refreshInventory();
            chestUI.refreshInventory();
        }
        gameManager.ToggleChest();

    }

    public void MovePlayerItemToChest(int index)
    {
        if (!playerInRange) return;
        if (index >= playerInventory.items.Count) return;

        Item item = playerInventory.items[index];
        playerInventory.TransferItemTo(item, chestInv);
        playerUI.refreshInventory();
        chestUI.refreshInventory();
    }

    public void MoveChestItemToPlayer(int index)
    {
        if (!playerInRange) return;
        if (index >= chestInv.items.Count) return;

        Item item = chestInv.items[index];
        chestInv.TransferItemTo(item, playerInventory);
        playerUI.refreshInventory();
        chestUI.refreshInventory();
    }


}
