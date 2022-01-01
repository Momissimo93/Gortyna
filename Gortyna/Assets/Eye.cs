using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    // Start is called before the first frame update
    private int ground = 1 << 6;

    public float rayLenghtFromEye;

    private Vector2 eye;
    
    public RaycastHit2D eyeRay;

    public void EmittingRay(float direction)
    {
        eye = new Vector2(transform.position.x, transform.position.y);
        eyeRay = Physics2D.Raycast(eye, Vector2.right * direction, rayLenghtFromEye, ground);
    }
    public void DrawRaysFromFeet(float direction)
    {
        Debug.DrawRay(eye, Vector2.right * rayLenghtFromEye * direction, Color.blue);
    }

    public bool IsOnGround()
    {
        return eyeRay;
    }

}
