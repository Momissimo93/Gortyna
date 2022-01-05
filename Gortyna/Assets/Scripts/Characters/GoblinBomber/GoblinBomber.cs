using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBomber : Enemy
{
    public Bomb b;

    public AIPlayerDetector_OverlapBox playerDetector_OverlapBox;
    public ThrowingBombs throwingBombs;
    [SerializeField] GameObject spawnPoint;

    private bool isFirying = false;
    private GameObject target;
    private GameObject oldTarget;

    void Update()
    {
        PlayerCheck();
        if (playerDetector_OverlapBox.playerDetected)
        {
            if(isFirying == false)
            {
                StartCoroutine("ThrowingBombs");
            }
        }
    }
    void PlayerCheck()
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
}
