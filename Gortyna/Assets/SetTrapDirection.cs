using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrapDirection : MonoBehaviour
{
    [SerializeField] TrapSuspended trapSuspended;

    public void SetDirectionPositive()
    {
        if(trapSuspended)
        {
            trapSuspended.direction = 1;
        }
    }

    public void SetDirectionNegative()
    {
        if (trapSuspended)
        {
            trapSuspended.direction = -1;
        }
    }
}
