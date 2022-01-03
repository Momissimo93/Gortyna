using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBombs : MonoBehaviour
{
    Bomb b;
    public void Fire(Bomb bomb, GameObject t)
    {
        Transform trnsf = t.transform;
        b = bomb;

        Instantiate(b, trnsf.position, Quaternion.identity);
    }
}
