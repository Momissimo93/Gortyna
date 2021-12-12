using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public Rigidbody2D rb;
    public Character character;
    //public float direction;

    //The extention classes are expected to execute this method
    public abstract void Execute(Transform trans, float direction);
    // Start is called before the first frame update

    //The extention classes are expected to supply the logic for this methods
    public virtual void Move(Transform trans, float direction) { }
}
