using System;
public class Vector {

	float x;
	float y;
	float z;

    public float Length
    {
        get
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
    }
    public Vector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

	//GETTERS AND SETTERS
	public float X {get{return x;} set{ x = value;}}
	public float Y {get{return y;} set{ y = value;}}
	public float Z {get{return z;} set{ z = value;}}

	public static Vector Zero()
	{
		return new Vector (0f, 0f, 0f);
	}


    public float Dot(Vector other)
    {
        return x * other.x +
               y * other.y +
               z * other.z;
    }

    public Vector Cross(Vector other)
    {
        return new Vector(y*other.z - z*other.y,
                          z*other.x - x*other.z,
                          x*other.y - y*other.x);
    }

    // Divides the vector by its length
    public Vector Normalize()
    {
        float length = Length;
        if (length != 1)
        {
            x /= length;
            y /= length;
            z /= length;
        }
        return this;
    }

    ///////////////////////////////////////////
    ////              Operators            ////
    ///////////////////////////////////////////

    public static bool operator == (Vector a, Vector b)
    {
        return a.x == b.x &&
               a.y == b.y &&
               a.z == b.z;
    }

    public static bool operator != (Vector a, Vector b)
    {
        return !(a == b);
    }

    public static Vector operator + (Vector a, Vector b)
    {
        return new Vector(a.X + b.X,
                          a.Y + b.Y,
                          a.Z + b.Z);
    }

    public static Vector operator - (Vector a)
    {
        return new Vector(-a.x, -a.y, -a.z);
    }

    public static Vector operator - (Vector a, Vector b)
    {
        return new Vector(a.x - b.x,
                          a.y - b.y,
                          a.z - b.z);
    }

    public static float Dot(Vector a, Vector b)
    {
        return a.Dot(b);
    }

    public Vector Cross(Vector a, Vector b)
    {
        return a.Cross(b);
    }

    public static Vector operator * (Vector u, float k)
    {
        return new Vector(u.x * k, u.y * k, u.z * k);
    }
    public static Vector operator / (Vector u, float k)
    {
        return new Vector(u.x / k, u.y / k, u.z / k);
    }
}
