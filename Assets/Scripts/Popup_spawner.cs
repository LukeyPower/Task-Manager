using UnityEngine;

public class Popup_spawner : MonoBehaviour
{
    //wvariables to spawn in popups
    public GameObject[] popupPrefabs;
   
    public float spawntime = 2f;
    private float timer =2f;    
    public AudioClip popupSound;
    public float volume = 1.0f;
    private AudioSource audioSource;

    public float initalspawnamount = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

          //onawake spawn 5 random popupsPrefabs at random locations on the screen
        for (int i = 0; i < initalspawnamount; i++)
        {
            int randIndex = Random.Range(0, popupPrefabs.Length);
            Instantiate(popupPrefabs[randIndex], UI_Manager.instance.transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //spawn a random prefab from the array between 1-5 seconds up to a max spawntime
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            int randIndex = Random.Range(0, popupPrefabs.Length);
            Instantiate(popupPrefabs[randIndex], UI_Manager.instance.transform);
            timer = Random.Range(1f, spawntime);
            audioSource.PlayOneShot(popupSound, volume);
        }
    }
}
