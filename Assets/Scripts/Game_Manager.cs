using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    private GameObject playerinput;

    [Header("Game Rules")]
    public int losePopupCount = 50;

    [Header("Runtime State")]
    public int currentPopupCount = 0;

    [Header("Scoring")]
    public int windowsClosed = 0;
    public float timeSurvived = 0f;
    public int maxPopupsAlive = 0;
    public int finalScore = 0;
    public int shotcount;
    public float accuracy;
        public bool gameEnded { get; private set; } = false;

    void Awake()
    {
        playerinput = GameObject.Find("PlayerInput");
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        shotcount = playerinput.GetComponent<PlayerInput>().shotcount;
        if (gameEnded)
            return;

        timeSurvived += Time.deltaTime;
        accuracy = windowsClosed / (float)shotcount * 100f;
    }
    // Called when a popup is spawned
    public void RegisterPopup()
{
    if (gameEnded) return;

    currentPopupCount++;

    if (currentPopupCount > maxPopupsAlive)
        maxPopupsAlive = currentPopupCount;

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
    windowsClosed++;

    if (currentPopupCount <= 0)
    {
        WinGame();
    }
}

   void WinGame()
{
    gameEnded = true;

    finalScore =
        (windowsClosed * 100)
        - Mathf.RoundToInt(timeSurvived * 5f)
        - (maxPopupsAlive * 50);

    finalScore = Mathf.Max(0, finalScore); // never negative

    Debug.Log("WIN");
    Debug.Log("Closed: " + windowsClosed);
    Debug.Log("Time: " + timeSurvived);
    Debug.Log("Peak Chaos: " + maxPopupsAlive);
    Debug.Log("Score: " + finalScore);

    // TODO: show win UI + score
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
