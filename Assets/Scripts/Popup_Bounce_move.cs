using UnityEngine;

public class Popup_BounceMove : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 150f;

   //variables to make the instances of my ui element bounce around screen
    private RectTransform rectTransform;
    private Vector2 direction;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    public float bottomOffset = 40f;
    public float rightsideOffset = 100f;
    public float leftsideOffset = 40f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Calculate screen bounds in canvas space
        Canvas canvas = GetComponentInParent<Canvas>();
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        screenBounds = new Vector2(canvasRect.rect.width / 2, canvasRect.rect.height / 2);

        objectWidth = rectTransform.rect.width / 2;
        objectHeight = rectTransform.rect.height / 2;

        // Set a random initial direction
        direction = Random.insideUnitCircle.normalized;

        rectTransform.anchoredPosition = new Vector2(
            Random.Range(-screenBounds.x + objectWidth, screenBounds.x - objectWidth),
            Random.Range(-screenBounds.y + objectHeight, screenBounds.y - objectHeight)
        );
    }
    // Update is called once per frame
    void Update()
    {
        // Move the popup
        rectTransform.anchoredPosition += direction * speed * Time.deltaTime;

        // Check for collisions with screen bounds with a bottom offset (to bring bounce hiehgt uo) and reverse direction
        if (rectTransform.anchoredPosition.x + objectWidth > screenBounds.x + rightsideOffset || rectTransform.anchoredPosition.x - objectWidth < -screenBounds.x - leftsideOffset)
        {
            direction.x = -direction.x;
        }   
        if (rectTransform.anchoredPosition.y + objectHeight > screenBounds.y || rectTransform.anchoredPosition.y - objectHeight < -screenBounds.y + bottomOffset)
        {
            direction.y = -direction.y;
        }  
    }
}

       
