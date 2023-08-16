using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float speed = 8f;

    Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 dir = new Vector3(target.position.x, target.position.y, _transform.position.z) - _transform.position;
            if (dir.magnitude > 0.001f)
            {
                _transform.position = Vector3.Slerp(_transform.position, new Vector3(target.position.x, target.position.y, _transform.position.z), Mathf.Clamp01(speed * Time.deltaTime));
            }

            Vector3 moveDir = Player.instance.moveDir;
            if (target.gameObject.layer == 3)
            {
                float angle = Vector3.Angle(Vector3.right, moveDir);
                if (moveDir.y < 0) angle *= -1;

                // Vector3.Angle -> 大於180度(含) 會轉成負數，數字表現範圍：±0-180
                target.localRotation = Quaternion.Euler(0f, 0f, angle + 90);
            }
        }
    }
}
