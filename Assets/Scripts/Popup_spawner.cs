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
    public int endgamemaxcrashspawnamount = 2000;
    public int endgamneamountcount = 0;
    public float endgamecrashinterval = 0.005f;
    public float endgamecrashtimer = 0f;



    //blue screen timer
    public float bluescreentimeshown = 5f;
    public Transform popupparent;
    

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
            Instantiate(popupPrefabs[randIndex], popupparent);
        }
    }

void Update()
{

    //gane end crash spawn
    if (Game_Manager.instance != null && Game_Manager.instance.gamelost)
     { 
       if (endgamecrashtimer > 0f)
        {
            endgamecrashtimer -= Time.deltaTime;
        }
    if (endgamecrashtimer <= 0f)
        {
            endgamecrash();
        }
   }


    // 👇 NEW: stop spawning when game ends
    if (Game_Manager.instance != null && Game_Manager.instance.gameEnded)
        return;


    timer += Time.deltaTime;


 
    
    

    if (timer >= nextSpawnTime)
    {
        int randIndex = Random.Range(0, popupPrefabs.Length);
        Instantiate(popupPrefabs[randIndex], popupparent);

        audioSource.PlayOneShot(popupSound, volume);

        timer = 0f;
        nextSpawnTime = Random.Range(0f, spawnmaxtime);
    }
}

public void endgamecrash()
{
    if (endgamneamountcount < endgamemaxcrashspawnamount)
        {
            endgamneamountcount++;
            int randIndex = Random.Range(0, popupPrefabs.Length);
            Instantiate(popupPrefabs[randIndex], popupparent);

            endgamecrashtimer = endgamecrashinterval;
        }
        else
        {
            //find crash ui element called "Crash_screen" by name and enable it
            UI_Manager.instance.crashScreen.SetActive(true);
           
            bluescreentimeshown -= Time.deltaTime;
            Au_LevelMusic.instance.audioSource.volume = 0;

            if (bluescreentimeshown <= 0f)
            {
                Application.Quit();
            }

         
        }
    }      
}       
         
