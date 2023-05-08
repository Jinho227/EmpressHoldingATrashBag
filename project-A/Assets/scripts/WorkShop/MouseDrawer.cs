using UnityEngine;

public class MouseDrawer : MonoBehaviour
{
    public GameObject linePrefab;
    public float lineWidth = 0.1f;
    public Color lineColor = Color.white;

    private GameObject currentLine;
    private LineRenderer lineRenderer;
    private Vector3 mousePos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        if (Input.GetMouseButton(0))
        {
            ContinueDrawing();
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndDrawing();
        }
    }

    void StartDrawing()
    {
        currentLine = Instantiate(linePrefab);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        lineRenderer.SetPosition(0, mousePos);
    }

    void ContinueDrawing()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, mousePos);
    }

    void EndDrawing()
    {
        currentLine = null;
    }
}
