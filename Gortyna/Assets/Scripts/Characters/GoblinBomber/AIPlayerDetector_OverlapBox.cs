using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerDetector_OverlapBox : MonoBehaviour
{
    [field: SerializeField]
    public bool playerDetected { get; private set;}

    [SerializeField]
    private Transform detectorOrigin;
    public Vector2 detectorSize = Vector2.one;
    public Vector2 detectorOriginOffset = Vector2.zero;

    public Color gizmoIdleColor = Color.green;
    public Color gizmoDetectedColor = Color.red;
    public bool showGizmos = true;

    public float detectionDelay;

    private GameObject target;

    public LayerMask detectorLayer;

    public int direction; 

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DetectionCoroutine());
    }
    private void Update()
    {
        PerformDetection();
        if (target)
        {
            RaycastHit2D targetLine = Physics2D.Linecast(transform.position, Target.transform.position, (detectorLayer));
            DrawTargetLine(targetLine);
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
        Collider2D collider = Physics2D.OverlapBox((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize, 0, detectorLayer );
        if(collider != null)
        {
            Target = collider.gameObject;
        }
        else
        {
            Target = null;
        }
    }

    private void CheckDirection()
    {
        if (target && detectorOrigin)
        {
            if (target.transform.position.x - detectorOrigin.transform.position.x > 0.0f)
            {
                direction = 1;
                Debug.Log(direction);
            }
            else if (target.transform.position.x - detectorOrigin.transform.position.x < 0.5f)
            {
                direction = -1;
                Debug.Log(direction);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(showGizmos && detectorOrigin != null)
        {
            Gizmos.color = gizmoIdleColor;

            Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize) ;
        }
    }
    private void DrawTargetLine(RaycastHit2D r)
    {

        Debug.DrawLine(transform.position, r.collider.gameObject.transform.position, Color.yellow);
    }
}