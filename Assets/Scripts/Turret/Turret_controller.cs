using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_controller : MonoBehaviour {


    public static float Angle1(Vector3 source, Vector3 destination)
    {
        Vector3 dir = destination - source;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        return angle;
    }


    [SerializeField]
    private Transform _player;
    private Weapon_turret weapon_script;
    [SerializeField]
    private GameObject smoke;
    private ParticleSystem _ps;

    private bool not_enter;


    // Use this for initialization
    void Start()
    {
        _ps = smoke.GetComponent<ParticleSystem>();
        weapon_script = GetComponent<Weapon_turret>();
        not_enter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!not_enter)
        {
            if (weapon_script.getAlive())
            {
                var angle = Angle1(transform.position, _player.position);
                var quat = Quaternion.AngleAxis(angle - 90, Vector3.back);
                transform.rotation = quat;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, -45);
                _ps.Play();
            }
        }
    }
}
