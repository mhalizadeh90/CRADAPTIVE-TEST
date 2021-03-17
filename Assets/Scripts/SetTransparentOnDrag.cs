using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(CanvasGroup))]
public class SetTransparentOnDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    CanvasGroup canvasGroup;


    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SetTransparent();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ResetTransparency();
    }


    void SetTransparent()
    {
        if (isSlotEmpty())
            return;

        canvasGroup.alpha = 0.8f;
    }

    void ResetTransparency()
    {
        if (isSlotEmpty())
            return;

        canvasGroup.alpha = 1;
    }

    bool isSlotEmpty()
    {
        return (canvasGroup.alpha == 0);
    }


}
