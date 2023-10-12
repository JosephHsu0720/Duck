using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    public static BulletTypeDictionary bulletDictionary;
    public UnitDataList enemyData;

    private Dictionary<string, Stack<GameObject>> pool = new Dictionary<string, Stack<GameObject>>();
    public Transform player;

    public int spawnTime;

    private void Start()
    {
        instance = this;
    }

    public GameObject Spawn(string name)
    {
        GameObject obj;

        // 如果該物件已被登錄且該池子裡還有剩餘
        if (pool.TryGetValue(name, out Stack<GameObject> stack) && stack.Count > 0)
        {
            obj = stack.Pop();
            obj.SetActive(true);
            return obj;
        }

        // 沒有的話直接生成新的 在 Despawn 登錄
        obj = Resources.Load<GameObject>(name);
        if (obj == null)
        {
            Debug.LogError($"Cannot find object tag: {name}");
            return null;
        }
        obj = GameObject.Instantiate(obj);

        PoolObject poolObject = obj.GetComponent<PoolObject>();

        Data objectData = enemyData.dataList.Find(x => x.name == name);
        poolObject.SetUp(name, objectData, player, Despawn);

        return obj;
    }

    public void Despawn(GameObject obj)
    {
        obj.SetActive(false);

        string name = obj.GetComponent<PoolObject>().objectName;

        // 如果該物件未被登錄 -> 登陸該物件並新增該物件群
        if (!pool.TryGetValue(name, out Stack<GameObject> stack))
        {
            stack = new Stack<GameObject>();
            pool.Add(name, stack);
        }

        if (stack.Contains(obj)) { return; }

        // 有的話就放回去
        stack.Push(obj);
    }
}
