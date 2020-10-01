using UnityEngine;

public class IsometricUtilities
{
    public const float X_PER_Y = 108f / 41f;
    public const float Y_PER_X = 1f / X_PER_Y;

    public static Vector3 ISO_RIGHT = new Vector3(X_PER_Y, 0, 0);
    public static Vector3 ISO_UP = new Vector3(0, 1, 0);

    public static Vector3 IsoToCartesian(Vector3 v)
    {
        return new Vector3(v.x, v.y / Y_PER_X, v.z);
    }

    public static Vector3 CartesianToIso(Vector3 v)
    {
        return new Vector3(v.x, v.y * Y_PER_X, v.z);
    }
}
