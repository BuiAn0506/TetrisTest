using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static int width = 10;
    public static int height = 20;

    public static Transform[,] grid = new Transform[10, 20];

    public static bool IsInsideGrid(Vector3 pos)
    {
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);

        return (x >= 0 && x < width && y >= 0);
    }

    public static void AddToGrid(Transform block)
    {
        foreach (Transform child in block)
        {
            int x = Mathf.RoundToInt(child.position.x);
            int y = Mathf.RoundToInt(child.position.y);

            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                grid[x, y] = child;
            }
        }
    }

    public static bool IsValidPosition(Transform block)
    {
        foreach (Transform child in block)
        {
            int x = Mathf.RoundToInt(child.position.x);
            int y = Mathf.RoundToInt(child.position.y);

            // ❌ ra ngoài grid
            if (x < 0 || x >= width || y < 0)
                return false;

            // 💥 check va chạm block khác
            if (y < height)
            {
                if (grid[x, y] != null && grid[x, y].parent != block)
                {
                    return false;
                }
            }
        }
        return true;
    }
}