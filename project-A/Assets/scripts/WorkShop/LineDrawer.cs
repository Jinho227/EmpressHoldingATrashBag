using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LineDrawer : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public RectTransform canvasRectTransform;
    public Image lineImage;
    public float lineWidth = 10f;
    public Color lineColor = Color.white;

    private RectTransform rectTransform;
    private Vector2 startPos;
    private Vector2 endPos;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = ClampToCanvas(eventData.position);
        endPos = startPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        endPos = ClampToCanvas(eventData.position);
        DrawLine();
    }

    private Vector2 ClampToCanvas(Vector2 pos)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, pos, null, out localPoint);
        return localPoint;
    }

    private void DrawLine()
    {
        Vector2 dir = endPos - startPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float length = dir.magnitude;
        lineImage.rectTransform.sizeDelta = new Vector2(length, lineWidth);
        lineImage.rectTransform.pivot = new Vector2(0, 0.5f);
        lineImage.rectTransform.position = startPos;
        lineImage.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
        lineImage.color = lineColor;
    }
}
