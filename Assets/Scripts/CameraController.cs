using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject bgTransform;
    public Transform playerTransform;
    public float offset, offsetBG;
    public float minusX = -122.5f;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void LateUpdate()
    {
        if(playerTransform.position.x > minusX)
        {
            Vector3 temp = transform.position;
            temp.x = playerTransform.position.x;
            temp.x += offset;
            transform.position = temp;
            Vector3 tempBG = transform.position;
            tempBG.x = playerTransform.position.x;
            tempBG.z = 0;
            tempBG.z += offsetBG;
            tempBG.x += offsetBG;
            bgTransform.transform.position = tempBG;
        }
    }
}
