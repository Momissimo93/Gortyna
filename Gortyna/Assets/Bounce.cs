using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float bounce;
    [SerializeField] private Enemy enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Human>())
        {
            Human human = collision.gameObject.GetComponent<Human>();
            if(human.isOnGround == false && human.canMove == true && !enemy.immune && !enemy.isDeath)
            {
                human.rigidBody.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
                enemy.TakeDamage(1, human, enemy);
            }
        }
    }
} 
