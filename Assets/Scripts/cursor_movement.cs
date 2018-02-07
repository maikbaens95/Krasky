using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor_movement : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse_position.z = 0;
        transform.position=mouse_position;
	}
}
