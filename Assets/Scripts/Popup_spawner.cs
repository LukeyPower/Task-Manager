using UnityEngine;

public class Popup_spawner : MonoBehaviour
{
    //wvariables to spawn in popups
    public GameObject popupPrefab_1;
    public GameObject popupPrefab_2;

    public float spawntime = 2f;
    private float timer =2f;    
    public AudioClip popupSound;
    public float volume = 1.0f;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //spawn a random prefab between 1-5 seconds up to a max spawntime
        timer += Time.deltaTime;
        if (timer >= spawntime)
        {
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                Instantiate(popupPrefab_1, UI_Manager.instance.transform);
                //play popupsound 2d
                audioSource.PlayOneShot(popupSound, volume );
            }
            else
            {
                Instantiate(popupPrefab_2, UI_Manager.instance.transform);
                audioSource.PlayOneShot(popupSound, volume );
            }
            timer = 0f;
        }
    }
}
