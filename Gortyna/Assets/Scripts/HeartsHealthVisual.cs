using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsHealthVisual : MonoBehaviour
{
    //public static HeartHealthSystem heartHealthSystemStatic;
    [SerializeField] private Sprite hearthSpriteFull;
    [SerializeField] private Sprite hearthSpriteEmpty;
    //Create a GameObject with an image component 

    private List<HeartImage> hearthImageList;
    private HeartHealthSystem heartHealthSystem;

    private void Awake()
    {
        hearthImageList = new List<HeartImage>();
    }

    private void Start()
    {
        HeartHealthSystem heartHealthSystem = new HeartHealthSystem(3);
        SetHeartHealthSystem(heartHealthSystem);

        //heartHealthSystem.Damage(3);
        //heartHealthSystem.Heal(0);
        //heartHealthSystem.Damage(1);
        //CreateHearthImage(new Vector2(60, 0));
        //RefreshAllHearts();
    }

    public void SetHeartHealthSystem (HeartHealthSystem heartHealthSystem)
    {
        this.heartHealthSystem = heartHealthSystem;
        //heartHealthSystemStatic = heartHealthSystem;

        List<HeartHealthSystem.Heart> heartList = heartHealthSystem.GetHeartList();
        Vector2 heartAncoredPosition = new Vector2(0, 0);

        int row = 0;
        int col = 0;
        int colMax = 10;
        float rowColSize = 30f;


        for (int i = 0; i < heartList.Count; i ++)
        {
            HeartHealthSystem.Heart heart = heartList[i];

            Vector2 heartAnchoredPosition = new Vector2(col * rowColSize, -row * rowColSize);
            CreateHearthImage(heartAncoredPosition).setHearthState(heart.GetStatus());
            heartAncoredPosition += new Vector2(80, 0);

            col++;
            if (col > colMax)
            {
                row++;
                col = 0;
            }
        }

        //heartHealthSystem.onDamage += heartHealthSystem_OnDamaged;
        //heartHealthSystem.onHealed += heartHealthSystem_OnHealed;
    }

    public void heartHealthSystemOnDamaged (int damage)
    {
        heartHealthSystem.Damage(damage);
        RefreshAllHearts();
        Debug.Log("Damage");
    }
    public void heartHealthSystemOnHealed(object sender, System.EventArgs e)
    {
        //RefreshAllHearts();
    }

    private void RefreshAllHearts()
    {
        List<HeartHealthSystem.Heart> heartsList = heartHealthSystem.GetHeartList();
        for (int i = 0; i < hearthImageList.Count; i++)
        {
            HeartImage heartImage = hearthImageList[i];
            HeartHealthSystem.Heart heart = heartsList[i];
            heartImage.setHearthState(heart.GetStatus());
        }
    }

    private HeartImage CreateHearthImage(Vector2 anchoredPosition)
    {
        //Create a GameObject 
        GameObject heartGameObject = new GameObject("Hearth", typeof(Image));
        
        //Set as child of this transform
        heartGameObject.transform.SetParent(transform);
        heartGameObject.transform.localPosition = Vector3.zero;

        //Locate and Size heart 
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(25, 25);


        //Set heart sprite
        Image hearthImageUI = heartGameObject.GetComponent<Image>();
        hearthImageUI.sprite = hearthSpriteFull;

        //hearthImage.transform.localScale = new Vector3(0.8f, 0.8f);

        HeartImage heartImage = new HeartImage(this.gameObject.GetComponent<HeartsHealthVisual>(), hearthImageUI);
        hearthImageList.Add(heartImage);

        return heartImage;
    }

    //A single heart
    public class HeartImage
    {
        private Image heartImage;
        private HeartsHealthVisual heartsHealthVisual;
        public HeartImage(HeartsHealthVisual hhV, Image heartImage)
        {
            this.heartImage = heartImage;
            this.heartsHealthVisual = hhV;
        }

        public void setHearthState (int state)
        {
            switch(state)
            {
                case 0:
                    heartImage.sprite = heartsHealthVisual.hearthSpriteEmpty;
                    break;
                case 1:
                    heartImage.sprite = heartsHealthVisual.hearthSpriteFull;
                    break;
            }
        }
    }

}
