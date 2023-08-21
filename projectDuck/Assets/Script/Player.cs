using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public class PlayerData
    {
        public enum PlayerStatus
        {
            Idle = 0,
            Move = 1,
            Action = 2
        }

        public int id;
        public string name;

        public int level;
        public int atk;
        public int def;
        public int hp;
    }

    public Vector2 moveH;           // 位移方向(水平)
    public Vector2 moveV;           // 位移方向(垂直)
    public Vector2 moveDir;         // 總位移方向
    public Vector3 offset;          // 偏移量
    public float moveSpeed;         // 位移速度
    [SerializeField] float moveVertical = 0;
    [SerializeField] float moveHorizontal = 0;

    [Header("Debug RayLine")]
    public int debugRayLength;

    public static Player instance;
    static public UnitData playerData;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        SetPlayerData();
    }

    public void SetPlayerData()
    {
        playerData = AssetDatabase.LoadAssetAtPath<UnitData>("Assets/Data/PlayerData.asset");
        if (playerData == null)
        {
            Debug.LogError("no playerData exists");
        }

        BattleUnitData battleUnitData = new BattleUnitData();
        battleUnitData.SetPlayerData(playerData.playerInfo);

        BattleUnitController battleUnitController = GetComponent<BattleUnitController>();
        battleUnitController.SetUnitData(battleUnitData);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // 垂直移動
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
        // 水平移動
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

        /*moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");*/

        moveH = new Vector2(moveHorizontal, 0f);
        moveV = new Vector2(0f, moveVertical);

        // Raycast
        //RaycastHit2D hit2D_H = Physics2D.Raycast(transform.position, moveH.normalized);
        //RaycastHit2D hit2D_V = Physics2D.Raycast(transform.position, moveV.normalized);

        // CircleCast
        RaycastHit2D circleHit2D = Physics2D.CircleCast(transform.position, 1f, moveH.normalized);
        Physics2D.IgnoreLayerCollision(6, 6);

        //Debug.DrawRay(transform.localPosition + offset, moveH.normalized * debugRayLength, Color.red);
        //Debug.DrawRay(transform.localPosition + offset, moveV.normalized * debugRayLength, Color.blue);

        if (circleHit2D)
        {
            Debug.Log(circleHit2D.collider.name);
        }

        /*
        if (hit2D_H)
        {
            Debug.Log(hit2D_H.collider.name);
            //moveH = Vector2.zero;
        }
        if (hit2D_V)
        {
            Debug.Log(hit2D_V.collider.name);
            //moveV = Vector2.zero;
        }*/

        moveDir = (moveH + moveV).normalized;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
}
