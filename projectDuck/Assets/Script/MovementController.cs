using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Transform controlTarget;

    public Vector2 moveH;           // �첾��V(����)
    public Vector2 moveV;           // �첾��V(����)
    public Vector2 moveDir;         // �`�첾��V
    public Vector3 offset;          // �����q
    public float moveSpeed;         // �첾�t��
    [SerializeField] float moveVertical = 0;
    [SerializeField] float moveHorizontal = 0;

    bool canMove = true;
    bool isDash = false;

    [Header("Debug RayLine")]
    public int debugRayLength;

    private void Update()
    {
        if (canMove)
        {
            // ��������
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                moveVertical = 0.1f;
            }
            else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                moveVertical = -0.1f;
            }
            else
            {
                moveVertical = 0f;
            }
            // ��������
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                moveHorizontal = -0.1f;
            }
            else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                moveHorizontal = 0.1f;
            }
            else
            {
                moveHorizontal = 0f;
            }
            // �Ĩ�(Dash)
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                if (!isDash)
                {
                    isDash = true;
                    canMove = false;
                    StartCoroutine(Dash(moveSpeed, moveSpeed * 5));
                }
            }
        }

        /*moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");*/

        moveH = new Vector2(moveHorizontal, 0f);
        moveV = new Vector2(0f, moveVertical);

        // Raycast
        //RaycastHit2D hit2D_H = Physics2D.Raycast(transform.position, moveH.normalized);
        //RaycastHit2D hit2D_V = Physics2D.Raycast(transform.position, moveV.normalized);

        //Debug.DrawRay(transform.localPosition + offset, moveH.normalized * debugRayLength, Color.red);
        //Debug.DrawRay(transform.localPosition + offset, moveV.normalized * debugRayLength, Color.blue);

        // CircleCast
        //RaycastHit2D circleHit2D = Physics2D.CircleCast(transform.position, 0.45f, Vector2.zero);
        //if (circleHit2D && circleHit2D.collider.tag == "Enemy")
        //{
        //    Debug.Log(circleHit2D.collider.name);
        //}

        moveDir = (moveH + moveV).normalized;
        controlTarget.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    IEnumerator Dash(float oldSpeed, float newSpeed)
    {
        moveSpeed = newSpeed;
        yield return new WaitForSecondsRealtime(0.2f);
        moveSpeed = oldSpeed;

        isDash = false;
        canMove = true;
    }
}
