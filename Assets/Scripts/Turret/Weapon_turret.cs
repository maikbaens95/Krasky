using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_turret : MonoBehaviour
{

    [SerializeField]
    private GameObject bala_turret_prefab;
    [SerializeField]
    private GameObject puesto_bala_turret;
    [SerializeField]
    private GameObject turret;
    [SerializeField]
    private Camera camera;

    private bool rafaga;
    private bool can_shoot;

    private bool coroutineStarted;

    // Use this for initialization
    void Start()
    {
        can_shoot = true;
        coroutineStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = camera.WorldToViewportPoint(this.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        if (onScreen)
        {
            if (can_shoot)
            {
                can_shoot = false;
                GameObject disparo_bala_turret = Instantiate(bala_turret_prefab, puesto_bala_turret.transform.position, Quaternion.identity);
                disparo_bala_turret.transform.Rotate(0, 0, turret.transform.eulerAngles.z);
                if (!coroutineStarted)
                    StartCoroutine(UsingYield(0.5f));
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
