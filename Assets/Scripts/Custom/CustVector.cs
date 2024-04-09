using UnityEngine;

/// <summary>
/// 自定义vector3
/// </summary>
public class CustVect3
{
    public float x;
    public float y;
    public float z;

    public CustVect3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

public static class CustVectorExtension
{
    public static Vector3 ToVector3(this CustVect3 custVect3)
    {
        return new Vector3(custVect3.x, custVect3.y, custVect3.z);
    }
}