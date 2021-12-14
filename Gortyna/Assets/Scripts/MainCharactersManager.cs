using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharactersManager : MonoBehaviour
{
    public List<Character> characters;
    Vector3 position;
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
        GameObject hero;

        for (int i = 0; i < characters.Count; i++)
        {
            if(characters[i].name == "Hero")
            {
                Debug.Log("Found the Human");
                hero = characters[i].gameObject;
                Instantiate(hero, transform.position, transform.rotation);
            }
        }
    }

    public void SpawnBunny(Transform tr)
    {
        GameObject bunny;

        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].name == "Bunny")
            {
                Debug.Log("Found the Bunny");
                Destroy(tr.gameObject);
                bunny = characters[i].gameObject;
                Instantiate(bunny, tr.position, tr.rotation);
            }
            else
            {
                Debug.Log("I could not find the bunny");
            }
        }
    }

    public void CanBunny()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].gameObject.GetComponent<HumanForm>())
            {
                HumanForm human = characters[i].gameObject.GetComponent<HumanForm>();
                human.canMutate_Bunny = true;
                Debug.Log("canMutate into a Bunny? " + human.canMutate_Bunny);
            }
            else
            {
                Debug.Log("I could not find the bunny");
            }
        }
    }
}
