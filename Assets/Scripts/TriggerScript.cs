using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private bool summoned = false;
    public Vector3 summonedPos, hiddenPos;
    // Start is called before the first frame update
    void Start()
    {
        hiddenPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!summoned)
        {
            transform.position = Vector3.Lerp(transform.position, hiddenPos, Time.deltaTime * 5f);
        }

        if (summoned)
        {
            transform.position = Vector3.Lerp(transform.position, summonedPos, Time.deltaTime * 5f);
        }

    }

    void OnVRTriggerDown()
    {
        summoned = !summoned;
    }
}
