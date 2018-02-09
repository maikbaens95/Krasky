using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_suelo_2floor : MonoBehaviour {

    [SerializeField]
    GameObject button_1;
    [SerializeField]
    GameObject button_2;
    [SerializeField]
    GameObject button_3;
    [SerializeField]
    GameObject button_4;
    [SerializeField]
    GameObject turret_central;

    private bool Condicion_1;
    private bool Condicion_2;
    private bool Condicion_3;
    private bool Condicion_4;
    private bool Condicion_5;

    // Use this for initialization
    void Start ()
    {
        Condicion_1 = false;
        Condicion_2 = false;
        Condicion_3 = false;
        Condicion_4 = false;
        Condicion_5 = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (!Condicion_1)
        {
            Condicion_1 = button_1.GetComponent<buttons_floor2_up>().get_pushed();
        }
        if (!Condicion_2)
        {
            Condicion_2 = button_2.GetComponent<buttons_floor2_down>().get_pushed();
        }
        if (!Condicion_3)
        {
            Condicion_3 = button_3.GetComponent<buttons_floor2_up>().get_pushed();
        }
        if (!Condicion_4)
        {
            Condicion_4 = button_4.GetComponent<buttons_floor2_down>().get_pushed();
        }
        if (!Condicion_5)
        {
            Condicion_5 = turret_central.GetComponent<Weapon_turret>().getAlive();
        }

        if (Condicion_1 && Condicion_2 && Condicion_3 && Condicion_4 && Condicion_5)
        {
            Destroy(this.gameObject);
        }
    }
}
