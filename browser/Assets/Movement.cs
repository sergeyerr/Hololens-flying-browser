using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    Transform CameraTrans;
    Vector3 offset;
    float idealLen;
    bool move = false;
    float speed = 10;
	// Use this for initialization
	void Start () {
        var camera = Camera.main;
        CameraTrans = camera.transform;
        offset = transform.position - CameraTrans.position;
        idealLen = offset.magnitude;
    }
	
	// Update is called once per frame
	void Update () {
        var browserToCamera = transform.position - CameraTrans.position;
        var bRotation = Quaternion.LookRotation(browserToCamera);
        var angleCamToB = Quaternion.Angle(CameraTrans.rotation, bRotation);
        transform.position = CameraTrans.position + offset;
        if (move)
        {
            Quaternion fullRotation = CameraTrans.rotation * Quaternion.Inverse(bRotation);
            float scalingFactor = (speed + angleCamToB * angleCamToB / 100)  / angleCamToB * Time.smoothDeltaTime;
            Quaternion scaledRotation = Quaternion.Slerp(Quaternion.identity, fullRotation, scalingFactor);
            Vector3 newbrowserToCamera = scaledRotation * browserToCamera;
            transform.position = CameraTrans.position + newbrowserToCamera.normalized*idealLen;
            offset = newbrowserToCamera;
            transform.rotation = Quaternion.LookRotation(-newbrowserToCamera) * Quaternion.Euler(90, 0, 0) * Quaternion.Euler(0, -180, 0);
            angleCamToB = Quaternion.Angle(CameraTrans.rotation, bRotation);
            if (angleCamToB < 7)
            {
                move = false;

            }
        }
        if (angleCamToB > 25) move = true;
    }
}
