using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipScript : MonoBehaviour
{
    public Text helpText;
    public Text tooltipText;

    private string helpString = "Bonjour, " + System.Environment.NewLine + "Bienvenue en France!";
    private string tooltipString = "Je suis votre guide.";

    public GameObject boule;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnVREnter()
    {
        helpText.text = helpString;
        tooltipText.text = tooltipString;

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            boule.SendMessage("OnVRTriggerDown");
        }

    }

    void OnVRExit()
    {
        helpText.text = " ";
        tooltipText.text = " ";
    }
}
