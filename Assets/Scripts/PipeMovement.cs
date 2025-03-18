using UnityEngine;
public class PipeMovement : MonoBehaviour
{
    public float speed = 2f;
    private float destroyXPosition = -10.5f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}