using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Boundary horizontalBoundary;
    public Boundary verticalBoundary;
    public Boundary horizontalSpeedRange;
    public float horizontalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        var RandomXPosition = Random.Range(horizontalBoundary.min, horizontalBoundary.max);
        var RandomYPosition = Random.Range(verticalBoundary.min, verticalBoundary.max);
        horizontalSpeedRange.min = Random.Range(0.75f, 1.8f);
        horizontalSpeedRange.max = Random.Range(1.8f, 5.0f);
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
        transform.position = new Vector3(RandomXPosition, RandomYPosition, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalLength = horizontalBoundary.max - horizontalBoundary.min;
        transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed, horizontalLength) - horizontalBoundary.max,
            transform.position.y, transform.position.z);
    }
}
