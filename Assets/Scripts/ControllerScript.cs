using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{

    private float distanceTreshold = 100;
    private GameObject go;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        RaycastHit hit;
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider != null)
            {
                if (go != null && go != hit.collider.gameObject)
                {
                    go.SendMessage("OnVRExit");
                }

                go = hit.collider.gameObject;

                if (hit.distance < distanceTreshold)
                {
                    go.SendMessage("OnVREnter");
                }
            }
        }
        else
        {
            if (go != null)
            {
                go.SendMessage("OnVRExit");
            }
            go = null;
        }
    }

}
