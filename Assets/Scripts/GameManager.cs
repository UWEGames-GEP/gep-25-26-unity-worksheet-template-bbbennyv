using Assets.Scripts;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool has_changed_state = false;
    [SerializeField] State state;
    public State GamePlay, Pause;
    [SerializeField]GameObject inventoryUI;
    void Start()
    {
        GamePlay = new("Gameplay", 1.0f);
        Pause = new("Pause", 0.0f);
        state = GamePlay;
        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        




    }


    public void Pausing()
    {
        switch (state.getCurrentState())
        {
            case "Gameplay":
                    has_changed_state = true;
                    state = Pause;
                break;
            case "Pause":
                    has_changed_state = true;
                    state = GamePlay;
                break;

        }
    }

    public string getState()
    {
        return state.getCurrentState();
    }


    private void LateUpdate()
    {
        if(has_changed_state) {has_changed_state=false;
            if (state == GamePlay)
            {
                Time.timeScale = state.ts;
                inventoryUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if(state == Pause)
            {
                Time.timeScale = state.ts;
                inventoryUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;

            }
        }
    }
}
