using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject topPipePrefab;
    public GameObject bottomPipePrefab;
    public float spawnRate = 2f;
    public float minHeightY = -5f;
    public float maxHeightY = 5f;
    public float pipeGap = 3f;
    private float spawnX = 10.5f;

    private float topScreenBound = 5f;
    private float bottomScreenBound = -5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPipes), 1f, spawnRate);
    }

    void SpawnPipes()
    {
        float gapBottomY = Random.Range(minHeightY, maxHeightY);
        float gapTopY = gapBottomY + pipeGap;

        float bottomPipeHeight = gapBottomY - bottomScreenBound;
        float topPipeHeight = topScreenBound - gapTopY;

        GameObject pipeGroup = new GameObject("PipeGroup");
        pipeGroup.transform.position = new Vector3(spawnX, 0, 0);

        GameObject topPipe = Instantiate(topPipePrefab, pipeGroup.transform);
        topPipe.transform.position = new Vector3(spawnX, topScreenBound - (topPipeHeight / 2f), 0);
        topPipe.transform.rotation = Quaternion.Euler(0, 0, 180);
        topPipe.transform.localScale = new Vector3(topPipe.transform.localScale.x, topPipeHeight, topPipe.transform.localScale.z);

        GameObject bottomPipe = Instantiate(bottomPipePrefab, pipeGroup.transform);
        bottomPipe.transform.position = new Vector3(spawnX, bottomScreenBound + (bottomPipeHeight / 2f), 0);
        bottomPipe.transform.localScale = new Vector3(bottomPipe.transform.localScale.x, bottomPipeHeight, bottomPipe.transform.localScale.z);

        pipeGroup.AddComponent<PipeMovement>();
    }
}
