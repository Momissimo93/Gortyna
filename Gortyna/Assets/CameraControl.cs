using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject mainChar;
    SpriteRenderer spriteRend;
    Camera camera;
    public GameObject backGround;

    float verExtent;
    float horExtent;

    float spriteWidth;
    float spriteHeight;

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

    void Start()
    {
        //We do that has we know that the first Character to be spawn is the human
        human = GameObject.FindObjectOfType<Human>();
        typeOfChar = TypeOfCharacter.Human;

        if (backGround.GetComponent<SpriteRenderer>())
        {
            spriteRend = backGround.GetComponent<SpriteRenderer>();
            //spriteSizeMax = sprite.bounds.size.x/2  ;
            //Debug.Log("spriteSizeMax = " + spriteSizeMax);
        }
        else
        {
            Debug.Log("The object does not have a SpriteRendere");
        }

        if (GetComponent<Camera>())
        {

            camera = GetComponent<Camera>();

            verExtent = camera.orthographicSize;
            horExtent = verExtent * camera.aspect;


            spriteWidth = spriteRend.bounds.size.x / 2f;
            spriteHeight = spriteRend.bounds.size.y / 2f;

            leftB = spriteRend.bounds.min.x + horExtent - offset.x;
            rightB = spriteRend.bounds.max.x - horExtent - offset.x;

            bottomB = spriteRend.bounds.min.y + verExtent - offset.y;
            topB = spriteRend.bounds.max.y - verExtent - offset.y;

        }
    
    }
    // Update is called once per frame
    void Update()
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
        //transform.position = new Vector2 (mainChar.transform.position.x , mainChar.transform.position.y);

        //transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(human.trans.position.x, leftB, rightB) + offset.x, Mathf.Clamp(human.trans.position.y, bottomB, topB) + offset.y, transform.position.z), Time.deltaTime * interpolationSpeed);
    }

    /*
    public void SetMainCharacter(GameObject character)
    {
        if (character.gameObject.CompareTag("Hero"))
        {
            typeOfChar = TypeOfCharacter.Human;
            human = character.gameObject.GetComponent<Human>();

        }
        else if (character.gameObject.CompareTag("Hero"))
        {
            typeOfChar = TypeOfCharacter.Bunny;
            human = character.gameObject.GetComponent<Human>();
        }
        else
        {
            Debug.Log("Error");
        }
    }*/

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
