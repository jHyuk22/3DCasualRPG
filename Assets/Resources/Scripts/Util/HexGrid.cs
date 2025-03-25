using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public GameObject hexPrefab1; // ū ������ Ÿ�� ������(�⺻)
    public GameObject hexPrefab2; // ���� ������ Ÿ�� ������
    public int width = 5;
    public int height = 5;
    public float hexSize = Mathf.Sqrt(3) / 3; // ������ �� ���� ����
    public int radius1 = 3; // ū �������� ������ ũ��(�⺻)
    public int radius2 = 3; // ū �������� ������ ũ��

    void Start()
    {
        //GenerateHexGrid();
        //GenerateHexPattern();
        GenerateHexIsland();
    }

    void GenerateHexGrid()
    {
        float xOffset = hexSize * 1.5f;
        float zOffset = hexSize * Mathf.Sqrt(3);

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                float xPos = x * xOffset;
                float zPos = z * zOffset;

                // Ȧ�� ���� �� ĭ �Ʒ��� ������
                if (x % 2 == 1)
                    zPos += zOffset / 2f;

                Vector3 pos = new Vector3(xPos, 0, zPos);
                Quaternion quat = Quaternion.Euler(0, 30, 0);
                Instantiate(hexPrefab1, pos, quat, transform);
            }
        }
    }

    void GenerateHexPattern()
    {
        List<Vector2Int> hexCoords = GetHexagonCoordinates(radius1);

        foreach (Vector2Int coord in hexCoords)
        {
            Vector3 worldPos = HexToWorld(coord.x, coord.y);
            Quaternion quat = Quaternion.Euler(0, 30, 0);
            Instantiate(hexPrefab1, worldPos, quat, transform);
        }
    }

    void GenerateHexIsland()
    {
        List<Vector2Int> hexCoords = GetHexagonCoordinates(radius1);

        foreach (Vector2Int coord in hexCoords)
        {
            Vector3 worldPos = HexToWorld(coord.x, coord.y);

            // �ٴ� Ÿ�� ��ġ (radius1 ���� ��ü)
            GameObject prefab = hexPrefab1;

            // �߽ɿ��� radius2 �̳��̸� ��(prefab2)���� ����
            if (Mathf.Abs(coord.x) <= radius2 && Mathf.Abs(coord.y) <= radius2 && Mathf.Abs(-coord.x - coord.y) <= radius2)
            {
                prefab = hexPrefab2;
            }

            Quaternion quat = Quaternion.Euler(0, 30, 0);
            Instantiate(prefab, worldPos, quat, transform);
        }
    }

    // ū ������ ��ǥ ���
    List<Vector2Int> GetHexagonCoordinates(int radius)
    {
        List<Vector2Int> hexCoords = new List<Vector2Int>();

        for (int q = -radius; q <= radius; q++)
        {
            int r1 = Mathf.Max(-radius, -q - radius);
            int r2 = Mathf.Min(radius, -q + radius);

            for (int r = r1; r <= r2; r++)
            {
                hexCoords.Add(new Vector2Int(q, r));
            }
        }

        return hexCoords;
    }

    // ������ ť�� ��ǥ(q, r)�� ���� ��ǥ(x, z)�� ��ȯ
    Vector3 HexToWorld(int q, int r)
    {
        float x = hexSize * (1.5f * q);
        float z = hexSize * Mathf.Sqrt(3) * (r + q / 2f);
        return new Vector3(x, 0, z);
    }
}
