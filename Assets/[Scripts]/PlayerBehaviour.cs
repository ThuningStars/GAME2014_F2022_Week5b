using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    public float speed = 2.0f;
    public Boundary boundary;
    public float verticalPosition;

    public Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Mobilenput();
        Move();
    }

    public void Mobilenput()
    {
        foreach(var touch in Input.touches)
        {
            transform.position = camera.ScreenToWorldPoint(touch.position);
        }
    }

    public void ConventionalInput()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.position += new Vector3(x, 0.0f, 0.0f);
    }

    public void Move()
    {
        // check bounds
        var clampedPosition = Mathf.Clamp(transform.position.x, boundary.min, boundary.max);
        transform.position = new Vector2(clampedPosition, verticalPosition);
    }
}
