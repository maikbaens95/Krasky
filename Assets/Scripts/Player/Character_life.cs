using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_life : MonoBehaviour {

    [SerializeField]
    private float live_max;
    private float live;
    public float l;

	// Use this for initialization
	void Start () {
        live = live_max;
	}
	
	// Update is called once per frame
	void Update () {
        l = live;
        if (live == 0)
        {
            SceneManager.LoadScene(4);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "bullet")
        {
            live -= 10;
        }
        if (collision.collider.tag == "botiquin")
        {
            live += 100;
            if (live > live_max)
            {
                live = live_max;
            }
        }
        if (collision.collider.tag == "Laser")
        {
            live = 0;
        }
    }
}
