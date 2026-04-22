using UnityEngine;

public class BlockController : MonoBehaviour
{
    float fallTime = 0;
    public float fallSpeed = 1f;

    void Update()
    {
        // ← di chuyển trái
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;

            if (!GridManager.IsValidPosition(transform))
                transform.position += Vector3.right;
        }

        // → di chuyển phải
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            transform.position = new Vector3(
                Mathf.Round(transform.position.x),
                Mathf.Round(transform.position.y),
                0
            );

            if (!GridManager.IsValidPosition(transform))
                transform.position += Vector3.left;
            transform.position = new Vector3(
                Mathf.Round(transform.position.x),
                Mathf.Round(transform.position.y),
                0
            );
        }

        // ↓ rơi theo thời gian
        if (Time.time - fallTime >= fallSpeed)
        {
            if (Time.time - fallTime >= fallSpeed)
            {
                transform.position += Vector3.down;

                if (!GridManager.IsValidPosition(transform))
                {
                    transform.position += Vector3.up;

                    // 💥 SNAP về đúng grid
                    transform.position = new Vector3(
                        Mathf.Round(transform.position.x),
                        Mathf.Round(transform.position.y),
                        0
                    );

                    GridManager.AddToGrid(transform);

                    FindObjectOfType<Spawner>().Spawn();

                    enabled = false;
                }

                fallTime = Time.time;
            }
        }
    }
}