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
    

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var angle = Angle1(transform.position, _player.position);
        var quat = Quaternion.AngleAxis(angle - 90, Vector3.back);
        
        transform.rotation = quat;
    }
}
