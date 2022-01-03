using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    public void Move(float speed, Transform trsf)
    {
        transform.position = Vector2.MoveTowards(transform.position, trsf.position, speed * Time.deltaTime);
    }
}
