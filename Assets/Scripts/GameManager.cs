using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    enum GameState {GAMEPLAY,PAUSE,ESCAPE};
    [SerializeField] GameState state;
    private bool has_changed_state = false;



    void Start()
    {
        state = GameState.GAMEPLAY;
    }

    // Update is called once per frame
    void Update()
    {
  

        switch (state)
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
        }
    }

    private void LateUpdate()
    {
        if(has_changed_state) {has_changed_state=false;
            if (state == GameState.GAMEPLAY)
            {
                Time.timeScale = 1.0f;
            }
            else if(state == GameState.PAUSE)
            {
                Time.timeScale = 0.0f;

            }
        }
    }
}
