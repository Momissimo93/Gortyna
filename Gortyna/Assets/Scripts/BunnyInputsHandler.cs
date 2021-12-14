using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyInputsHandler : MonoBehaviour
{
    public Bunny bunny;
    private float horizontalMove = 0;
    float direction;
    Rigidbody2D rb;
    Command moveRigth; 
    // Start is called before the first frame update
    void Start()
    {
        moveRigth = new MoveRight();
    }

    private void Update()
    {
        bunny = FindObjectOfType<Bunny>();
        Move();
    }

    // Update is called once per frame
    private void Move()
    {
        if (bunny)
        {
            Debug.Log("Let's try to move");
            horizontalMove = Input.GetAxisRaw("Horizontal");

            direction = horizontalMove;

            if (horizontalMove < 0 )
            {
                moveRigth.Execute(bunny.transform, -1);
                Debug.Log("Let's move");
                //bunny.transform.position = new Vector2(bunny.transform.position.x + (direction * 10 * Time.deltaTime), bunny.transform.position.y);

                //rb = bunny.transform.gameObject.GetComponent<Rigidbody2D>();
                //rb.velocity = new Vector2(-1 * bunny.speed * Time.deltaTime, rb.velocity.y);
            }
            else if (horizontalMove < 0 )
            {

            }
            else if (horizontalMove == 0)
            {

            }
        }
    }
}
