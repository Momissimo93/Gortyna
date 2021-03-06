using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDoor : MonoBehaviour
{
    [HideInInspector] public bool open;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        animator = gameObject.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

   public void OpenDoor()
    {
        animator.SetTrigger("door_Open");
    }
    public void CloseDoor()
    {
        animator.SetTrigger("door_Close");
    }
}
