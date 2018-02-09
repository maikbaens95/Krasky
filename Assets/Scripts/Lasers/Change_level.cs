using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_level : MonoBehaviour {

    [SerializeField]
    GameObject _laser;
    public bool entered;

	// Use this for initialization
	void Start () {
        entered = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!entered && collision.GetComponent<Collider2D>().tag == "Player")
        {
            entered = true;
            _laser.GetComponent<ParticleSystem>().Play();
            this.GetComponent<Collider2D>().enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Character_movement>().setfloor(2.0f);
        }
    }

}
