using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_Plat_diente_rot : MonoBehaviour {

    private bool rota_abajo;
    private bool rota_arriba;
    [SerializeField]
    private float rot_speed_bajada;
    [SerializeField]
    private float rot_speed_subida;
    private float Angle;

    // Use this for initialization
    void Start () {
        rota_abajo = false;
        rota_arriba = false;
	}
	
	// Update is called once per frame
	void Update () {

        Angle = transform.rotation.eulerAngles.z;
        if (Angle == 270.0f)
        {
            rota_abajo = false;
        }
        if (Angle == 0.0)
        {
            rota_arriba = false;
        }
        if (rota_abajo && (Angle > 270.0f || Angle == 0.0f))
        {
            transform.Rotate(new Vector3(0, 0, -2.0f) * rot_speed_bajada);
        }
        if (rota_arriba && Angle > 0)
        {
            transform.Rotate(new Vector3(0, 0, 2.0f) * rot_speed_subida);
            if (transform.rotation.eulerAngles.z > 356.0f)
                transform.eulerAngles = new Vector3(0, 0, 0.0f);
        }

    }

    public void set_rota_abajo(bool r)
    {
        rota_abajo = true;
    }

    public void set_rota_arriba(bool r)
    {
        rota_arriba = true;
    }
}
