using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject mainChar;
    Camera cam;
    //public GameObject backGround;

    float verExtent;
    float horExtent;

    float leftB;
    float rightB;
    float topB;
    float bottomB;

    [SerializeField] float interpolationSpeed = 5f;
    [SerializeField] Vector2 offset;
    private enum TypeOfCharacter {Human, Bunny};
    private TypeOfCharacter typeOfChar;

    private Human human;
    private Bunny bunny;

    Bounds sceneBounds;

    void Start()
    {
        //We do that has we know that the first Character to be spawn is the human
        SetCameraHuman();

        cam =  GetComponent<Camera>();

        Collider2D[] sceneColliders2D = FindObjectsOfType<Collider2D>(); 

        foreach(Collider2D coll in sceneColliders2D)
        {
            sceneBounds.Encapsulate(coll.bounds);
        }

        GetExtents();
        GetBounds();
    }
    // Update is called once per frame
    void Update()
    {
        if((human) || (bunny))
        {
            switch (typeOfChar)
            {
                case TypeOfCharacter.Human:
                    transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(human.trans.position.x, leftB, rightB) + offset.x, Mathf.Clamp(human.trans.position.y, bottomB, topB) + offset.y, transform.position.z), Time.deltaTime * interpolationSpeed);
                    break;

                case TypeOfCharacter.Bunny:
                    transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(bunny.trans.position.x, leftB, rightB) + offset.x, Mathf.Clamp(bunny.trans.position.y, bottomB, topB) + offset.y, transform.position.z), Time.deltaTime * interpolationSpeed);
                    break;
            }
        }
    }

    void GetExtents()
    {
        if (GetComponent<Camera>())
        {
            verExtent = GetComponent<Camera>().orthographicSize;
            horExtent = verExtent * GetComponent<Camera>().aspect;
        }
    }

    void GetBounds()
    {
        if (GetComponent<Camera>())
        {

            leftB = sceneBounds.min.x + horExtent - offset.x;
            rightB = sceneBounds.max.x - horExtent - offset.x;

            bottomB = sceneBounds.min.y + verExtent - offset.y;
            topB = sceneBounds.max.y - verExtent - offset.y;
        }
    }

    public void SetCameraBunny()
    {
        typeOfChar = TypeOfCharacter.Bunny;
        bunny = GameObject.FindObjectOfType<Bunny>();
    }
    public void SetCameraHuman()
    {
        typeOfChar = TypeOfCharacter.Human;
        human = GameObject.FindObjectOfType<Human>();
    }
}
