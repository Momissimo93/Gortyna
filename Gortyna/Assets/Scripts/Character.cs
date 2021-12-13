using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] protected float direction;

    protected Transform trans;
    protected BoxCollider2D boxCollider2D;
    protected Rigidbody2D rigidBody;
    protected Animator animator;

    //protected Input moveLeft;

    void Start()
    {
        SetAnimator();
        SetBoxCollider();
        SetTransform();
        SetRigidBody2D();
        //InputsHandler NP = new InputsHandler();
        //moveLeft = new MoveLeft();
    }
    protected void SetAnimator()
    {
        if (GetComponent<Animator>())
        {
            animator = gameObject.GetComponent<Animator>();
            Debug.Log("I have got the Animator");
        }
    }
    protected void SetBoxCollider()
    {
        if (GetComponent<BoxCollider2D>())
        {
            boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
            Debug.Log("I have got the BoxCollider");
        }
    }

    protected void SetTransform()
    {
        if(GetComponent<Transform>())
        {
            trans = gameObject.GetComponent<Transform>();
            Debug.Log("I have got the Transform");
        }
        else
        {
            Debug.Log("I have NOT got the Transform");
        }
    }

    protected void SetRigidBody2D()
    {
        if (GetComponent<Rigidbody2D>())
        {
            rigidBody = gameObject.GetComponent<Rigidbody2D>();
            Debug.Log("I have got the RigidBody");
        }
        else
        {
            Debug.Log("I have NOT got the RigidBody");
        }
    }
}
