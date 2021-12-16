using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    Human human;

    public IEnumerator Dashing(Human hum)
    {
        if(hum.GetComponent<Human>())
        {
            human = hum.GetComponent<Human>();
            float d = human.dashPower * human.direction;
            human.rigidBody.velocity = new Vector2(d, human.rigidBody.velocity.y);
            human.isDashing = true;
            yield return new WaitForSeconds(human.dashTime);
            human.isDashing = false;
        }
        else
        {
            Debug.Log("No Object of type Human detected");
        }
    }
}
