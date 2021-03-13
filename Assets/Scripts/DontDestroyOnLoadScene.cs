using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{

    public GameObject[] pObjects;

    void Awake()
    {
        foreach (var element in pObjects)
        {
            DontDestroyOnLoad(element);
        }
    }

}
