using UnityEngine;

public class Popup_spawner : MonoBehaviour
{
    public GameObject[] popupPrefabs;

    public float spawnmaxtime = 5f;
    private float timer;
    private float nextSpawnTime;

    public AudioClip popupSound;
    public float volume = 1.0f;
    private AudioSource audioSource;

    public int initialSpawnAmount = 5;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Set first random spawn time
        nextSpawnTime = Random.Range(0f, spawnmaxtime);
        timer = 0f;

        // Spawn initial popups
        for (int i = 0; i < initialSpawnAmount; i++)
        {
            int randIndex = Random.Range(0, popupPrefabs.Length);
            Instantiate(popupPrefabs[randIndex], UI_Manager.instance.transform);
        }
    }

void Update()
{
    // 👇 NEW: stop spawning when game ends
    if (Game_Manager.instance != null && Game_Manager.instance.gameEnded)
        return;

    timer += Time.deltaTime;

    if (timer >= nextSpawnTime)
    {
        int randIndex = Random.Range(0, popupPrefabs.Length);
        Instantiate(popupPrefabs[randIndex], UI_Manager.instance.transform);

        audioSource.PlayOneShot(popupSound, volume);

        timer = 0f;
        nextSpawnTime = Random.Range(0f, spawnmaxtime);
    }
}
}
