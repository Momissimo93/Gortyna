using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameObject mainChar;
    [SerializeField] float interpolationSpeed = 5f;
    [SerializeField] Vector2 offset;

    private Camera cam;
    private float verExtent;
    private float horExtent;
    private float leftB;
    private float rightB;
    private float topB;
    private float bottomB;
    private enum TypeOfCharacter {Human, Bunny, Bird};
    private TypeOfCharacter typeOfChar;
    private Human human;
    private Bunny bunny;
    private Bird bird;
    private Bounds sceneBounds;

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
        if((human) || (bunny) || (bird))
        {
            switch (typeOfChar)
            {
                case TypeOfCharacter.Human:
                    transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(human.trans.position.x, leftB, rightB) + offset.x, Mathf.Clamp(human.trans.position.y, bottomB, topB) + offset.y, transform.position.z), Time.deltaTime * interpolationSpeed);
                    break;

                case TypeOfCharacter.Bunny:
                    transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(bunny.trans.position.x, leftB, rightB) + offset.x, Mathf.Clamp(bunny.trans.position.y, bottomB, topB) + offset.y, transform.position.z), Time.deltaTime * interpolationSpeed);
                    break;

                case TypeOfCharacter.Bird:
                    transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(bird.trans.position.x, leftB, rightB) + offset.x, Mathf.Clamp(bird.trans.position.y, bottomB, topB) + offset.y, transform.position.z), Time.deltaTime * interpolationSpeed);
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
    public void SetCameraBird()
    {
        typeOfChar = TypeOfCharacter.Bird;
        bird = GameObject.FindObjectOfType<Bird>();
    }

    public void SetCameraHuman()
    {
        typeOfChar = TypeOfCharacter.Human;
        human = GameObject.FindObjectOfType<Human>();
    }
}
