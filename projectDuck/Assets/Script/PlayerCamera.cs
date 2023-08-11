using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform targetPlayer;
    public float speed = 8f;

    Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    private void LateUpdate()
    {
        if (targetPlayer != null)
        {
            Vector3 dir = new Vector3(targetPlayer.position.x, targetPlayer.position.y, _transform.position.z) - _transform.position;
            if (dir.magnitude > 0.001f)
            {
                _transform.position = Vector3.Slerp(_transform.position, new Vector3(targetPlayer.position.x, targetPlayer.position.y, _transform.position.z), Mathf.Clamp01(speed * Time.deltaTime));
            }
        }
    }
}
