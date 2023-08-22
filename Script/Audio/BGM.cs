using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BGM�̏���
/// </summary>
public class BGM : MonoBehaviour
{
    private static BGM instance;

    // BGM���p�����ė���
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
