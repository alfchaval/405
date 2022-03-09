using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class FixedJoystick : Joystick
{
    [Header("Fixed Joystick")]    

    Vector2 joystickPosition = Vector2.zero;
    private Camera cam = new Camera();
    Vector2 startingPosition;

    public Color handleColor;
    public Color backgroundColor;
    public Color temporalColor;

    float distanciaInvisible = 10000f;

    void Start()
    {
        joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, background.position);
        handleColor = handle.GetComponent<Image>().color;
        backgroundColor = background.GetComponent<Image>().color;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - startingPosition;
        inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
        handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;
        temporalColor = handleColor;
        temporalColor.a = handleColor.a - Vector2.SqrMagnitude(direction) * handleColor.a / distanciaInvisible;
        handle.GetComponent<Image>().color = temporalColor;
        temporalColor = backgroundColor;
        temporalColor.a = backgroundColor.a - Vector2.SqrMagnitude(direction) * backgroundColor.a / distanciaInvisible;
        background.GetComponent<Image>().color = temporalColor;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        startingPosition = eventData.position;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
        handle.GetComponent<Image>().color = handleColor;
        background.GetComponent<Image>().color = backgroundColor;
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}