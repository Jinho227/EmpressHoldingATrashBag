using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public GameObject Leatheryou;
    public GameObject Leatherme;
    private bool clear = false;

    private void Start()
    {

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!clear)
        {
            rectTransform.anchoredPosition += eventData.delta;
        }
        else
        {

        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float distance = Vector2.Distance(Leatherme.transform.position, Leatheryou.transform.position);
        if(distance < 100)
        {
            Leatherme.transform.position = Leatheryou.transform.position;
            clear = true;
        }
        else
        {

        }
    }
}
