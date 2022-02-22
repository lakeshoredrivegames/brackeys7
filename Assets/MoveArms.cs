using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArms : MonoBehaviour
{
    public Transform aimCam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Vector3.Lerp(transform.forward, aimCam.forward, Time.deltaTime * 20f);
    }
}
