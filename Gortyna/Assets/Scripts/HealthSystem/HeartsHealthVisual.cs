using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsHealthVisual : MonoBehaviour
{
    //public static HeartHealthSystem heartHealthSystemStatic;
    [SerializeField] public Sprite hearthSpriteFull;
    [SerializeField] public Sprite hearthSpriteEmpty;
    //Create a GameObject with an image component 

    //A list to store the HeartImage gameObject 
    private List<HeartImage> hearthImageList;

    //A reference to the HeartHealthSystem
    private HeartHealthSystem heartHealthSystem;

    private void Awake()
    {
        //Initialize a list of HeartImage object 
        hearthImageList = new List<HeartImage>();
    }

    private void Start()
    {
        //The constructor of the heartHealthSystem needs to know the amount of heart the player has
        HeartHealthSystem heartHealthSystem = new HeartHealthSystem(3);

        //The newly created gameObject is passed to the SetHeartHealthSystem
        SetHeartHealthSystem(heartHealthSystem);
    }

    public void SetHeartHealthSystem (HeartHealthSystem heartHealthSystem)
    {
        this.heartHealthSystem = heartHealthSystem;

        //A List heartList is created. This  list of Heart is a reference to the heart List inside the class HearthHealthSystem
        List <Heart> heartList = heartHealthSystem.GetHeartList();

        Vector2 heartAncoredPosition = new Vector2(0, 0);

        int row = 0;
        int col = 0;
        int colMax = 10;
        float rowColSize = 30f;

        //This for loop places the Heart on the Canvas
        for (int i = 0; i < heartList.Count; i ++)
        {

           Heart heart = heartList[i];

            Vector2 heartAnchoredPosition = new Vector2(col * rowColSize, -row * rowColSize);

            /*
             * CreateHeartImage needs a Vector2 game Object, which is used to create a HeartImage gameObject that will be added to the hearthImageList (instanitated on Awake)
             * The method then returns the newly created HeartImage. The function setHearthState of the HeartImage gameObejct is called. This requires to know the status of the Heart (which is 0 or 1)  
            */
            CreateHearthImage(heartAncoredPosition).SetHearthState(heart.GetStatus());

            //The heartAncoredPosition is then updated 
            heartAncoredPosition += new Vector2(50, 0);

            col++;
            if (col > colMax)
            {
                row++;
                col = 0;
            }
        }
    }

    //This function is called from external game Object (like the WarmAttack)
    public void HeartHealthSystemOnDamaged (int damage)
    {
        //First we tell the heartHealthSystem to deal with the damages
        heartHealthSystem.Damage(damage);
        //Second we update the Canvas 
        RefreshAllHearts();
    }
    public void HeartHealthSystemOnHealed(int heal)
    {
        heartHealthSystem.Heal(heal);
        RefreshAllHearts();
    }

    public int CheckLifePoint()
    {
        return heartHealthSystem.GetLifePoints();
    }

    public int CheckInitialLifePoint()
    {
        return heartHealthSystem.GetInitialLifePoints();
    }

    private void RefreshAllHearts()
    {
        //A reference of the Heart list contained in the heartHealthSystem is taken
        List<Heart> heartsList = heartHealthSystem.GetHeartList();
        for (int i = 0; i < hearthImageList.Count; i++)
        {
            HeartImage heartImage = hearthImageList[i];
            Heart heart = heartsList[i];

            //We check what is the right sprite that the heartImage has to display; this according to the status of the Heart at position [i] in the List 
            heartImage.SetHearthState(heart.GetStatus());
        }
    }

    private HeartImage CreateHearthImage(Vector2 anchoredPosition)
    {
        //Create a GameObject 
        GameObject heartGameObject = new GameObject("Hearth", typeof(Image));
        
        //Set the heartGameObject as a child of this transform
        heartGameObject.transform.SetParent(transform);
        heartGameObject.transform.localPosition = Vector3.zero;

        //Locate and Size heart 
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);

        //Set heart sprite
        Image hearthImageUI = heartGameObject.GetComponent<Image>();
       
        //Do not know if this is needed or not 
        //hearthImageUI.sprite = hearthSpriteFull;

        //hearthImage.transform.localScale = new Vector3(0.8f, 0.8f);

        //The constructor of the heartImage needs a reference to the class HeartsHealthVisual and a reference to an Image
        HeartImage heartImage = new HeartImage(this.gameObject.GetComponent<HeartsHealthVisual>(), hearthImageUI);
        hearthImageList.Add(heartImage);

        return heartImage;
    }
}
