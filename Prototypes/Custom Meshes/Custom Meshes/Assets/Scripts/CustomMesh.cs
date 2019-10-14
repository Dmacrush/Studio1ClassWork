using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMesh : MonoBehaviour
{
    private void Start()
    {
        CreateQuadTileMap();
    }

    private void BasicQuadMesh()
    {
        //always rememeber you need to define the vertices, UVs and Triangles
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(0     ,0);
        vertices[1] = new Vector3(0     ,100);
        vertices[2] = new Vector3(100   ,100);
        vertices[3] = new Vector3(100   ,0);

        //they are normalised meaning origin is 0,0 and top right corner is 1,1
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);


        //remember when ordering triangles its best to do clockwise otherwise the backface may show on the front instead of the frontface
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;


        GetComponent<MeshFilter>().mesh = mesh;

    }
    private void BasicTriangleMesh()
    {
        //always rememeber you need to define the vertices, UVs and Triangles
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[3];
        Vector2[] uv = new Vector2[3];
        int[] triangles = new int[3];

        vertices[0] = new Vector3(0, 0);
        vertices[1] = new Vector3(0, 100);
        vertices[2] = new Vector3(100, 100);
        
        //they are normalised meaning origin is 0,0 and top right corner is 1,1
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);
        
        //remember when ordering triangles its best to do clockwise otherwise the backface may show on the front instead of the frontface
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;


        GetComponent<MeshFilter>().mesh = mesh;

    }

    private void CreateQuadTileMap()
    {
        //always rememeber you need to define the vertices, UVs and Triangles
        Mesh mesh = new Mesh();

        int width = 5;
        int height = 5;
        float tileSize = 10f;

        Vector3[] vertices = new Vector3[4 * (width * height)];
        Vector2[] uv = new Vector2[4 * (width * height)];
        int[] triangles = new int[6 * (width * height)];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int index = i * height + j;
                
                vertices[index * 4 + 0] = new Vector3(tileSize * i      , tileSize * j);
                vertices[index * 4 + 1] = new Vector3(tileSize * i      , tileSize * (j + 1));
                vertices[index * 4 + 2] = new Vector3(tileSize * (i + 1), tileSize * (j + 1));
                vertices[index * 4 + 3] = new Vector3(tileSize * (i + 1), tileSize * j);

                //they are normalised meaning origin is 0,0 and top right corner is 1,1
                uv[index * 4 + 0] = new Vector2(0, 0);
                uv[index * 4 + 1] = new Vector2(0, 1);
                uv[index * 4 + 2] = new Vector2(1, 1);
                uv[index * 4 + 3] = new Vector2(1, 0);


                //remember when ordering triangles its best to do clockwise otherwise the backface may show on the front instead of the frontface
                triangles[index * 6 + 0] = index * 4 + 0;
                triangles[index * 6 + 1] = index * 4 + 1;
                triangles[index * 6 + 2] = index * 4 + 2;

                triangles[index * 6 + 3] = index * 4 + 0;
                triangles[index * 6 + 4] = index * 4 + 2;
                triangles[index * 6 + 5] = index * 4 + 3;

            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;

    }
}
