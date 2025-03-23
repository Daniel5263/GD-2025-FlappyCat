using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.5f;
    [SerializeField] private GameObject pipes;

    private float timer;

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(10.5f, Random.Range(-heightRange, heightRange));
        GameObject pipe = Instantiate(pipes, spawnPos, Quaternion.identity);

        Destroy(pipe, 10f);
    }
}
