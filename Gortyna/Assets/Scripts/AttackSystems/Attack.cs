using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    protected int offenderLayer;
    protected Character offender;
    protected Character receiver;


    public void SetOffenderLayer(int offndLayer)
    {
        offenderLayer = offndLayer;
    }

    public void SetReceiver(Character rc)
    {
        receiver = rc;
    }

    public void SetOffender(Character of)
    {
        offender = of;
    }
}
