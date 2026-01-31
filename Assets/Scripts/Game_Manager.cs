using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    [Header("Game Rules")]
    public int losePopupCount = 50;

    [Header("Runtime State")]
    public int currentPopupCount = 0;

    private bool gameEnded = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Called when a popup is spawned
    public void RegisterPopup()
    {
        if (gameEnded) return;

        currentPopupCount++;

        // LOSE CONDITION
        if (currentPopupCount >= losePopupCount)
        {
            LoseGame();
        }
    }

    // Called when a popup is destroyed/closed
    public void UnregisterPopup()
    {
        if (gameEnded) return;

        currentPopupCount--;

        // WIN CONDITION
        if (currentPopupCount <= 0)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        gameEnded = true;

        Debug.Log("WIN: All popups cleared!");

        // TODO:
        // - Show win UI
        // - Display score / time survived
        // - Stop spawners
    }

    void LoseGame()
    {
        gameEnded = true;

        Debug.Log("LOSE: Too many popups!");

        // TODO:
        // - Show lose UI
        // - Freeze input
        // - Stop spawners
    }
}
