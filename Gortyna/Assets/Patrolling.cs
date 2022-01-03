using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public void Move(float s, RightFoot ft, float direction)
    {
        
        transform.position = new Vector2(transform.position.x + (s * direction * Time.deltaTime), transform.position.y);
    }
}
