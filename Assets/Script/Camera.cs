using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform cam;
    public float cameraX = 0;
    public float cameraY = 0;

    private void Update()
    {
        Vector3 delta = Vector3.zero;

        float deltaX = cam.position.x - transform.position.x;

        if (deltaX > cameraX || deltaX < -cameraX)
        {
            if(transform.position.x < cam.position.x) 
            {
                delta.x = deltaX - cameraX;
            }
            else
            {
                delta.x = deltaX + cameraX;
            }
        }

        float deltaY = cam.position.y - transform.position.y;

        if (deltaY > cameraY || deltaY < -cameraY)
        {
            if (transform.position.x < cam.position.x)
            {
                delta.y = deltaY - cameraY;
            }
            else
            {
                delta.y = deltaY + cameraY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
