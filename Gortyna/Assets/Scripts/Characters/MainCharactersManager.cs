using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharactersManager : MonoBehaviour
{
    public List<Character> characters;
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
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.x);
    }

    public void SpawnHuman()
    {
        GameObject human;

        for (int i = 0; i < characters.Count; i++)
        {
            if(characters[i].name == "Hero")
            {
                //Debug.Log("Found the Human");
                human = characters[i].gameObject;
                Instantiate(human, transform.position, transform.rotation);
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
                //Debug.Log("Found the Bunny");
                Destroy(transform.gameObject);
                bunny = characters[i].gameObject.GetComponent<Bunny>();
                bunny.SetTransform(transform);
                bunny.SetDirection(direction);
            }
        }
        Instantiate(bunny, transform.position, transform.rotation);
    }

    public void CanBunny(Human human)
    {
        human.canMutate_Bunny = true;
        Debug.Log("canMutate into a Bunny? " + human.canMutate_Bunny);
    }

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
                //Debug.Log("Found the Human");
                human = characters[i].gameObject;
                Instantiate(human, tr.position, transform.rotation);
            }
        }
    }
}
