using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public GameObject go;
    public GameObject man;
    public GameObject boule;

    private GameObject dummy;

    // Start is called before the first frame update
    void Start()
    {
        go = new GameObject();
        dummy = new GameObject();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider != null)
            {
                go = hit.collider.gameObject;
                if (go == man)
                {
                    man.SendMessage("OnVREnter");
                    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                    {
                        // man.SendMessage("OnVREnter");
                        boule.SendMessage("OnVRTriggerDown");
                    }

                } else
                {
                    man.SendMessage("OnVRExit");
                }
   
            }
        }
        else
        {
            man.SendMessage("OnVRExit");
            go = dummy;
        }



    }

}
