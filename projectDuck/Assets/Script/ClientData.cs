using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientData
{
    /* Singleton */
    static ClientData _ins;
    public static ClientData instance
    {
        get
        {
            if (_ins == null)
            {
                _ins = new ClientData();
            }
            return _ins;
        }
    }
}

public enum GameUI
{
    CharaProfilePage,
    GachaPage,
    Settings,
    LoadingPage
}
