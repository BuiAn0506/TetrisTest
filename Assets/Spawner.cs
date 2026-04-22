using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] tetrominoes;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        int index = Random.Range(0, tetrominoes.Length);
        Instantiate(tetrominoes[index], transform.position, Quaternion.identity);
    }
}