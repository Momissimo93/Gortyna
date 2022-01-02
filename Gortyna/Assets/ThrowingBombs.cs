using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingBombs : MonoBehaviour
{
    Bomb b;
    public void Fire(Bomb bomb)
    {
        b = bomb;
        Instantiate(b, transform.position, Quaternion.identity);
    }
}
