using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesMove : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(speed, _rb.velocity.y);
    }
}
