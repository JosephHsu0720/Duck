using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Dictionary<string, bool> moveDirection = new Dictionary<string, bool>();

    public float moveDelta;     // 位移量
    public float moveSpeed;     // 位移速度

    [SerializeField] float moveVertical = 0;
    [SerializeField] float moveHorizontal = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*moveDirection.Add("up", false);
        moveDirection.Add("down", false);
        moveDirection.Add("left", false);
        moveDirection.Add("right", false);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            /*if (moveDirection.TryGetValue("down", out bool down) == true)
            {
                moveDirection["down"] = false;
                moveVector = new Vector3(0f, moveDelta, 0f);
            }*/
            moveVertical = 0.1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            /*if (moveDirection.TryGetValue("up", out bool down) == true)
            {
                moveDirection["up"] = false;
                moveVector = new Vector3(0f, -moveDelta, 0f);
            }*/
            moveVertical = -0.1f;
        }
        else
        {
            moveVertical = 0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //moveVector = new Vector3(-moveDelta, 0f, 0f);
            moveHorizontal = -0.1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //moveVector = new Vector3(moveDelta, 0f, 0f);
            moveHorizontal = 0.1f;
        }
        else
        {
            moveHorizontal = 0f;
        }

        Vector3 moveVector = new Vector3(moveHorizontal, moveVertical, 0f);
        transform.localPosition += moveVector.normalized * moveSpeed * Time.deltaTime;
    }
}
