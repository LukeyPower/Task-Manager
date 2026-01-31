using UnityEngine;

public class Popup_window : MonoBehaviour
{
public AudioClip popdownSound;
private AudioSource audioSource;
private GameObject audiomanager;


    public void ClosePopup()
    {
        Destroy(gameObject);
        audioSource.PlayOneShot(popdownSound, 1.0f);
  
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {

        audiomanager = GameObject.Find("AudioManager");
        audioSource = audiomanager.GetComponent<AudioSource>();
        //Unannote below ------
        popdownSound = Resources.Load<AudioClip>("popdown");
    }
void OnEnable()
{
    Game_Manager.instance.RegisterPopup();
}

void OnDestroy()
{
    if (Game_Manager.instance != null)
        Game_Manager.instance.UnregisterPopup();
}
}