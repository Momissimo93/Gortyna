using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public Rigidbody2D rb;

    public Character character;
    public abstract void Execute(Transform trans, float direction);
    public virtual void Move(Transform trans, float direction) { }
    public virtual void JumpCommand(Transform trans) { }

    public virtual void FlyingCommand(Transform trans) { }
}
