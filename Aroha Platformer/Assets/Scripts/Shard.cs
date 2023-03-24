using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{
    [SerializeField] private float deadlyYPos;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= deadlyYPos)
        {
            transform.position += new Vector3(0, 100, 0);
            rb.velocity = Vector2.zero;
        }
    }
}
