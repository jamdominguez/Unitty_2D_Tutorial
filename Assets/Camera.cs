using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject John;
    private const float CAMERA_LIMIT = -0.3f;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        float JohnPositionX = John.transform.position.x;
        //Check if is camera limit
        if (JohnPositionX <= CAMERA_LIMIT) position.x = CAMERA_LIMIT;
        else position.x = JohnPositionX;

        transform.position = position;
    }
}
