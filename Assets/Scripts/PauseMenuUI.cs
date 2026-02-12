using UnityEngine;
using Assets.Scripts;
public class PauseMenuUI : MonoBehaviour
{
    [Header("Ref")]
    [SerializeField] private GameManager gameManager;
    public void Quit()
    {
        Debug.Log("QUIT");
    }

    public void Play()
    {
        gameManager.TogglePause();
    }
}
