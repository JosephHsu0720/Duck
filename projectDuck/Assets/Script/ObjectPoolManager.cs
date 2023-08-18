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

        // �p�G�Ӫ���w�Q�n���B�Ӧ��l���٦��Ѿl
        if (pool.TryGetValue(tag, out Stack<GameObject> stack) && stack.Count > 0)
        {
            obj = stack.Pop();
            obj.SetActive(true);
            return obj;
        }

        // �S�����ܪ����ͦ��s�� �b Despawn �n��
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

        // �p�G�Ӫ��󥼳Q�n�� -> �n���Ӫ���÷s�W�Ӫ���s
        if (!pool.TryGetValue(tag, out Stack<GameObject> stack))
        {
            stack = new Stack<GameObject>();
            pool.Add(tag, stack);
        }

        if (stack.Contains(obj)) { return; }

        // �����ܴN��^�h
        stack.Push(obj);
    }
}
