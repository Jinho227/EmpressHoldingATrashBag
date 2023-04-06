using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCutter : MonoBehaviour
{
    // The image to cut
    public Image image;

    // The game object to use for the cut image
    public GameObject cutImageObject;

    // The material to use for the cut image
    public Material cutImageMaterial;

    // The texture to use for the cut image
    private Texture2D cutImageTexture;

    // The starting and ending positions for the cut
    private Vector2 startCutPosition;
    private Vector2 endCutPosition;

    // The size of the cut area
    private Vector2 cutSize;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Record the starting position for the cut
            startCutPosition = GetMousePosition();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Record the ending position for the cut
            endCutPosition = GetMousePosition();

            // Calculate the size of the cut area
            cutSize = new Vector2(Mathf.Abs(endCutPosition.x - startCutPosition.x), Mathf.Abs(endCutPosition.y - startCutPosition.y));

            // Create a new texture for the cut image
            cutImageTexture = new Texture2D((int)cutSize.x, (int)cutSize.y);

            // Copy the pixels from the original image to the cut image texture
            for (int x = 0; x < cutSize.x; x++)
            {
                for (int y = 0; y < cutSize.y; y++)
                {
                    Color pixel = image.sprite.texture.GetPixel((int)startCutPosition.x + x, (int)startCutPosition.y + y);
                    cutImageTexture.SetPixel(x, y, pixel);
                }
            }

            // Apply the changes to the cut image texture
            cutImageTexture.Apply();

            // Set the cut image texture as the material's texture for the new game object
            cutImageMaterial.mainTexture = cutImageTexture;

            // Create a new game object for the cut image
            GameObject newCutImageObject = Instantiate(cutImageObject, transform.position, Quaternion.identity);

            // Set the material of the new game object to the cut image material
            newCutImageObject.GetComponent<MeshRenderer>().material = cutImageMaterial;
        }
    }

    // Helper function to get the position of the mouse in local coordinates
    private Vector2 GetMousePosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = image.transform.InverseTransformPoint(mousePosition);
        return mousePosition;
    }
}
