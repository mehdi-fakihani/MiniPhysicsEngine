
public class TransformScript {
    float[,] matrix;

    //Return the identity transform
	public static TransformScript Identity()
    {
		TransformScript identity = new TransformScript();
        identity.matrix[0, 0] = 1;
        identity.matrix[1, 1] = 1;
        identity.matrix[2, 2] = 1;
        return identity;
    }
	public TransformScript()
    {
        matrix = new float[4, 4];
        matrix[3, 3] = 1;
    }

    //When you have a transform A and you want to append B to it,
    //the result matrix is b.matrix * a.matrix.
	public TransformScript Append(TransformScript other)
    {
        float[,] result = new float[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
            {
                float c_ij = 0;
                for (int k = 0; k < 4; k++)
                    c_ij += other.matrix[i, k] * matrix[k, j];
                result[i, j] = c_ij;
            }
        matrix = result;
        return this;
    }

    //B*A does A first, then B
	public static TransformScript operator * (TransformScript a, TransformScript b)
    {
        return b.Append(a);
    }

	/*
	//+
	public static TransformScript operator + (TransformScript a, TransformScript b)
	{
		
	}

	//-
	public static TransformScript operator - (TransformScript a, TransformScript b)
	{

	}*/

	/*
	public static TransformScript Translate (Vector v, float x, float y, float z)
	public static TransformScript Rotate (Vector v, float alpha, float beta, float gama)*/


}
