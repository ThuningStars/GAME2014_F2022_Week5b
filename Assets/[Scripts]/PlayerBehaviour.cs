using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    public float speed = 2.0f;
    public Boundary boundary;
    public float verticalPosition;


    // Update is called once per frame
    void Update()
    {
        Move();

    }

    public void Move()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        transform.position += new Vector3(x, 0.0f, 0.0f);

        // check bounds
        var clampedPosition = Mathf.Clamp(transform.position.x, boundary.min, boundary.max);
        transform.position = new Vector2(clampedPosition, verticalPosition);

    }

    //public void CheckBounds()
    //{
    //    if(transform.position.x > boundary.max)
    //    {
    //        transform.position = new Vector2(boundary.max, verticalPosition);
    //    }
    //    if (transform.position.x < boundary.min)
    //    {
    //        transform.position = new Vector2(boundary.min, verticalPosition);
    //    }
    //}
}
