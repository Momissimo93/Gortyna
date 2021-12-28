using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private TrapsAttack trapsAttack;

    private Vector2 observerLeft;
    private RaycastHit2D observerRayLeft;

    private Vector2 observerRight;
    private RaycastHit2D observerRayRight;

    private BoxCollider2D boxCollider2D;

    public float rayLenght;
    private int hero = 1 << 7;
    bool canMove = false;
    int damages = 1;

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
        observerLeft = new Vector2(boxCollider2D.bounds.min.x, boxCollider2D.bounds.min.y);
        observerRayLeft = Physics2D.Raycast(observerLeft, Vector2.down, rayLenght, hero);

        observerRight = new Vector2(boxCollider2D.bounds.max.x, boxCollider2D.bounds.min.y);
        observerRayRight = Physics2D.Raycast(observerRight, Vector2.down, rayLenght, hero);


        if (observerRayLeft || observerRayRight)
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
        Debug.DrawRay(observerRight, Vector2.down * rayLenght, Color.blue);
        Debug.DrawRay(observerLeft, Vector2.down * rayLenght, Color.blue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            Human humam = collision.gameObject.GetComponent<Human>();
            trapsAttack.Attack(humam, damages);
        }
        if (collision.gameObject.CompareTag("SpikePlatform"))
        {
            canMove = false;
        }
    }
}
