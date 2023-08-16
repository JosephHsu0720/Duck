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

    public Vector3 moveH;           // 位移方向(水平)
    public Vector3 moveV;           // 位移方向(垂直)
    public Vector3 moveDir;         // 總位移方向
    public Vector3 offset;
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
        battleUnitData.SetBattleUnitData(playerData.playerInfo);

        BattleUnitController battleUnitController = GetComponent<BattleUnitController>();
        battleUnitController.SetUnitData(battleUnitData);
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

        moveH = new Vector3(moveHorizontal, 0f, 0f);
        moveV = new Vector3(0f, moveVertical, 0f);

        Ray rayH = new Ray(transform.localPosition + offset, moveH);
        Ray rayV = new Ray(transform.localPosition + offset, moveV);

        Debug.DrawRay(transform.localPosition + offset, moveH.normalized * debugRayLength, Color.red);
        Debug.DrawRay(transform.localPosition + offset, moveV.normalized * debugRayLength, Color.blue);

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

        moveDir = (moveH + moveV).normalized;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
}