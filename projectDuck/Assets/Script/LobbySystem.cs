using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySystem : MonoBehaviour
{
    static public UIManager uIManager;

    private void Awake()
    {
        uIManager = UIManager.GetInstance();
    }
}
