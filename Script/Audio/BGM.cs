using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BGM‚Ìˆ—
/// </summary>
public class BGM : MonoBehaviour
{
    private static BGM instance;

    // BGM‚ğŒp‘±‚µ‚Ä—¬‚·
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
