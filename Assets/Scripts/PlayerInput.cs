using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerInput : MonoBehaviour
{
    public GameObject clickEffectPrefab;
    public float spawnZ = 10f;
    public Transform parentTransform;
    public int shotcount = 0;

    public AudioClip[] gunshot;
    private AudioSource audioSource;
    public float volume = 1.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Mouse mouse = Mouse.current;
            InputSystem.QueueStateEvent(mouse, new MouseState
            {
            position = Input.mousePosition,
            buttons = 1 // left button pressed
            });
            InputSystem.QueueStateEvent(mouse, new MouseState
            {
            position = Input.mousePosition,
            buttons = 0 // left button released
            });


            SpawnClickEffect();
            gunshotaudio();
            shotcount++;
            

        }
    }

    void SpawnClickEffect()
    {
        if (clickEffectPrefab == null) return;

        Vector3 mousePos = Input.mousePosition;

        Instantiate(clickEffectPrefab, mousePos, Quaternion.identity, UI_Manager.instance.transform);

        
    }

     void gunshotaudio()
        {
        //play randon gunshot from array
        int randIndex = Random.Range(0, gunshot.Length);
        audioSource.PlayOneShot(gunshot[randIndex], volume);

    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

}

   

