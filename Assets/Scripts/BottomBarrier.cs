using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBarrier : MonoBehaviour
{
    [SerializeField] private float _barrierOffset;

    private void OnEnable()
    {
        PlayerController.OnVelocityChanged += ChangePosition;
    }

    private void OnDisable()
    {
        PlayerController.OnVelocityChanged -= ChangePosition;
    }

    private void ChangePosition(Vector2 playerPos)
    {
        if(transform.position.y < playerPos.y + _barrierOffset)
            transform.position = new Vector3(transform.position.x, playerPos.y + _barrierOffset, transform.position.z);
    }
}
