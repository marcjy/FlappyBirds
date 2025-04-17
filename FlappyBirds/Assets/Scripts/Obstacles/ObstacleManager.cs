using System.Collections;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public int EndPositionX = -10;
    public float Speed = 1.0f;

    private void Start()
    {
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        Vector2 target = new Vector2(-10, 0);

        while ((Vector2)transform.position != target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
    }
}
