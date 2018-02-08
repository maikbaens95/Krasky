using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muere_laser : MonoBehaviour {

    private float vida;
    [SerializeField]
    GameObject _laser_collider;
    [SerializeField]
    GameObject _laser;

    // Use this for initialization
    void Start () {
        vida = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (vida == 0.0f)
        {
            _laser_collider.GetComponent<Collider2D>().enabled = false;
            Destroy(_laser.gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (vida > 0.0f && collision.collider.tag == "bullet")
        {
            --vida;
        }
    }
}
