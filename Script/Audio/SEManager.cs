using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SEを管理する処理
/// </summary>
public class SEManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    // SEを管理
    public enum SE_Type
    {
        turnSE,
    }
}
