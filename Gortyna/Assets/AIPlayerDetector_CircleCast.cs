using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerDetector_CircleCast : MonoBehaviour
{
    [SerializeField]
    private Transform detectorOrigin;
    public Vector2 detectorOriginOffset = Vector2.zero;
    public float detectorRadius = 0.0f;
    public float detectorDistance = 0.0f;
    public LayerMask detectorLayer;

    private GameObject target;
    public bool playerDetected { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    public void PerformDetection()
    {
        RaycastHit2D circleCast = Physics2D.CircleCast((Vector2)detectorOrigin.position + detectorOriginOffset, detectorRadius, Vector2.zero, detectorDistance, detectorLayer);

        if (circleCast.collider != null)
        {
            Target = circleCast.collider.gameObject;
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
    private void DrawTargetLine(RaycastHit2D r)
    {
        Debug.DrawLine(transform.position, r.collider.gameObject.transform.position, Color.yellow);
    }
}
