using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtr : MonoBehaviour
{

    public Camera camera;
    public GameObject player;
    public float speed = 0.5f;
    float cameraSize = 6f;
    public float MaXsize = 6f;
    public float MinSize = 4f;

    void Update()
    {
        if (player != null)
        {
            cameraSize = 6f + player.transform.position.y;
            if (cameraSize >= MaXsize)
            {
                cameraSize = MaXsize;
            }

            if (cameraSize <= MinSize)
            {
                cameraSize = MinSize;
            }

            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, cameraSize, Time.deltaTime / speed);
        }
    }
}