using System.Linq;
using UnityEngine;

public class MeshGen : MonoBehaviour {
     public int quality = 1; // Quality parameter for polygonization

    public static Mesh GenerateMesh(int[,] data)
    {
             Mesh mesh = new Mesh();

        int width = data.GetLength(0);
        int height = data.GetLength(1);

        Vector3[] vertices = new Vector3[width * height];
        int[] triangles = new int[(width - 1) * (height - 1) * 6];

        int triangleIndex = 0;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                vertices[y * width + x] = new Vector3(x, data[x, y], y);

                if (x < width - 1 && y < height - 1)
                {
                    triangles[triangleIndex] = y * width + x;
                    triangles[triangleIndex + 1] = (y + 1) * width + x;
                    triangles[triangleIndex + 2] = y * width + x + 1;

                    triangles[triangleIndex + 3] = y * width + x + 1;
                    triangles[triangleIndex + 4] = (y + 1) * width + x;
                    triangles[triangleIndex + 5] = (y + 1) * width + x + 1;

                    triangleIndex += 6;
                }
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles.Reverse().ToArray(); // Reversing triangle order
        mesh.RecalculateNormals();


        return mesh;
    }


    // Example usage

}