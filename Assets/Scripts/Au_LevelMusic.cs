using UnityEngine;

public class Au_LevelMusic : MonoBehaviour
{
    public AudioClip    levelMusic;
    public AudioSource audioSource;

    public static Au_LevelMusic instance;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = levelMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
