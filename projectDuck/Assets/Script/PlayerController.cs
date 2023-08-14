using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public class PlayerData
    {
        public enum PlayerStatus
        {
            Idle = 0,
            Move = 1,
            Action = 2
        }
    }

    public Vector3 moveH;           // 位移方向(水平)
    public Vector3 moveV;           // 位移方向(垂直)
    public float moveSpeed;         // 位移速度
    [SerializeField] float moveVertical = 0;
    [SerializeField] float moveHorizontal = 0;

    [Header("Debug RayLine")]
    public int debugRayLength;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 垂直移動
        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 0.1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -0.1f;
        }
        else
        {
            moveVertical = 0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -0.1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 0.1f;
        }
        else
        {
            moveHorizontal = 0f;
        }
        moveH = new Vector3(moveHorizontal, 0f, 0f);
        moveV = new Vector3(0f, moveVertical, 0f);

        Ray rayH = new Ray(transform.localPosition, moveH);
        Ray rayV = new Ray(transform.localPosition, moveV);

        Debug.DrawRay(transform.localPosition, moveH.normalized * debugRayLength, Color.red);
        Debug.DrawRay(transform.localPosition, moveV.normalized * debugRayLength, Color.blue);

        if (Physics.Raycast(rayH, out RaycastHit hitH, 1))
        {
            Debug.Log(hitH.collider.name + hitH.distance.ToString());
            moveH = Vector3.zero;
        }
        if (Physics.Raycast(rayV, out RaycastHit hitV, 1))
        {
            Debug.Log(hitV.collider.name + hitV.distance.ToString());
            moveV = Vector3.zero;
        }

        Vector3 moveDir = (moveH + moveV).normalized;
        transform.localPosition += moveDir * moveSpeed * Time.deltaTime;
    }
}
