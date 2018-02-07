using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_controller : MonoBehaviour {

    [SerializeField]
    private float bullet_speed;
    [SerializeField]
    private GameObject bullet_explosion_prefab;
    private Rigidbody2D _rb;

    private bool coroutine;
    private bool disapear = false;

	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        _rb.velocity = transform.right * bullet_speed;
        if (!coroutine)
            StartCoroutine(UsingYield(5.0f));
        if(disapear)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];
        Vector3 contact_position = new Vector3(contact.point.x, contact.point.y, 0);
        GameObject disparo_bala = Instantiate(bullet_explosion_prefab, contact_position,Quaternion.identity);
        Destroy(this.gameObject);
    }
    

    IEnumerator UsingYield(float seconds)
    {
        coroutine = true;
        yield return new WaitForSeconds(seconds);
        disapear = true;
        coroutine = false;
    }
}
