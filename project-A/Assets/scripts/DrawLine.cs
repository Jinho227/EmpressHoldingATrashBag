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
            // ���콺 ��ġ ��������
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // ���콺 ��ġ�� ���� ������Ʈ ��輱 ���η� ����
            mousePosition.x = Mathf.Clamp(mousePosition.x, transform.position.x - objectSize.x / 2f, transform.position.x + objectSize.x / 2f);
            mousePosition.y = Mathf.Clamp(mousePosition.y, transform.position.y - objectSize.y / 2f, transform.position.y + objectSize.y / 2f);

            // ���콺 ��ġ�� Line Renderer�� �߰�
            currentIndex++;
            lineRenderer.positionCount = currentIndex + 1;
            lineRenderer.SetPosition(currentIndex, mousePosition);
        }
    }
}
