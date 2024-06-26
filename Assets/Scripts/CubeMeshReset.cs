using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMeshReset : MonoBehaviour
{
    private MeshFilter meshFilter;

    // Default cube mesh data
    private Vector3[] defaultVertices = new Vector3[]
    {
        new Vector3(-0.5f, -0.5f,  0.5f), new Vector3( 0.5f, -0.5f,  0.5f), new Vector3( 0.5f,  0.5f,  0.5f), new Vector3(-0.5f,  0.5f,  0.5f),
        new Vector3(-0.5f, -0.5f, -0.5f), new Vector3( 0.5f, -0.5f, -0.5f), new Vector3( 0.5f,  0.5f, -0.5f), new Vector3(-0.5f,  0.5f, -0.5f)
    };

    private int[] defaultTriangles = new int[]
    {
        0, 2, 1, 0, 3, 2, // front
        2, 3, 7, 2, 7, 6, // top
        0, 7, 3, 0, 4, 7, // left
        1, 6, 5, 1, 2, 6, // right
        5, 7, 4, 5, 6, 7, // back
        0, 5, 4, 0, 1, 5  // bottom
    };

    private Vector3[] defaultNormals = new Vector3[]
    {
        Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward,
        Vector3.back, Vector3.back, Vector3.back, Vector3.back
    };

    private Vector2[] defaultUVs = new Vector2[]
    {
        new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1),
        new Vector2(1, 0), new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1)
    };

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

        if (meshFilter != null)
        {
            ResetMeshToDefault();
        }
    }

    void ResetMeshToDefault()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = defaultVertices;
        mesh.triangles = defaultTriangles;
        mesh.normals = defaultNormals;
        mesh.uv = defaultUVs;

        meshFilter.mesh = mesh;
    }
}
