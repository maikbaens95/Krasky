using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_movement : MonoBehaviour {

    public float speed = 5.0f;
    public float jump = 5.0f;
    public float floor;

    private Rigidbody2D _rb;
    private bool ceiling_walk = false;
    private bool walk_left = false;
    private bool botas_magneticas = false;
    
	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody2D>();
        floor = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            botas_magneticas = !botas_magneticas;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.velocity = new Vector2(speed, _rb.velocity.y);
            if (walk_left)
            {
                if (ceiling_walk)
                    transform.localScale += new Vector3(-0.4F, 0, 0);
                else
                    transform.localScale += new Vector3(0.4F, 0, 0);
            }
            walk_left = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb.velocity = new Vector2((-1) * speed, _rb.velocity.y);
            if (!walk_left)
            {
                if (ceiling_walk)
                    transform.localScale += new Vector3(0.4F, 0, 0);
                else
                    transform.localScale += new Vector3(-0.4F, 0, 0);
            }
            walk_left = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ceiling_walk)
                _rb.velocity = new Vector2(_rb.velocity.x, -jump);
            else
                _rb.velocity = new Vector2(_rb.velocity.x, jump);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "techo")
        {
            if (botas_magneticas)
            {
                ceiling_walk = true;
                transform.Rotate(0, 0, 180);
                if (!walk_left)
                {
                    transform.localScale += new Vector3(-0.4F, 0, 0);
                }
                else
                {
                    transform.localScale += new Vector3(0.4F, 0, 0);
                }
                _rb.gravityScale = -5.0f;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (botas_magneticas)
        {
            if (other.tag == "techo")
            {
                transform.Rotate(0, 0, 180);
                if (walk_left)
                {
                    transform.localScale += new Vector3(-0.4F, 0, 0);
                }
                else
                {
                    transform.localScale += new Vector3(0.4F, 0, 0);
                }
                ceiling_walk = false;
                _rb.gravityScale = 5.0f;
            }
        }
    }
    
    public bool getwalking_direction()
    {
        return walk_left;
    }

    public bool getwalking_terrain()
    {
        return ceiling_walk;
    }

    public void setfloor(float f)
    {
        floor = f;
    }

    public float getfloor()
    {
        return floor;
    }
}
