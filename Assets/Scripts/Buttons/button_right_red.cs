using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_right_red : MonoBehaviour {

    private bool pushed;
    private bool button_return;
    rotate_Plat_diente_rot script_plat;
    [SerializeField]
    GameObject _plat;
    button_right_green script_other_button;
    [SerializeField]
    GameObject _otherbutton;

    // Use this for initialization
    void Start () {
        pushed = false;
        button_return = false;
        script_plat = _plat.GetComponent<rotate_Plat_diente_rot>();
        script_other_button = _otherbutton.GetComponent<button_right_green>();

	}
	
	// Update is called once per frame
	void Update () {
	    if (button_return)
        {
            button_return = false;
            pushed = false;
            transform.position += new Vector3(-0.4f, 0, 0);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!pushed && collision.gameObject.tag == "Player")
        {
            transform.position += new Vector3(0.4f, 0, 0);
            pushed = true;
            script_plat.set_rota_arriba(true);
            Destroy(GameObject.Find("/Escenario/1st floor/First_metal_floor"));
            script_other_button.set_button_return(true);
        }
    }

    public void set_button_return(bool p)
    {
        button_return = p;
    }
}
