using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arranca_laser : MonoBehaviour {

    [SerializeField]
    GameObject _laser;
    [SerializeField]
    GameObject _collider2;
    [SerializeField]
    GameObject _collider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<buttons_floor2_down>().get_pushed())
        {
            _laser.GetComponent<ParticleSystem>().Play();
            _collider.GetComponent<Collider2D>().enabled = true;
            _collider.GetComponent<Move_laser2f>().enabled = true;
            _collider2.GetComponent<Move_laser2f>().enabled = true;
        }
	}
}
