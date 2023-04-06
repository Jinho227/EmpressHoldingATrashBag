using UnityEngine;
using UnityEngine.UI;

public class DrawLine : MonoBehaviour
{
    public RectTransform canvasRect;
    public Image linePrefab;

    private Image currentLine;
    private Vector2 startPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ��ư�� ������ �� ���ο� ���� �����մϴ�.
            currentLine = Instantiate(linePrefab, transform);
            startPoint = GetMousePosInCanvas();
            currentLine.rectTransform.anchoredPosition = startPoint;
        }
        else if (Input.GetMouseButton(0))
        {
            // ���콺 ��ư�� ���� ���¿��� ���콺 ��ġ���� ���� �׸��ϴ�.
            Vector2 currentPoint = GetMousePosInCanvas();
            currentLine.rectTransform.sizeDelta = new Vector2(Vector2.Distance(startPoint, currentPoint), 3f);
            currentLine.rectTransform.right = (currentPoint - startPoint).normalized;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // ���콺 ��ư�� �������� �� ���� �׸��� �۾��� �����մϴ�.
            currentLine = null;
        }
    }

    private Vector2 GetMousePosInCanvas()
    {
        // ���콺 ��ġ�� ĵ���� ���� ��ġ�� ��ȯ�մϴ�.
        Vector2 mousePos = Input.mousePosition;
        Vector2 canvasSize = canvasRect.sizeDelta;
        Vector2 canvasPos = canvasRect.position;
        return (mousePos - canvasPos) / canvasSize * canvasRect.localScale.x;
    }
}
