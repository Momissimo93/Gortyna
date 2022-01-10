using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    Vector2 originalPosition;
    Transform transform;
    float distance;
    int direction;

    public void SetParameters(Transform tr, Vector2 originalPos, float dist, int dir)
    {
        transform = tr;
        originalPosition = originalPos;
        distance = dist;
        direction = dir;
    }
    public void Move(Transform tr)
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (2 * direction * Time.deltaTime));
        if (direction == -1 && transform.position.y <= originalPosition.y - distance || direction == 1 && transform.position.y >= originalPosition.y )
        {
            direction *= -1;
        }
    }
}

