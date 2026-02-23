using Assets.Scripts;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("UI Ref")]
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject chestUI;

    private State currentState;

    public GameObject PauseUI => pauseUI;
    public GameObject InventoryUI => inventoryUI;
    public GameObject ChestUI => chestUI;

    private GameplayState gameplayState = new GameplayState();
    private PauseState pauseState = new PauseState();
    private InventoryState inventoryState = new InventoryState();
    private ChestState chestState = new ChestState();


    public bool IsGameplay => currentState is GameplayState;

    public bool IsChest => currentState is ChestState;
    //public bool IsPaused => currentState is PauseState;
    public bool IsInventory => currentState is InventoryState;
    //public State CurrentState => currentState;

    private void Start()
    {
        SetState(gameplayState);
    }

    public void SetState(State newState)
    {
        if (currentState == newState)
            return;

        currentState = newState;
        currentState.Enter(this);
        Debug.Log($"current state -{currentState.ToString()}");
    }


    //if need be these are here
    /*public void GoToGameplay()
    {
        SetState(gameplayState);
    }

    public void GoToPause()
    {
        SetState(pauseState);
    }

    public void GoToInventory()
    {
        SetState(inventoryState);
    }*/

    public void TogglePause()
    {
        if (currentState is PauseState)
            SetState(gameplayState);
        else if (currentState is GameplayState)
            SetState(pauseState);
    }

    public void ToggleInventory()
    {
        if (currentState is InventoryState)
            SetState(gameplayState);
        else if (currentState is GameplayState)
            SetState(inventoryState);

    }

    public void ToggleChest()
    {
        if (currentState is ChestState)
            SetState(gameplayState);
        else if (currentState is GameplayState)
            SetState(chestState);
    }

}
