using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Trap
{
    public float speed;
    Rigidbody2D rdbody2D;
    public GameObject target;
    Vector2 moveDirection;
    public float force = 0.9f;
    //Animator animator;
    //public int direction;

    private void Start()
    {
        GetAnimator();
        StartCoroutine("Destroy");
        if(target)
        {
            Spawn();
        }
        GetAnimator();
    }
    public void SetTarget(GameObject trgt)
    {
        target = trgt;
    }
    private void GetAnimator()
    {
        if (gameObject.GetComponent<Animator>())
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }
    public void Spawn()
    {
        if (gameObject.GetComponent<Rigidbody2D>())
        {
            rdbody2D = gameObject.GetComponent<Rigidbody2D>();
        }
        if (target)
        {
            moveDirection = (target.transform.position - transform.position).normalized * speed;
            rdbody2D.velocity = new Vector2(moveDirection.x, moveDirection.y);
            if (moveDirection.x > 0 )
            {
                Debug.Log("Direction is positive");
                direction = 1;
            }
            else if (moveDirection.x < 0)
            {
                Debug.Log("Direction is negative");
                direction = - 1;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Hero"))
        {
            Human humam = collider2D.gameObject.GetComponent<Human>();
            trapsAttack.Attack(damages, humam, this.gameObject.GetComponent<Bomb>());
        }
        else if (collider2D.gameObject.layer == 6)
        {
            StartCoroutine ("GroundCollision");
        }
    }
    IEnumerator GroundCollision()
    {
        yield return new WaitForSeconds(0.25f);
        rdbody2D.velocity = new Vector2(0, 0);
        animator.SetTrigger("Explosion");
        rdbody2D.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2.0f);
        rdbody2D.velocity = new Vector2(0, 0);
        animator.SetTrigger("Explosion");
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}
