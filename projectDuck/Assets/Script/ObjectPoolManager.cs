using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private Dictionary<string, Stack<GameObject>> pool = new Dictionary<string, Stack<GameObject>>();
    public Transform poolRoot;
    public Transform player;

    public int spawnTime;

    public GameObject Spawn(string tag)
    {
        GameObject obj;

        // 如果該物件已被登錄且該池子裡還有剩餘
        if (pool.TryGetValue(tag, out Stack<GameObject> stack) && stack.Count > 0)
        {
            obj = stack.Pop();
            obj.SetActive(true);
            return obj;
        }

        // 沒有的話直接生成新的 在 Despawn 登錄
        obj = Resources.Load<GameObject>(tag);
        if (obj == null)
        {
            Debug.LogError($"Cannot find object tag: {tag}");
            return null;
        }
        obj = GameObject.Instantiate(obj, poolRoot);

        PoolObject poolObject = obj.GetComponent<PoolObject>();
        poolObject.objectTag = tag;
        poolObject.followTarget = player;
        poolObject.RecycleEvent += Despawn;

        return obj;
    }

    public void Despawn(GameObject obj)
    {
        obj.SetActive(false);

        string tag = obj.GetComponent<PoolObject>().objectTag;

        // 如果該物件未被登錄 -> 登陸該物件並新增該物件群
        if (!pool.TryGetValue(tag, out Stack<GameObject> stack))
        {
            stack = new Stack<GameObject>();
            pool.Add(tag, stack);
        }

        if (stack.Contains(obj)) { return; }

        // 有的話就放回去
        stack.Push(obj);
    }
}
