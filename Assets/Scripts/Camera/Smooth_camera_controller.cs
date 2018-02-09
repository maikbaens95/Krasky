using UnityEngine;
using System.Collections;

public class Smooth_camera_controller : MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private Transform player;
    private float y_floor1;
    private float y_floor2;
    private float y_floor3;
    private float y_floor4;
    private float y_floor5;
    private float y_player_actual;

    private void Start()
    {
        y_floor1 = 0.0f;
        y_floor2 = -10.3f;
        y_floor3 = -20.6f;
        y_floor4 = -30.9f;
        y_floor5 = -41.2f;
    }
    // Update is called once per frame
    void Update()
    {
        y_player_actual = player.transform.position.y;
        if (y_player_actual > -4.0f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), ref velocity, dampTime);
            transform.position = new Vector3(transform.position.x, y_floor1, transform.position.z);
        }
        else if (y_player_actual < -4.0f && y_player_actual > -10.1)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x, y_player_actual, transform.position.z), ref velocity, dampTime);
        }
        else if (y_player_actual < -10.1 && y_player_actual > -14.6)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), ref velocity, dampTime);
            transform.position = new Vector3(transform.position.x, y_floor2, transform.position.z);
        }
        else if (y_player_actual < -14.6f && y_player_actual > -20.6)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x, y_player_actual, transform.position.z), ref velocity, dampTime);
        }
        else if (y_player_actual < -20.6)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), ref velocity, dampTime);
            transform.position = new Vector3(transform.position.x, y_floor3, transform.position.z);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), ref velocity, dampTime);
        }

    }
}