using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    private float resetSpeed = 0.5f;
    private float cameraSpeed = 0.5f;
    private float offsetZ;
    private float offsetY;

    public Transform pausePanel;

    public Bounds cameraBounds;

    private Transform target;
    
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;

    private bool followsPlayer;
    void Awake()
    {
        BoxCollider2D myCol = GetComponent<BoxCollider2D>();
        myCol.size = new Vector2(Camera.main.aspect * 2f * Camera.main.orthographicSize, 10f);
        cameraBounds = myCol.bounds;
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        lastTargetPosition = target.position;
        offsetY = (transform.position - target.position).y;
        offsetZ = (transform.position - target.position).z;
        followsPlayer = true;
    }

    void FixedUpdate()
    {
        if (followsPlayer)
        {
            Vector3 aheadTargetPos = new Vector3(target.position.x, target.position.y + offsetY, offsetZ);

            Vector3 newCameraPosition =
                Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, cameraSpeed);

            transform.position = new Vector3(newCameraPosition.x, newCameraPosition.y, offsetZ);
            lastTargetPosition = target.position;

        }
    }
}
