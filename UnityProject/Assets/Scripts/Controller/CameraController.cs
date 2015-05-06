using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    
    public AutoMovePlayer amp;
    public float smoothing = 5f;        // The speed with which the camera will be following.
    public float speed;
    public Vector3 direction;
    public String targetTag = "Player";

    private Vector3 _offset;
    private GameObject target;            // The position that that camera will be following.
    // Use this for initialization
    void Start()
    {
        _offset = transform.position;
        target = GameObject.FindGameObjectWithTag(targetTag);
    }

    void FixedUpdate()
    {
        if (target == null)
            return;
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = (target != null && transform.position.z < target.transform.position.z ? target.transform.position + _offset : transform.position) + (direction*speed*Time.deltaTime) + (amp ? amp.SpeedModifier() : new Vector3());

        targetCamPos.y = _offset.y;
        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        if (target.transform.position.z < (transform.position.z - GetComponent<Camera>().orthographicSize*2.2))
        {
            Life life = target.GetComponent<Life>();
            if ( life != null)
            {
                life.death();
            }
        }
    }

    public void ResetCamera()
    {
        Vector3 targetCamPos = target.transform.position + _offset;
        targetCamPos.y = _offset.y;
        transform.position = targetCamPos;
    }
}
