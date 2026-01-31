using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject clickEffectPrefab;
    public float spawnZ = 10f;
    public Transform parentTransform;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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

