using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    public void Move(float speed, Transform target, Transform current)
    {
        current.position = Vector2.MoveTowards(current.position, new Vector3 (target.position.x, current.position.y, target.position.y), speed * Time.deltaTime);
    }
}
