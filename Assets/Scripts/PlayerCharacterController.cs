using StarterAssets;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : ThirdPersonController
{
    [Header("Ref")]
    [SerializeField]GameManager gameManager;
    [SerializeField] Inventory inventory;
    [SerializeField] Chest chest;

    private void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            gameManager.TogglePause();
        }
    }

    private void OnInventory(InputValue input)
    {
        if (input.isPressed)
        {
            gameManager.ToggleInventory();
        }
    }


    private void OnRemoveItem(InputValue value)
    {
        if (!value.isPressed) return;

        if (!gameManager.IsGameplay)
            return;

        inventory.RemoveItemFromInventory();
    }

    private void OnOpenChest(InputValue value)
    {
        chest.ToggleChest();
    }



}
