using Assets.Scripts;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("UI References")]
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject inventoryUI;

    private State currentState;

    // Public getters so states can access them safely
    public GameObject PauseUI => pauseUI;
    public GameObject InventoryUI => inventoryUI;

    // State instances
    private GameplayState gameplayState = new GameplayState();
    private PauseState pauseState = new PauseState();
    private InventoryState inventoryState = new InventoryState();

    public State CurrentState => currentState;

    public bool IsGameplay => currentState is GameplayState;
    public bool IsPaused => currentState is PauseState;
    public bool IsInventory => currentState is InventoryState;

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
}
