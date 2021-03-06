using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharactersManager : MonoBehaviour
{
    [SerializeField] private List<Character> characters;
    [SerializeField] private CameraControl cameraControl;

    private HeartsHealthVisual heartHealthVisual;
    private Bunny bunny;
    private Bird bird;
    private Human human;

    void Awake()
    {
        heartHealthVisual = GameObject.FindObjectOfType<HeartsHealthVisual>();
        SpawnHuman();
    }

    //Mehotd Called only the game start 
    public void SpawnHuman()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if(characters[i].name == "Hero")
            {
                human = characters[i].gameObject.GetComponent<Human>();
                Instantiate(human, transform.position, transform.rotation);
                //There is something wrong, before it was bird...Check it later
                heartHealthVisual.SetCurrentCharacter(human);
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
        heartHealthVisual.SetCurrentCharacter(bird);
    }

    public void SpawnBird(Transform tr)
    {
        Transform transform = tr;
        float direction = 0;

        if (transform.gameObject.GetComponent<Human>())
        {
            direction = transform.gameObject.GetComponent<Human>().direction;
            //lifePoints = transform.gameObject.GetComponent<Human>().currentLifePoints;
        }

        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].name == "Bird")
            {
                Destroy(transform.gameObject);
                bird = characters[i].gameObject.GetComponent<Bird>();
                bird.SetTransform(transform);
                bird.SetDirection(direction * -1);
            }
        }
        Instantiate(bird, transform.position, transform.rotation);
        cameraControl.SetCameraBird();
        heartHealthVisual.SetCurrentCharacter(bird);
    }

    //Mehtod used when we mutate back into Human
    public void HumanMutationFromBunny(Bunny bunny)
    {
        Character b = bunny;
        Transform tr = bunny.transform;
        Destroy(b.gameObject);

        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].name == "Hero")
            {
                human = characters[i].gameObject.GetComponent<Human>();
                Instantiate(human, tr.position, transform.rotation);
                cameraControl.SetCameraHuman();
                heartHealthVisual.SetCurrentCharacter(human);
            }
        }
    }
    public void HumanMutationFromBird(Bird bird)
    {
        Bird b = bird;
        Transform tr = bird.transform;
        Destroy(b.gameObject);

        for (int i = 0; i < characters.Count; i++)
        {
            //Funziona ma non so perch? (domani bisogna indagare)
            if (characters[i].name == "Hero" && heartHealthVisual.CheckLifePoint() > 0)
            {
                human = characters[i].gameObject.GetComponent<Human>();
                Instantiate(human, tr.position, transform.rotation);
                cameraControl.SetCameraHuman();
                heartHealthVisual.SetCurrentCharacter(human);
            }
        }
    }
    public void CanBunny(Human human)
    {
        human.canMutate_Bunny = true;
    }
    public void CanNotBunny(Human human)
    {
        human.canMutate_Bunny = false;
    }
    public void CanBird(Human human)
    {
        human.canMutate_Bird = true;
    }
    public void CanNotBird(Human human)
    {
        human.canMutate_Bird = false;
    }
}
