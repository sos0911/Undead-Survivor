using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public        Player      GlobalPlayer;
    public        PoolManager Pool;

    void Awake()
    {
        Instance = this;
    }
}
