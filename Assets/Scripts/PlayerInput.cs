using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerInput : MonoBehaviour
{
    public GameObject clickEffectPrefab;
    public float spawnZ = 10f;
    public Transform parentTransform;

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
        }
    }

    void SpawnClickEffect()
    {
        if (clickEffectPrefab == null) return;

        Vector3 mousePos = Input.mousePosition;

              
        Instantiate(clickEffectPrefab, mousePos, Quaternion.identity, UI_Manager.instance.transform);
    }
}

