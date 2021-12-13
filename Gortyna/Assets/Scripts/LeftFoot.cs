using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftFoot: MonoBehaviour
{
    private Vector2 leftFoot;
    public BoxCollider2D boxCollider2D;
    public float rayLenghtFromFeet;
    private int ground = 1 << 6;
    public RaycastHit2D leftFootRays;

    public void EmittingRay()
    {
        leftFoot = new Vector2(boxCollider2D.bounds.min.x, boxCollider2D.bounds.min.y);
        leftFootRays = Physics2D.Raycast(leftFoot, Vector2.down, rayLenghtFromFeet, ground);
    }
    public void DrawRaysFromFeet()
    {
        Debug.DrawRay(leftFoot, Vector2.down * rayLenghtFromFeet, Color.blue);
    }
}
