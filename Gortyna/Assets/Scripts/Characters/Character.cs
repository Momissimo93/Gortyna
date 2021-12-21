using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float direction;
    [SerializeField] protected int maxLifePoints;
    public int currentLifePoints;

    protected Transform trans;
    public bool immune = false;

    public Rigidbody2D rigidBody;
    public Animator animator;
    public BoxCollider2D boxCollider2D;

    public TakeDamage takeDamage;
    //protected Input moveLeft;

    void Awake()
    {
        SetAnimator();
        SetBoxCollider();
        SetTransform();
        SetRigidBody2D();

        currentLifePoints = maxLifePoints;

        takeDamage = gameObject.GetComponent<TakeDamage>();
    }
    protected void SetAnimator()
    {
        if (GetComponent<Animator>())
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }
    protected void SetBoxCollider()
    {
        if (GetComponent<BoxCollider2D>())
        {
            boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        }
    }
    protected void SetTransform()
    {
        if(GetComponent<Transform>())
        {
            trans = gameObject.GetComponent<Transform>();
        }
    }
    protected void SetRigidBody2D()
    {
        if (GetComponent<Rigidbody2D>())
        {
            rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }
    }

    public void TakeDamage(int damage, Character offender, Character receiver)
    {
        if(takeDamage)
        {
            takeDamage.DoTakeDamage(damage, offender, receiver);
        }
    }
}
