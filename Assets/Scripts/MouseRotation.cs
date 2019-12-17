using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public Camera cam;
    private Transform playerTransform;
    private Rigidbody2D rb;

    void Awake()
    {
        cam = Camera.main;
        playerTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Distance from camera to object.  We need this to get the proper calculation.
        float camDis = cam.transform.position.y - playerTransform.position.y;

        // Get the mouse position in world space. Using camDis for the Z axis.
        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float AngleRad = Mathf.Atan2(mouse.y - playerTransform.position.y, mouse.x - playerTransform.position.x);
        float angle = (180 / Mathf.PI) * AngleRad;

        rb.rotation = angle;
    }
}
