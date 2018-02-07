using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_explosion_autodestroy : MonoBehaviour {

    private float delay = 0.1f;

	// Use this for initialization
	void Start () {
        GameObject _anim = GameObject.Find("bullet_explosion_anim");
        Destroy(this.gameObject, _anim.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
