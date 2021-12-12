using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsHandler: MonoBehaviour
{
    Command moveLeft;

    // Start is called before the first frame update
    void Start()
    {
        moveLeft = new MoveLeft();
        if(moveLeft == null)
        {
            Debug.Log("Is null here as well");
        }
        else
        {
            Debug.Log("Here we have it");
        }
        //playerTransform = FindObjectOfType<Character>().transform;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Moveleft(Transform transform, float direction)
    {
        moveLeft.Execute(transform, direction);
    }
}
