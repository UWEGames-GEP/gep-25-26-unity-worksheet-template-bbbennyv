using StarterAssets;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : ThirdPersonController
{
    [SerializeField]GameManager gameManager;
    [SerializeField] Inventory inventory;

    private void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            gameManager.Pausing();
            Debug.Log("PAUSED");
        }
    }

    private void OnInventory(InputValue input)
    {
        if (input.isPressed)
        {
            gameManager.Inventorying();
            Debug.Log("Inventory");
        }
    }


    private void OnRemoveItem(InputValue value)
    {

        if (value.isPressed) 
        {
            Debug.Log("Remove Item");
            inventory.RemoveItemFromInventory();
        }

    }


}
