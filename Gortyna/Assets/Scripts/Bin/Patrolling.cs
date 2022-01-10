using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public void Move(float s, float direction, Transform tra )
    {
        tra.position = new Vector2(tra.position.x + (s * direction * Time.deltaTime), tra.position.y);
    }
}
