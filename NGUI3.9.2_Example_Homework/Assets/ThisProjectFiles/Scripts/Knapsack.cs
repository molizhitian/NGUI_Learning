﻿using UnityEngine;
using System.Collections;

public class Knapsack : MonoBehaviour {

    public GameObject[] cells;

    public string[] equipmentsName;

    public GameObject item;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PickUp();
        }
    }


    public void PickUp()
    {
        int index = Random.Range(0, equipmentsName.Length);
        string name = equipmentsName[index];

        bool isFind = false;
        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i].transform.childCount > 0)
            {
                //当前格子有物品
                MyDragDropItem item = cells[i].GetComponentInChildren<MyDragDropItem>();
                //判断当前游戏物体的名字 跟我们捡到的游戏物体名字是否一样
                if (item.sprite.spriteName == name)
                {
                    isFind = true;
                    item.AddCount(1);
                    break;
                }
            }
        }

        if (!isFind)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].transform.childCount == 0)
                {
                    //当前位置没有物品  
                    //添加我们新捡起来的物品
                    GameObject go = NGUITools.AddChild(cells[i], item);
                    go.GetComponent<UISprite>().spriteName = name;
                    go.transform.localPosition = Vector3.zero;
                    break;
                }
            }
        }

    }

}
