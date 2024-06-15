using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] DistanceJoint2D distanceJoint2D;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        distanceJoint2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, mousePos);
            lineRenderer.SetPosition(1, transform.position);
            distanceJoint2D.connectedAnchor = mousePos;
            distanceJoint2D.enabled = true;
            lineRenderer.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            distanceJoint2D.enabled = false;
            lineRenderer.enabled = false;
        }

        if(distanceJoint2D.enabled)
        {
            lineRenderer.SetPosition(1, transform.position);
        }
    }
}
