using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Vector2 observer;
    private BoxCollider2D boxCollider2D;
    private RaycastHit2D observerRay;
    public float rayLenght;
    private int hero = 1 << 7;
    bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.GetComponent<BoxCollider2D>())
        {
            boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == false)
        {
            canMove = EmittingRay();
        }
        else
        {
            Move();
        }
        DrawRaysFromFeet();
    }

    public bool EmittingRay()
    {
        observer = new Vector2(boxCollider2D.bounds.min.x, boxCollider2D.bounds.min.y);
        observerRay = Physics2D.Raycast(observer, Vector2.down, rayLenght, hero);

        if(observerRay)
        {
            return true;
        }

        return false;
    }

    public void Move()
    {
        if (canMove)
        {
            boxCollider2D.transform.position = new Vector2(boxCollider2D.transform.position.x, boxCollider2D.transform.position.y + (-1 * 4 * Time.deltaTime));
        }
    }

    public void DrawRaysFromFeet()
    {
        Debug.DrawRay(observer, Vector2.down * rayLenght, Color.blue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpikePlatform"))
        {
            canMove = false;
        }
    }
}
