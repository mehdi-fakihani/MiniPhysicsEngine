using System;
public class Force : Vector {

    //A force is applied on a specific point (yet it hasn't been used, it was supposed to be useful to handle torques)
    private Vector applicationPoint;


	private const double G = 6.674E-11;

	//GETTERS AND SETTERS
	public Vector ApplicationPoint {get{return applicationPoint;} set{ applicationPoint = value;}}

	public Force(Vector applicationPoint, float x, float y, float z) : base(x, y, z)
	{
		this.applicationPoint = applicationPoint;
	}

    public Force(float x, float y, float z) : base(x, y, z)
    {
    }

    public Force() : base(0,0,0)
    {

    }

    ///////////////////////////////////////////
    ////          Generic forces           ////
    ///////////////////////////////////////////

    /*Returns the gravity force caused by other to apply on me*/
    public static Force Gravity(Object3D me, Object3D other){
		double dist = (other.Position - me.Position).Length;
        if (dist != 0.0)
        {
            Vector direction = (other.Position - me.Position).Normalize();
            Vector result = direction * (float)(G * me.Mass * other.Mass / (dist * dist));
            return new Force(result.X, result.Y, result.Z);
        }
        else
            return new Force();
	}

    /*Returns the impulse to apply on me if it's in collision with other*/
    public static Force ImpulseIfCollision(Object3D me, Object3D other)
    {
        float distance = (me.Position - other.Position).Length;
        Vector normal = (me.Position - other.Position).Normalize();
        Vector relativeSpeed = me.Speed - other.Speed;
        if (distance <= me.Radius + other.Radius)
        {
            Vector impulse = -1 * ((1.0f + EngineScript.e) * relativeSpeed.Dot(normal) / (1.0f / me.Mass + 1.0f / other.Mass)) * normal;
            return new Force(impulse.X, impulse.Y, impulse.Z);
        }
        else
            return new Force();
    }

    ///////////////////////////////////////////
    ////              Operators            ////
    ///////////////////////////////////////////
    public static Force operator +(Force a, Force b)
    {
        return new Force(a.X + b.X,
                         a.Y + b.Y,
                         a.Z + b.Z);
    }

    public static Force operator -(Force a)
    {
        return new Force(-a.X, -a.Y, -a.Z);
    }

    public static Force operator -(Force a, Force b)
    {
        return new Force(a.X - b.X,
                         a.Y - b.Y,
                         a.Z - b.Z);
    }
    public static Force operator *(Force u, float k)
    {
        return new Force(u.X * k, u.Y * k, u.Z * k);
    }
    public static Force operator /(Force u, float k)
    {
        return new Force(u.X / k, u.Y / k, u.Z / k);
    }

}
