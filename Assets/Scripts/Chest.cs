using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    [SerializeField] private Inventory chestInv;

    private bool playerInRange = false;
    public bool Playerinrange => playerInRange;

    private void Start()
    {
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
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    public void OpenChest()
    {
        Debug.Log("Open Chest");
        
    }


}
