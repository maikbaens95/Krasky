using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_weapon : MonoBehaviour
{

    public static float Angle(Vector3 source, Vector3 destination)
    {
        Vector3 dir = destination - source;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        return angle;
    }

    [SerializeField]
    private Transform _mirilla;
    private Character_movement Script_character_movement;
    private bool ceiling;
    private bool left;

    // Use this for initialization
    void Start()
    {
        Script_character_movement = GameObject.Find("robot").GetComponent<Character_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        ceiling = Script_character_movement.getwalking_terrain();
        left = Script_character_movement.getwalking_direction();

        var angle = Angle(transform.position, _mirilla.position);
        var quat = Quaternion.AngleAxis(angle - 90, Vector3.back);
        
        if ((left && !ceiling) || (!left && ceiling))
        {
            quat = Quaternion.AngleAxis(angle + 90, Vector3.back);
        }

        transform.rotation = quat;
    }

}
