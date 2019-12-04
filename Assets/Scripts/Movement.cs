using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public GameObject centerEye;
    public GameObject pObject;
    public Vector2 joystick;
    public float speed;
    //public float hoverHeight = 1.0f;

    //private float terrainHeight;
    //private Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        transform.eulerAngles = new Vector3(0, centerEye.transform.localEulerAngles.y, 0);
        transform.Translate(Vector3.forward * speed * joystick.y * Time.deltaTime);
        transform.Translate(Vector3.right * speed * joystick.x * Time.deltaTime);

        //pos = transform.position;
        //terrainHeight = Terrain.activeTerrain.SampleHeight(pos);
        //transform.position = new Vector3(pos.x,
        //                                 terrainHeight,
        //                                 pos.z);

        pObject.transform.position = Vector3.Lerp(pObject.transform.position, transform.position, 10f * Time.deltaTime);
        // pObject.transform.position = Vector3.Lerp(pObject.transform.position, transform.position, 10f * Time.deltaTime);
    }
}

