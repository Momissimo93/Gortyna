using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] Transform detectorOrigin;
    [SerializeField] Vector2 detectorOriginOffset = Vector2.zero;
    [SerializeField] float detectorRadius = 0.0f;
    [SerializeField] LayerMask detectorLayer;
    [SerializeField] private Enemy enemy;

    [SerializeField] float bounce;

    //An alternative way for the bouncing system. The worm has a box collider attached to it. For the Slime I wanted to use a CircleCast
    public void PerformDetection()
    {
        RaycastHit2D range = Physics2D.CircleCast((Vector2)detectorOrigin.position + detectorOriginOffset, detectorRadius, Vector2.zero, 1, detectorLayer);
        if (range)
        {
            if (range.collider.gameObject.CompareTag("Hero"))
            {
                Human human = range.collider.gameObject.GetComponent<Human>();
                if (human.isOnGround == false && human.canMove == true)
                {
                    human.rigidBody.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
                    enemy.TakeDamage(1, human, enemy);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectorOrigin.transform.position, detectorRadius);
    }
}
