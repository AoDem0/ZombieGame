using System.Numerics;
using UnityEngine;

public class canvaRotation : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        UnityEngine.Vector3 direction = player.position - transform.position ;
        //direction.y += 180;
        direction.y = 0f; // Ignoruj różnicę wysokości
        if (direction != UnityEngine.Vector3.zero)
        {
            transform.rotation = UnityEngine.Quaternion.LookRotation(direction);
        }
    }

}
