using System.Collections.Generic;
using UnityEngine;


public class cutObject : MonoBehaviour
{
    public GameObject objectToCut;
    private Vector3 _startPos;
    private Vector3 _endPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Cut();
        }
    }

    private void Cut()
    {
        var mesh = objectToCut.GetComponent<MeshFilter>().mesh;
        var vertices = mesh.vertices;
        var triangles = mesh.triangles;
        var plane = new Plane(_endPos - _startPos, _startPos);
        var leftVertices = new List<Vector3>();
        var rightVertices = new List<Vector3>();
        for (int i = 0; i < triangles.Length; i += 3)
        {
            var p1 = vertices[triangles[i]];
            var p2 = vertices[triangles[i + 1]];
            var p3 = vertices[triangles[i + 2]];
            var side1 = plane.GetSide(p1);
            var side2 = plane.GetSide(p2);
            var side3 = plane.GetSide(p3);
            if (side1 && side2 && side3)
            {
                leftVertices.Add(p1);
                leftVertices.Add(p2);
                leftVertices.Add(p3);
            }
            else if (!side1 && !side2 && !side3)
            {
                rightVertices.Add(p1);
                rightVertices.Add(p2);
                rightVertices.Add(p3);
            }
            else
            {
                float distance;
                Ray ray;
                if (side1 != side2)
                {
                    ray = new Ray(p1, p2 - p1);
                    plane.Raycast(ray, out distance);
                    var point = ray.GetPoint(distance);
                    leftVertices.Add(p1);

                    if (side1)
                    {
                        leftVertices.Add(point);
                        rightVertices.Add(point);
                    }
                    else
                    {
                        rightVertices.Add(point);
                        leftVertices.Add(point);
                    }
                }
                else if (side2 != side3)
                {
                    ray = new Ray(p2, p3 - p2);
                    plane.Raycast(ray, out distance);
                    var point = ray.GetPoint(distance);

                    if (side2)
                    {
                        leftVertices.Add(point);
                        rightVertices.Add(point);
                    }
                    else
                    {
                        rightVertices.Add(point);
                        leftVertices.Add(point);
                    }

                    rightVertices.Add(p2);

                }
                else if (side1 != side3)
                {
                    ray = new Ray(p1, p3 - p1);
                    plane.Raycast(ray, out distance);
                    var point = ray.GetPoint(distance);

                    if (side1)
                    {
                        leftVertices.Add(point);
                        rightVertices.Add(point);
                    }
                    else
                    {
                        rightVertices.Add(point);
                        leftVertices.Add(point);
                    }

                    rightVertices.Add(p1);

                }
            }
        }

        CreateMesh(leftVertices.ToArray(), objectToCut.transform.GetChild(0).gameObject, "Left");
        CreateMesh(rightVertices.ToArray(), objectToCut.transform.GetChild(0).gameObject, "Right");
        Destroy(objectToCut.gameObject);

    }

    private void CreateMesh(Vector3[] vertices, GameObject parent, string name)
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        int[] triangles = new int[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            triangles[i] = i;
        }
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GameObject obj = new GameObject(name + " " + parent.name);

        parent.transform.position = obj.transform.position;
        parent.transform.rotation = obj.transform.rotation;
        obj.transform.parent = parent.transform;
        obj.AddComponent<MeshFilter>();
        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshFilter>().mesh = mesh;
        obj.GetComponent<MeshRenderer>().material = parent.GetComponent<MeshRenderer>().material;
    }
}