using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Vector2 movementDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        AccelToward(movementDir);
    }

    private void AccelToward(Vector2 cartesianMoveDir)
    {
        // Use cartesian coordinates to compute desired V, force required, etc.
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 cartesianVel = IsometricUtilities.IsoToCartesian(rb.velocity);
        Debug.Log(rb.velocity);
        // If Movement dir has magnitude > 1, scale it down. Magnitude less than 1 is ok.
        if (cartesianMoveDir.SqrMagnitude() > 1)
        {
            cartesianMoveDir.Normalize();
        }
        Vector2 desiredV = GetMaxSpeed() * cartesianMoveDir;
        Vector2 deltaV = desiredV - cartesianVel;
        float accelNeeded = deltaV.magnitude / Time.fixedDeltaTime;
        Vector2 actualAccel = Mathf.Min(accelNeeded, GetAccel()) * deltaV.normalized;
        // Convert back to isometric (screen) coordinates before applying the force
        rb.AddForce(IsometricUtilities.CartesianToIso(actualAccel));
    }

    private float GetMaxSpeed()
    {
        return 6f;
    }

    private float GetAccel()
    {
        return 50f;
    }
}
