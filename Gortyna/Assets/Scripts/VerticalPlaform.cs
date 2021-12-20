using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlaform : MonoBehaviour
{
    public bool canMove = false;
    private Vector2 originalPosition;
    private Transform transform;
    private VerticalMovement verticalMovement;
    private float distance = 7.80f;
    private int initialDirection = -1;

    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
        originalPosition = transform.position;
        verticalMovement = gameObject.AddComponent<VerticalMovement>();
        verticalMovement.SetParameters(transform, originalPosition, distance, initialDirection);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            verticalMovement.Move(transform);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Human>())
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Human>())
        {
            collision.transform.SetParent(null);
            //collision.gameObject.GetComponent<Human>().isNotOnPlatform = true;
        }
    }
}
