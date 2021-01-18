using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float _yOffset;
    
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y + _yOffset, transform.position.z);
    }
}
