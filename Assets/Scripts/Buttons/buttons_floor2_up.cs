using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons_floor2_up : MonoBehaviour {

    private bool pushed;

	// Use this for initialization
	void Start () {
        pushed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Player")
        {
            pushed = true;
            transform.position += new Vector3(0, 0.5f, 0);
        }
    }

    public bool get_pushed ()
    {
        return pushed;
    }

}
