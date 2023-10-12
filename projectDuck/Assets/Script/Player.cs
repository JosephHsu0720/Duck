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

    public static Player instance;
    public MovementController moveController;
    static public UnitData playerData;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        SetPlayerData();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag == "Enemy")
    //    {
    //        Debug.Log(collision.collider.name);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BattleUnitController unitController = GetComponent<BattleUnitController>();

        if (collision.tag == "Enemy")
        {
            Debug.Log(collision.name);
            unitController.AddHP(-15);
        }
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
        if (battleUnitController != null) battleUnitController.SetUnitData(battleUnitData);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.45f);
    }
}
