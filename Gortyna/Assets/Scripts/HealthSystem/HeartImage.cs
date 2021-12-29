using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartImage
{
    private Image heartImage;
    private HeartsHealthVisual heartsHealthVisual;

    public HeartImage(HeartsHealthVisual hhV, Image heartImage)
    {
        this.heartImage = heartImage;
        this.heartsHealthVisual = hhV;
    }

    //Depending on the receive int variable (state) one between the sprite game object: hearthSpriteEmpty or hearthSpriteFull (Sprite game objects from the class HeartsHealthVisual) is saved into the sprite variable of the heartImage component of type Image

    public void SetHearthState(int state)
    {
        switch (state)
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
