using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_UZI : MonoBehaviour {

    [SerializeField]
    private GameObject bala_UZI_prefab;
    [SerializeField]
    private GameObject puesto_bala;
    [SerializeField]
    private GameObject UZI;
    
    private Character_movement Script_character_movement;
    private bool ceiling;
    private bool left;

    private bool rafaga;
    private bool can_shoot;

    private bool coroutineStarted;

    // Use this for initialization
    void Start ()
    {
        Script_character_movement = GameObject.Find("robot").GetComponent<Character_movement>();
        rafaga = false;
        can_shoot = true;
        coroutineStarted = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rafaga = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rafaga = true;
        }
        ceiling = Script_character_movement.getwalking_terrain();
        left = Script_character_movement.getwalking_direction();
        if (!rafaga)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject disparo_bala = Instantiate(bala_UZI_prefab, puesto_bala.transform.position, Quaternion.identity);
                if ((left && !ceiling) || (!left && ceiling))
                {
                    disparo_bala.transform.Rotate(0, 0, UZI.transform.eulerAngles.z + 180);
                }
                else
                {
                    disparo_bala.transform.Rotate(0, 0, UZI.transform.eulerAngles.z);
                }
            }
        }
        else
        {
            if (can_shoot && Input.GetMouseButton(0))
            {
                can_shoot = false;
                GameObject disparo_bala = Instantiate(bala_UZI_prefab, puesto_bala.transform.position, Quaternion.identity);
                if ((left && !ceiling) || (!left && ceiling))
                {
                    disparo_bala.transform.Rotate(0, 0, UZI.transform.eulerAngles.z + 180);
                }
                else
                {
                    disparo_bala.transform.Rotate(0, 0, UZI.transform.eulerAngles.z);
                }
                if (!coroutineStarted)
                    StartCoroutine(UsingYield(0.1f));
            }
        }
    }

    IEnumerator UsingYield(float seconds)
    {
        coroutineStarted = true;

        yield return new WaitForSeconds(seconds);
        can_shoot = true;

        coroutineStarted = false;
    }
}
