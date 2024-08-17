using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShapeController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite[] shapeSprites;

    [SerializeField] private PolygonCollider2D polygonCollider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            ChangeShape(shapeSprites[0]);
        if (Input.GetKeyDown(KeyCode.Keypad2))
            ChangeShape(shapeSprites[1]);
        if (Input.GetKeyDown(KeyCode.Keypad3))
            ChangeShape(shapeSprites[2]);
    }



    private void ChangeShape(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;

        RecalculatePolygonColliderShape();
    }

    private void RecalculatePolygonColliderShape()
    {
        // Clear the current paths on the polygon collider
        polygonCollider.pathCount = 0;

        // Get the number of shapes (polygons) in the sprite's physics shape
        int shapeCount = spriteRenderer.sprite.GetPhysicsShapeCount();
        polygonCollider.pathCount = shapeCount;

        // For each shape (polygon) in the physics shape, get the vertices and set them as the collider's path
        for (int i = 0; i < shapeCount; i++)
        {
            List<Vector2> shapeVertices = new List<Vector2>();
            spriteRenderer.sprite.GetPhysicsShape(i, shapeVertices); // Populate the vertices for this shape
            polygonCollider.SetPath(i, shapeVertices.ToArray()); // Set the vertices as the collider's path
        }
    }
}
