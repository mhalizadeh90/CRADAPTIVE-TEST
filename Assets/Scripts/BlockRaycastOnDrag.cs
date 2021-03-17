using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(CanvasGroup))]
public class BlockRaycastOnDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        BlockRaycast();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UnBlockRaycast();
    }


    void BlockRaycast()
    {
        canvasGroup.blocksRaycasts = false;
    }

    void UnBlockRaycast()
    {
        canvasGroup.blocksRaycasts = true;
    }

}
