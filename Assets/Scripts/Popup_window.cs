using UnityEngine;

public class Popup_window : MonoBehaviour
{
public AudioClip popdownSound;
    public void ClosePopup()
    {
        Destroy(gameObject);
        //play popdown sound 2d
        //Unannote below ------
        //AudioSource.PlayClipAtPoint(popdownSound, Camera.main.transform.position);
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Unannote below ------
       // popdownSound = Resources.Load<AudioClip>("popdown");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
