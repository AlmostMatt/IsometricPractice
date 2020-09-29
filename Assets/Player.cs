using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // XZ plane
    // private static Vector3 RIGHT = new Vector3(1, 0, 1).normalized;
    // private static Vector3 UP = new Vector3(-1, 0, 1).normalized;
    // XY plane
    //private static Vector3 RIGHT = new Vector3(2, -1, 0).normalized;
    //private static Vector3 UP = new Vector3(2, 1, 0).normalized;
    // XY plane, take 2
    private static Vector3 RIGHT = new Vector3(2, 0, 0);
    private static Vector3 UP = new Vector3(0, 1, 0);

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        //Vector2 inWorldDir = new Vector2(Input.GetAxis("Horizontal") * 2, Input.GetAxis("Vertical"));
        //AccelToward(inWorldDir);
        Vector2 movementDir = Input.GetAxis("Horizontal") * RIGHT + Input.GetAxis("Vertical") * UP;
        AccelToward(movementDir);
        
    }

    private void AccelToward(Vector2 movementDir)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // If Movement dir has magnitude > 1, scale it down. Magnitude less than 1 is ok.
        if (movementDir.SqrMagnitude() > 1)
        {
            movementDir.Normalize();
        }
        Vector2 desiredV = GetMaxSpeed() * movementDir;
        Vector2 deltaV = desiredV - rb.velocity;
        float accelNeeded = deltaV.magnitude / Time.fixedDeltaTime;
        Vector2 actualAccel = Mathf.Min(accelNeeded, GetAccel()) * deltaV.normalized;
        rb.AddForce(actualAccel);
    }

    private float GetMaxSpeed()
    {
        return 8f;
    }

    private float GetAccel()
    {
        return 40f;
    }
}
