using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] public float direction;
    [HideInInspector] public Transform trans;
    [HideInInspector] public Rigidbody2D rigidBody;
    [HideInInspector] public Animator animator;
    [HideInInspector] public BoxCollider2D boxCollider2D;
    [HideInInspector] public TakeDamage takeDamage;
    [HideInInspector] public TrapsAttack trapsAttack;

    public int damages;

    void Awake()
    {
        SetAnimator();
        SetBoxCollider();
        SetTransform();
        SetRigidBody2D();

        takeDamage = gameObject.GetComponent<TakeDamage>();
        trapsAttack = gameObject.GetComponent<TrapsAttack>();
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
        if (GetComponent<Transform>())
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
        if (takeDamage)
        {
            takeDamage.DoTakeDamage(damage, offender, receiver);
        }
    }
    public float GetTransfromPositionX()
    {
        if (this.trans != null)
        {
            return trans.position.x;
        }
        return 0f;
    }

    public float GetTranformPositionY()
    {
        if (this.trans != null)
        {
            return trans.position.y;
        }
        return 0f;
    }
}
