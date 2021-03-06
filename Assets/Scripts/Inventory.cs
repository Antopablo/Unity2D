﻿using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public Text mCoinsCountText;

    public int mCoinsCount;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'Inventory dans la scène.");
            return;
        }
        instance = this;
    }

    public void AddCoin(int count)
    {
        mCoinsCount += count;
        mCoinsCountText.text = mCoinsCount.ToString();

    }

}
