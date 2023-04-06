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
            // 마우스 버튼이 눌렸을 때 새로운 선을 생성합니다.
            currentLine = Instantiate(linePrefab, transform);
            startPoint = GetMousePosInCanvas();
            currentLine.rectTransform.anchoredPosition = startPoint;
        }
        else if (Input.GetMouseButton(0))
        {
            // 마우스 버튼이 눌린 상태에서 마우스 위치까지 선을 그립니다.
            Vector2 currentPoint = GetMousePosInCanvas();
            currentLine.rectTransform.sizeDelta = new Vector2(Vector2.Distance(startPoint, currentPoint), 3f);
            currentLine.rectTransform.right = (currentPoint - startPoint).normalized;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 마우스 버튼이 떼어졌을 때 선을 그리는 작업을 종료합니다.
            currentLine = null;
        }
    }

    private Vector2 GetMousePosInCanvas()
    {
        // 마우스 위치를 캔버스 안의 위치로 변환합니다.
        Vector2 mousePos = Input.mousePosition;
        Vector2 canvasSize = canvasRect.sizeDelta;
        Vector2 canvasPos = canvasRect.position;
        return (mousePos - canvasPos) / canvasSize * canvasRect.localScale.x;
    }
}
