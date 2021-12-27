using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharactersManager : MonoBehaviour
{
    public List<Character> characters;
    public CameraControl cameraControl;
    Vector3 position;
    Bunny bunny;
    float direction;

    void Awake()
    {
        SpawnHuman();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.x);
    }

    //Mehotd Called only the game start 
    public void SpawnHuman()
    {
        GameObject human;

        for (int i = 0; i < characters.Count; i++)
        {
            if(characters[i].name == "Hero")
            {
                human = characters[i].gameObject;
                Instantiate(human, transform.position, transform.rotation);
 
                if(human.gameObject.GetComponent<Transform>() != null)
                {
                    //cameraControl.SetMainCharacter(human);
                    Debug.Log("Let's set the Camera");
                }
            }
        }
    }

    public void SpawnBunny(Transform tr)
    {
        Transform transform = tr;
        float direction = 0;

        if (transform.gameObject.GetComponent<Human>())
        {
            direction = transform.gameObject.GetComponent<Human>().direction;
        }

        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].name == "Bunny")
            {
                Destroy(transform.gameObject);
                bunny = characters[i].gameObject.GetComponent<Bunny>();
                bunny.SetTransform(transform);
                bunny.SetDirection(direction);
            }
        }
        Instantiate(bunny, transform.position, transform.rotation);
        cameraControl.SetCameraBunny();
    }

    public void CanBunny(Human human)
    {
        human.canMutate_Bunny = true;
    }

    //Mehtod used when we mutate back into Human
    public void HumanMutation(Bunny bunny)
    {
        Bunny b = bunny;
        Transform tr = bunny.transform;
        Destroy(b.gameObject);

        GameObject human;

        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].name == "Hero")
            {
                human = characters[i].gameObject;
                Instantiate(human, tr.position, transform.rotation);
                cameraControl.SetCameraHuman();
            }
        }
    }
}
