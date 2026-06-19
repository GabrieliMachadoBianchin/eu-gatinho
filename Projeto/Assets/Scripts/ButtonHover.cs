using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour,
IPointerEnterHandler,
IPointerExitHandler
{
    Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale =
            initialScale * 1.08f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale =
            initialScale;
    }
}