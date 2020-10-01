using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricSort : MonoBehaviour
{
    void Update()
    {
        Vector3 pos = transform.localPosition;
        // Set z = y, so that objects higher on the screen will be drawn in the back 
        transform.localPosition = new Vector3(pos.x, pos.y, pos.y);
    }
}
