using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBomber : Enemy
{
    [SerializeField] private Bomb b;
    [SerializeField] private AIPlayerDetector_OverlapBox playerDetector_OverlapBox;
    [SerializeField] private ThrowingBombs throwingBombs;
    [SerializeField] private GameObject spawnPoint;

    private bool isFirying = false;
    private GameObject target;
    private GameObject oldTarget;

    void Update()
    {
        SetDirection();
        if (playerDetector_OverlapBox.playerDetected)
        {
            //This variable avoid the spawing of Bomb object at each frame. What we want is the spawning of Bomb game object at a fixed time. 
            if(isFirying == false)
            {
                isFirying = true;
                StartCoroutine("ThrowingBombs");
            }
        }
    }
    void SetDirection()
    {
        if (playerDetector_OverlapBox.playerDetected)
        {
            if (playerDetector_OverlapBox.direction == 1 && direction == -1)
            {
                transform.Rotate(0f, 180f, 0f);
                direction *= -1;
            }
            else if (playerDetector_OverlapBox.direction == -1 && direction == 1)
            {
                transform.Rotate(0f, 180f, 0f);
                direction *= -1;
            }
        }
    }
    IEnumerator ThrowingBombs()
    {
        animator.SetBool("ThrowingBomb", isFirying);
        yield return new WaitForSeconds(0.7f);
        target = playerDetector_OverlapBox.GetTarget();

        /* I had an issue: once the Human moved out from the field of view of the GoblinBomber the bomb just fell over its feet, not knowing where to go as the Target suddently 
         * became Null. This is the how i solved it.
         */
        if (playerDetector_OverlapBox.GetTarget() == null && isFirying == true)
        {
            if(oldTarget == null)
            {
                //I force it to find the human, if not the bomb does not know where to go if he suddently exits the area 
                GameObject gb = GameObject.FindObjectOfType<Human>().gameObject;
                b.SetTarget(gb);
            }
            else if (oldTarget)
            {
                //If the target becomes immediately null we want the GoblinBomber to at least spawn a bomb
                b.SetTarget(oldTarget);
            }
        }
        else if (playerDetector_OverlapBox.GetTarget() != null)
        {
            b.SetTarget(target);
            oldTarget = target;
        }

        animator.SetBool("ThrowingBomb", false);
        throwingBombs.Fire(b, spawnPoint);
        yield return new WaitForSeconds(2.0f);
        isFirying = false;
    }
}
