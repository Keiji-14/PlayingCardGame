using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BGMの処理
/// </summary>
public class BGM : MonoBehaviour
{
    private static BGM instance;

    // BGMを継続して流す
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
