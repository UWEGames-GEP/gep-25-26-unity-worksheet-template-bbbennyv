using Assets.Scripts;
using UnityEditor.Rendering;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool has_changed_state = false;
    [SerializeField] State state;
    public State GamePlay, Pause;

    void Start()
    {
        GamePlay = new("Gameplay", 1.0f);
        Pause = new("Pause", 0.0f);
        state = GamePlay;
    }

    // Update is called once per frame
    void Update()
    {


        /*switch (state)
        {
            case GameState.GAMEPLAY:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    state = GameState.PAUSE;
                    has_changed_state = true;
                }
                break;
            case GameState.PAUSE:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    state = GameState.GAMEPLAY;
                    has_changed_state = true;

                }
                break;
        }*/
        switch (state.getCurrentState())
        {
            case "Gameplay":
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    has_changed_state = true;
                    state = Pause;
                }
                break;
            case "Pause":
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    has_changed_state = true;
                    state = GamePlay;
                }
                break;

        }






    }

    


    private void LateUpdate()
    {
        if(has_changed_state) {has_changed_state=false;
            if (state == GamePlay)
            {
                Time.timeScale = state.ts;
            }
            else if(state == Pause)
            {
                Time.timeScale = state.ts;

            }
        }
    }
}
