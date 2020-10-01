using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour
{
    private const float D_ON_PLANE = 7f;
    private const float D_FROM_PLANE = 5f;
    // Start is called before the first frame update
    void Start()
    {
        XYPlane();
        Debug.Log(transform.localPosition);
        Debug.Log(transform.localEulerAngles);
    }

    private void XYPlane()
    {
        // Alternative implementation: move away from the origin and look at the origin
        float dxy = Mathf.Cos(Mathf.PI / 4) * D_ON_PLANE;
        transform.localPosition = new Vector3(-dxy, -dxy, D_FROM_PLANE);

        // LocalEulerAngles does rotations in order: Z then Y then X
        // I want to rotate around x axis then around global z axis
        float camAngle = 90f - GetCameraAngle();
        transform.localEulerAngles = new Vector3(camAngle - 180, 0f, 0f);
        // Turn to face the origin
        transform.Rotate(0f, 0f, -45, Space.World);
        // Flip camera (otherwise it is upside down)
        transform.Rotate(0f, 0f, 180, Space.Self);
    }

    private void XZPlane()
    {
        // LocalEulerAngles does rotations in order: Z then Y then X
        // Formula 1: for exact equilateral triangles and hexagons
        float dxy = Mathf.Cos(Mathf.PI / 4) * D_ON_PLANE;
        transform.localPosition = new Vector3(-dxy, D_FROM_PLANE, -dxy);

        // Formula 2: for 1:2 y:x ratio on slopes
        // I did some notes on paper, but the idea is that 0 degrees is undistorted
        // and slight rotation means that more y tiles are seen, and each tile's y is squished
        transform.localEulerAngles = new Vector3(GetCameraAngle(), -45f, 0f);
    }

    private float GetCameraAngle()
    {
        float ySizePerX = 0.5f;
        float numYTilesPerXTile = 1 / ySizePerX;
        float xAngle = Mathf.Rad2Deg * Mathf.Asin(ySizePerX);
        return xAngle;
    }
}
