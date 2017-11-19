
public class Transform {
    float[,] matrix;

    //Return the identity transform
    public static Transform Identity()
    {
        Transform identity = new Transform();
        identity.matrix[0, 0] = 1;
        identity.matrix[1, 1] = 1;
        identity.matrix[2, 2] = 1;
        return identity;
    }
    public Transform()
    {
        matrix = new float[4, 4];
        matrix[3, 3] = 1;
    }

    //When you have a transform A and you want to append B to it,
    //the result matrix is b.matrix * a.matrix.
    public Transform Append(Transform other)
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
    public static Transform operator * (Transform a, Transform b)
    {
        return b.Append(a);
    }
}
