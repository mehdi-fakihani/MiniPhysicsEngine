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

    public Vector()
    {

    }

	//GETTERS AND SETTERS
	public float X {get{return x;} set{ x = value;}}
	public float Y {get{return y;} set{ y = value;}}
	public float Z {get{return z;} set{ z = value;}}

	public static Vector Zero() //TO REMOVE
	{
		return new Vector();
	}


    public float Dot(Vector other)
    {
        return x * other.X +
               y * other.Y +
               z * other.Z;
    }

    public Vector Cross(Vector other)
    {
        return new Vector(y*other.Z - z*other.Y,
                          z*other.X - x*other.Z,
                          x*other.Y - y*other.X);
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
        return a.X == b.X &&
               a.Y == b.Y &&
               a.Z == b.Z;
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
        return new Vector(-a.X, -a.Y, -a.Z);
    }

    public static Vector operator - (Vector a, Vector b)
    {
        return new Vector(a.X - b.X,
                          a.Y - b.Y,
                          a.Z - b.Z);
    }
    public static Vector operator * (Vector u, float k)
    {
        return new Vector(u.X * k, u.Y * k, u.Z * k);
    }

    public static Vector operator *(float k, Vector u)
    {
        return new Vector(u.X * k, u.Y * k, u.Z * k);
    }
    public static Vector operator / (Vector u, float k)
    {
        return new Vector(u.X / k, u.Y / k, u.Z / k);
    }
}
