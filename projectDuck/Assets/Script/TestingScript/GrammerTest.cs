using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test
{
    private int input;
    public int Output
    {
        get
        {
            if (input <= 0) return -1;
            return input;
        }
        set
        {
            if (value > 69) value = 69;
            input = value;
        }
    }
}

[RequireComponent(typeof(EffectivenessTest))]
public class GrammerTest : MonoBehaviour
{
    public int testInput;
    Test newTest = new Test();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {            
            newTest.Output = testInput;

            Debug.Log($"newTest.Output = {newTest.Output}");
        }
    }
}
