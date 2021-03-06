using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Trap
{
    [SerializeField] private float speed;
    [SerializeField] private float force = 0.9f;
    Rigidbody2D rdbody2D;
    Vector2 moveDirection;
    public GameObject target;

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
                direction = 1;
            }
            else if (moveDirection.x < 0)
            {
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
            StartCoroutine("HeroCollision");
        }
        else if (collider2D.gameObject.layer == 6)
        {
            StartCoroutine ("GroundCollision");
        }
    }
    IEnumerator GroundCollision()
    {
        yield return new WaitForSeconds(0.2f);
        rdbody2D.velocity = new Vector2(0, 0);
        animator.SetTrigger("Explosion");
        rdbody2D.velocity = new Vector2(0, 0);
        boxCollider2D.enabled = false;
        yield return new WaitForSeconds(0.8f);
        Destroy(this.gameObject);
    }
    IEnumerator HeroCollision()
    {
        yield return new WaitForSeconds(0.1f);
        rdbody2D.velocity = new Vector2(0, 0);
        animator.SetTrigger("Explosion");
        rdbody2D.velocity = new Vector2(0, 0);
        boxCollider2D.enabled = false;
        yield return new WaitForSeconds(0.8f);
        Destroy(this.gameObject);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2.0f);
        rdbody2D.velocity = new Vector2(0, 0);
        animator.SetTrigger("Explosion");
        boxCollider2D.enabled = false;
        yield return new WaitForSeconds(0.8f);
        Destroy(this.gameObject);
    }
}
