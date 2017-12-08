using System;
public class Force : Vector {

	//Une force est appliquée en un point précis
	Vector position{ get; set; }
	float length { get; set; }
	Vector normalized{ get; set; }


	private const double G = 6.674E-11;

	//GETTERS AND SETTERS
	public Vector Position {get{return position;} set{ position = value;}}
	public float Length {get{return length;} set{ length = value;}}
	public Vector Normalized {get{return normalized;} set{ normalized = value;}}

	public Force(Vector i_pos, float x, float y, float z) : base(x, y, z)
	{
		this.position = i_pos;
		this.length = this.Length;
		this.normalized = this.Normalize();
	}


	public void Gravity(Object3D me, Object3D other){
		double dist = (me.Position - other.Position).Length;
		if (dist != 0.0) {
			Vector value = new Vector (other.Position.X - me.Position.X, other.Position.Y - me.Position.Y, other.Position.Z - me.Position.Z);
			value = value.Normalize ();
			value = value * (float)(G * me.Mass * other.Mass / (dist * dist));
			this.X = value.X;
			this.Y = value.Y;
			this.Z = value.Z;
		}
	}

}
