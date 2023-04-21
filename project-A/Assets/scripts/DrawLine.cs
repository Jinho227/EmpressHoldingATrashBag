using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private int currentIndex;
    public Vector2 objectSize;

    void Start()
    {
        currentIndex = 0;

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // 마우스 위치 가져오기
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 마우스 위치를 게임 오브젝트 경계선 내부로 제한
            mousePosition.x = Mathf.Clamp(mousePosition.x, transform.position.x - objectSize.x / 2f, transform.position.x + objectSize.x / 2f);
            mousePosition.y = Mathf.Clamp(mousePosition.y, transform.position.y - objectSize.y / 2f, transform.position.y + objectSize.y / 2f);

            // 마우스 위치를 Line Renderer에 추가
            currentIndex++;
            lineRenderer.positionCount = currentIndex + 1;
            lineRenderer.SetPosition(currentIndex, mousePosition);
        }
    }
}
