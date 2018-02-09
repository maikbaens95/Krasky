using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_laser2f : MonoBehaviour {

    [SerializeField]
    private float speed;
    public bool izq;

    public float x_min;
    public float x_max;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (izq)
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            if (transform.localPosition.x < x_min)
            {
                izq = false;
            }
        }
        else
        {
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            if (transform.localPosition.x > x_max)
            {
                izq = true;
            }
        }


    }
}
