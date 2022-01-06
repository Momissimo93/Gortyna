using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AIPlayerDetector_CircleCast : MonoBehaviour
{
    [SerializeField]
    private Transform detectorOrigin;
    [SerializeField]
    private Vector2 detectorOriginOffset = Vector2.zero;
    [SerializeField]
    private float detectorRadius = 0.0f;
    [SerializeField]
    private float detectorDistance = 0.0f;
    [SerializeField]
    private LayerMask detectorLayer;

    private GameObject target;
    public bool playerDetected { get; private set; }
    
    private int groundLayer = 1 << 6;
    private int enemyLayer = 1 << 8;
    private int coinLayer = 1 << 11;

    public bool attack = true;
    public int direction = 0;

    void Update()
    {
        PerformDetection();

        if (target)
        {
            float distance = target.transform.position.x - transform.position.x;
            if (distance > -1 && distance < 1)
            {
                Rigidbody2D rb = transform.gameObject.GetComponent<Rigidbody2D>();
                {
                    attack = true;
                }
            }
            else
                attack = false;
        }
        CheckDirection();
    }
    private void CheckDirection()
    {
        if (target && detectorOrigin)
        {
            if (target.transform.position.x - detectorOrigin.transform.position.x > 0.1f)
            {
                direction = 1;
            }
            else if (target.transform.position.x - detectorOrigin.transform.position.x < 0.1f)
            {
                direction = -1;
            }
        }
    }
    public GameObject Target
    {
        //get => target;
        //get accessor implemented by Expression Bodied
        get => target;

        private set
        {
            target = value;
            playerDetected = target != null;
        }
    }
    public void PerformDetection()
    {
        //RaycastHit2D circleCast  = Physics2D.CircleCast((Vector2)detectorOrigin.position + detectorOriginOffset, detectorRadius, Vector2.zero, detectorDistance, detectorLayer);

        /*if (circleCast.collider != null)
        {
            Target = circleCast.collider.gameObject;
        }
        else
        {
            Target = null;
        }*/
        RaycastHit2D[] arrayOfElements = Physics2D.CircleCastAll((Vector2)detectorOrigin.position + detectorOriginOffset, detectorRadius, Vector2.zero, 1, ~(enemyLayer + coinLayer + groundLayer));
        if(arrayOfElements.Length > 0)
        {
            for (int i = 0; i < arrayOfElements.Length; i++)
            {
                RaycastHit2D targetLine = Physics2D.Linecast(transform.position, arrayOfElements[i].collider.gameObject.transform.position, ~(enemyLayer + coinLayer + groundLayer));

                if (targetLine)
                {
                    if (targetLine.collider.transform.gameObject.GetComponent<Human>())
                    {
                        DrawTargetLine(targetLine, Color.yellow);
                        Target = arrayOfElements[i].transform.gameObject;
                        break;
                    }
                    else if (!targetLine.collider.transform.gameObject.GetComponent<Human>())
                    {
                        DrawTargetLine(targetLine, Color.red);
                        Target = null;
                    }
                    else
                        Target = null;
                }
            }
        }
        else
        {
            Target = null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(detectorOrigin.transform.position, detectorRadius);
    }
    private void DrawTargetLine(RaycastHit2D r, Color c)
    {
        Debug.DrawLine(transform.position, r.collider.gameObject.transform.position, c);
    }
}
