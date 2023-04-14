using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameLimitManager : MonoBehaviour
{
    [SerializeField] int frameRate;
    void Start()
    {
        Application.targetFrameRate = frameRate;
    }
}
