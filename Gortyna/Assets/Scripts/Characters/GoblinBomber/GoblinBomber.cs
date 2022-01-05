using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBomber : MonoBehaviour
{
    public Bomb b;

    private Animator animator;
    private AIPlayerDetector_OverlapBox playerDetector_OverlapBox;
    private ThrowingBombs throwingBombs;
    private bool isFirying = false;
    private bool facingRight = true;

    private GameObject target;
    private GameObject oldTarget;

    [SerializeField] GameObject spawnPoint;

    public int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerDetector_OverlapBox = gameObject.GetComponent<AIPlayerDetector_OverlapBox>();
        throwingBombs = gameObject.GetComponent<ThrowingBombs>();
        if(gameObject.GetComponent<Animator>())
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDetector_OverlapBox.playerDetected)
        {
            if(isFirying == false)
            {
                StartCoroutine("ThrowingBombs");
            }
        }
        if (playerDetector_OverlapBox.direction == 1 && direction == -1)
        {
            Debug.Log("Change direction");
            transform.Rotate(0f, 180f, 0f);
            direction *= -1;
        }
        else if (playerDetector_OverlapBox.direction == -1 && direction == 1)
        {
            Debug.Log("Change direction");
            transform.Rotate(0f, 180f, 0f);
            direction *= -1;
        }
    }

    IEnumerator ThrowingBombs()
    {
        isFirying = true;
        animator.SetBool("ThrowingBomb", isFirying);

        yield return new WaitForSeconds(0.5f);

        target = playerDetector_OverlapBox.GetTarget();

        if(target == null)
        {
            if(oldTarget == null)
            {
                //I force it to find the human, if not the bomb does not know where to go if i suddently exit the area 
                GameObject gb = GameObject.FindObjectOfType<Human>().gameObject;
                b.SetTarget(gb);
            }
            else
            {
                b.SetTarget(oldTarget);
            }
        }
        else
        {
            b.SetTarget(target);
            oldTarget = target;
        }

        animator.SetBool("ThrowingBomb", true);
        throwingBombs.Fire(b, spawnPoint);

        yield return new WaitForSeconds(1.0f);

        isFirying = false;
        animator.SetBool("ThrowingBomb", isFirying);
    }
    IEnumerator Turn()
    {
        Debug.Log("Turn");
        yield return new WaitForSeconds(0.3f);
        transform.Rotate(0f, 180f, 0f);
    }
}
