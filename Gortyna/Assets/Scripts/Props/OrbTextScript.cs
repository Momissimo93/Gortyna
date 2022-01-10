using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbTextScript : MonoBehaviour
{
    private Text text;
    public static int OrbAmount;
    void Start()
    {
        text = GetComponent<Text>();
    }
    //Update is called once per frame
    void Update()
    {
        text.text = OrbAmount.ToString();
    }
}