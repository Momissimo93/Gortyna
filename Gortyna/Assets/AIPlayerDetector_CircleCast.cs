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
    
    private int groundLayer = 1 << 6;
    private int enemyLayer = 1 << 8;
    private int coinLayer = 1 << 11;

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
            //RaycastHit2D targetLine = Physics2D.Linecast(transform.position, Target.transform.position);
            //DrawTargetLine(targetLine);
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

                if (arrayOfElements[i].collider.gameObject.GetComponent<Human>())
                {

                    RaycastHit2D targetLine = Physics2D.Linecast(transform.position, arrayOfElements[i].collider.gameObject.transform.position, ~(enemyLayer + coinLayer + groundLayer));
                    DrawTargetLine(targetLine);

                    if (targetLine.collider.transform.gameObject.GetComponent<Human>())
                    {
                        Debug.Log("I can see the player");
                        Target = arrayOfElements[i].transform.gameObject;

                    }
                    else
                    {
                        Debug.Log("There is an element before the player i can not see him anymore ");
                        Debug.Log(targetLine.collider.transform.gameObject.name);
                        Target = null;
                    }
                    //DrawTargetLine(arrayOfElements[i])
                }
                else
                {
                    //Target = null;
                    //Debug.Log("I can not see the player");
                }
            }
        }
        else
        {
            Target = null;
            Debug.Log("I can not see the player");
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
