using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public float riseHeight;
    private bool summoned = false;
    private Vector3 summonedPos, hiddenPos;
    // Start is called before the first frame update
    void Start()
    {
        hiddenPos = transform.position;
        summonedPos = hiddenPos + (new Vector3(0, riseHeight, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (!summoned)
        {
            transform.position = Vector3.Lerp(transform.position, hiddenPos, Time.deltaTime * 5f);
        }
        else if (summoned)
        {
            transform.position = Vector3.Lerp(transform.position, summonedPos, Time.deltaTime * 5f);
        }
    }

    void OnVRTriggerDown()
    {
        summoned = !summoned;
    }
}
