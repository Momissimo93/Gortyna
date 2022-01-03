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
        if (playerDetector_OverlapBox.direction == 1 && facingRight == false)
        {
            StartCoroutine("Turn");
            facingRight = true; 
        }
        else if (playerDetector_OverlapBox.direction == -1 && facingRight == true)
        {
            StartCoroutine("Turn");
            facingRight = false; 
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
            b.SetTarget(oldTarget);
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
        yield return new WaitForSeconds(0.3f);
        transform.Rotate(0f, 180f, 0f);
    }
}
