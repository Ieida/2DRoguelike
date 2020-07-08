using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public int moveSpeed;

    private float horizontal;
    private float vertical;
    private Vector2 move;
    private Rigidbody2D rigidbody2d;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        vertical = Input.GetAxisRaw("Vertical") * moveSpeed;

        move = new Vector2(horizontal, vertical);
    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = move;
    }
}
