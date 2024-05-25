using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Camera cam;
    public float smoothing;
    public Vector2 minPos;
    public Vector2 maxPos;
    public float camSize = 5;

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

        if(transform.position != target.position)
        {
            Vector3 targetPosition = new(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPos.x, maxPos.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);

            cam.orthographicSize = camSize;
        }
    }
}
