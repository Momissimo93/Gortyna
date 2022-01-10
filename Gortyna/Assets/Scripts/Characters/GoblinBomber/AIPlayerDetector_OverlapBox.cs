using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerDetector_OverlapBox : MonoBehaviour
{
    public bool playerDetected { get; private set;}

    [SerializeField] private Transform detectorOrigin;
    [SerializeField] private Vector2 detectorSize = Vector2.one;
    [SerializeField] private Vector2 detectorOriginOffset = Vector2.zero;
    [SerializeField] private Color gizmoIdleColor = Color.green;
    [SerializeField] private Color gizmoDetectedColor = Color.red;
    [SerializeField] private bool showGizmos = true;
    [SerializeField] private LayerMask detectorLayer;
    [SerializeField] private float detectionDelay;

    public int direction;

    private GameObject target;

    private void Update()
    {
        PerformDetection();
        if (target)
        {
            RaycastHit2D targetLine = Physics2D.Linecast(transform.position, Target.transform.position, (detectorLayer));
            DrawTargetLine(targetLine, Color.red);
        }
        CheckDirection();
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
    public GameObject GetTarget()
    {
        if (target)
        {
            return target;
        }
        else 
            return null;
    }
    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionDelay);
        PerformDetection();
        StartCoroutine(DetectionCoroutine());
    }
    public void PerformDetection()
    {
        Collider2D [] colliders = Physics2D.OverlapBoxAll((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize, 0, detectorLayer );
        for(int i = 0; i < colliders.Length; i ++)
        {
            RaycastHit2D targetLine = Physics2D.Linecast(transform.position, colliders[i].gameObject.transform.position, (detectorLayer));
            if(targetLine)
            {
                if (targetLine.collider.transform.gameObject.GetComponent<Human>())
                {
                    DrawTargetLine(targetLine, Color.yellow);
                    Target = colliders[i].transform.gameObject;
                    break;
                }
                else
                    DrawTargetLine(targetLine, Color.red);
                    Target = null;
            }
        }
    }
    private void CheckDirection()
    {
        if (target && detectorOrigin)
        {
            if (target.transform.position.x - detectorOrigin.transform.position.x > 1f)
            {
                direction = 1;
            }
            else if (target.transform.position.x - detectorOrigin.transform.position.x < -1f)
            {
                direction = -1;
            }
        }
    }
    private void OnDrawGizmos()
    {
        if((showGizmos && detectorOrigin != null) && target == null)
        {
            Gizmos.color = gizmoIdleColor;
            Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize) ;
        }
        else if ((showGizmos && detectorOrigin && target != null))
        {
            Gizmos.color = gizmoDetectedColor;
            Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize);
        }
    }
    private void DrawTargetLine(RaycastHit2D r,Color c)
    {
        Debug.DrawLine(transform.position, r.collider.gameObject.transform.position, c);
    }
}
