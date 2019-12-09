using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipScript : MonoBehaviour
{
    public Text helpText;
    public Text tooltipText;

    public GameObject boule;
    public GameObject dialogueObj;
    public GameObject player;

    private string helpString = "Bonjour, Bienvenue en France!";
    private readonly string tooltipString = "Appuyez sur l'amorce pour converser";

	private string inConvoString = "Parlez avec monsieur...";
	private string wrongAnswerString = "Je ne comprends pas.";

	private bool initiatedConvo;
    private bool finishedConvo;
	private bool wrongAnswer;
	private bool entered;
    private bool clearOnce = true;

    private float activeDistThresh = 150;
    void Update()
	{
        if ((this.transform.position - player.transform.position).magnitude < activeDistThresh)
        {
            clearOnce = true;
            if (initiatedConvo)
		    {
                if (!finishedConvo)
                {
                    dialogueObj.SetActive(true);
                }
			    if (!wrongAnswer)
			    {
                    if (finishedConvo)
                    {
                        if (entered)
                        {
                            helpText.text = "Merci encore pour l'aide";
                        } else
                        {
                            helpText.text = "";
                        }                        
                    } else
                    {
                        helpText.text = inConvoString;
                    }
			    }
			    else
			    {
				    helpText.text = wrongAnswerString;
			    }
			    tooltipText.text = "";
		    }
		    else
		    {
                if (entered)
			    {
				    helpText.text = helpString;
				    tooltipText.text = tooltipString;
			    } else
			    {
				    helpText.text = "";
				    tooltipText.text = "";
			    }
		    }
        } else
        {
            dialogueObj.SetActive(false);
            if (clearOnce)
            {
                helpText.text = "";
                tooltipText.text = "";
                clearOnce = false;
            }
        }
	}
	
    void OnVREnter()
    {
		entered = true;
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (!finishedConvo)
            {
                dialogueObj.SetActive(true);
            }
            initiatedConvo = true;
        }

    }

    void OnVRExit()
    {
		entered = false;
	}

    void PickedWrongAnswer()
	{
		wrongAnswer = true;
	}

    void PickedRightAnswer()
    {
        wrongAnswer = false;
    }

    void FinishedConvo()
    {
        finishedConvo = true;
    }
}
