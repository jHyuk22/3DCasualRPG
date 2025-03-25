using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public GameObject hexPrefab1; // 큰 육각형 타일 프리팹(기본)
    public GameObject hexPrefab2; // 작은 육각형 타일 프리팹
    public int width = 5;
    public int height = 5;
    public float hexSize = Mathf.Sqrt(3) / 3; // 육각형 한 변의 길이
    public int radius1 = 3; // 큰 육각형의 반지름 크기(기본)
    public int radius2 = 3; // 큰 육각형의 반지름 크기

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

                // 홀수 열은 반 칸 아래로 내리기
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

            // 바다 타일 배치 (radius1 영역 전체)
            GameObject prefab = hexPrefab1;

            // 중심에서 radius2 이내이면 땅(prefab2)으로 변경
            if (Mathf.Abs(coord.x) <= radius2 && Mathf.Abs(coord.y) <= radius2 && Mathf.Abs(-coord.x - coord.y) <= radius2)
            {
                prefab = hexPrefab2;
            }

            Quaternion quat = Quaternion.Euler(0, 30, 0);
            Instantiate(prefab, worldPos, quat, transform);
        }
    }

    // 큰 육각형 좌표 계산
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

    // 육각형 큐브 좌표(q, r)를 월드 좌표(x, z)로 변환
    Vector3 HexToWorld(int q, int r)
    {
        float x = hexSize * (1.5f * q);
        float z = hexSize * Mathf.Sqrt(3) * (r + q / 2f);
        return new Vector3(x, 0, z);
    }
}
