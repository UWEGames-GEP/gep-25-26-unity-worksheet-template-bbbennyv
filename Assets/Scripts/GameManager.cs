using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializedField] enum GameState {GAMEPLAY,PAUSE,ESCAPE};
    GameState state;



    void Start()
    {
        state = GameState.GAMEPLAY;
        if (state == GameState.GAMEPLAY)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = GameState.PAUSE;
            }
        }
        else if (state == GameState.PAUSE)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = GameState.GAMEPLAY;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
