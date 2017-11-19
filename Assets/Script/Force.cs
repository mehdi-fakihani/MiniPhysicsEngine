using System;
public class Force : Vector {

	//Une force est appliquée en un point précis
	Vector position{ get; set; }
	float length { get; set; }
	Vector normalized{ get; set; }


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




}
