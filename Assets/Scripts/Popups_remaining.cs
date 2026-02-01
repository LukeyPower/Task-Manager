using UnityEngine;
using TMPro;

public class UI_PopupCounter : MonoBehaviour
{
    public TextMeshProUGUI popupText;

    [Header("Game Rules")]
    public int maxPopupCount = 600;

    [Header("Visuals")]
    public float baseFontSize = 36f;
    public float dangerFontSize = 48f;
    public float shakeAmount = 4f;

    RectTransform rect;
    Vector3 originalPos;

    void Start()
    {
        rect = popupText.GetComponent<RectTransform>();
        originalPos = rect.localPosition;
        popupText.fontSize = baseFontSize;
    }

    void Update()
    {
        if (Game_Manager.instance == null)
            return;

        int count = Game_Manager.instance.currentPopupCount;

        popupText.text = count.ToString();

        // ----- Colour states -----
        if (count < 5)
            popupText.color = Color.green;
        else if (count < 10)
            popupText.color = Color.yellow;
        else
            popupText.color = Color.red;

        // ----- Danger zone (last 5 before max) -----
        if (count >= maxPopupCount - 5)
        {
            popupText.fontSize = Mathf.Lerp(
                popupText.fontSize,
                dangerFontSize,
                Time.deltaTime * 6f
            );

            // Shake
            rect.localPosition = originalPos + (Vector3)Random.insideUnitCircle * shakeAmount;
        }
        else
        {
            popupText.fontSize = Mathf.Lerp(
                popupText.fontSize,
                baseFontSize,
                Time.deltaTime * 6f
            );

            rect.localPosition = originalPos;
        }
    }
}
