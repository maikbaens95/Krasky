using UnityEngine;
using System.Collections;

public class Smooth_camera_controller : MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private Transform player;

    // Update is called once per frame
    void Update()
    {
        Camera camera = GetComponent<Camera>();
        if (player)
        {
            Vector3 point = camera.WorldToViewportPoint(player.position);
            Vector3 delta = player.position - camera.ViewportToWorldPoint(new Vector3(0.5f, point.y, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}