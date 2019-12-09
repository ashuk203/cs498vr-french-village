using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManConvoOpt2 : MonoBehaviour
{
    public Material inactive;
    public Material hover;
    public Material clicked;
    public GameObject dialogueObj;


    void OnVREnter()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            GetComponent<Renderer>().material = clicked;
            dialogueObj.SendMessage("HandleResponse", 2);
        }
        else
        {
            GetComponent<Renderer>().material = hover;
        }
    }

    void OnVRExit()
    {
        GetComponent<Renderer>().material = inactive;
    }
}
