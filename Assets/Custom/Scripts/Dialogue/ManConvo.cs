using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManConvo : MonoBehaviour
{

    public GameObject man;

    public TextMesh[] choices;
    public string[] choice1;
    public string[] choice2;
    public string[] choice3;
    public int[] correctChoice;


    private int currentQuestion = 0;
    private int numQuestions;

   


    // Start is called before the first frame update
    void Start()
    {
        numQuestions = choice1.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentQuestion >= numQuestions)
        {
            this.gameObject.SetActive(false);
        } else 
        {
            choices[0].text = choice1[currentQuestion];
            choices[1].text = choice2[currentQuestion];
            choices[2].text = choice3[currentQuestion];
        }
    }

    void HandleResponse (int choiceSelected)
    {
        if (currentQuestion < numQuestions)
        {
            if (choiceSelected == correctChoice[currentQuestion])
            {
                currentQuestion++;
                man.SendMessage("PickedRightAnswer");

                if (currentQuestion == numQuestions)
                {
                    man.SendMessage("FinishedConvo");
                }
            }
            else
            {
                man.SendMessage("PickedWrongAnswer");
            }
        }
    }

}
