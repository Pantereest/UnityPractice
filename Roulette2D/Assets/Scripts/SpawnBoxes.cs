using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class SpawnBoxes : MonoBehaviour
{
    [SerializeField]
    [Range(1, 100)]
    private int _commonChance = 0;
    private float _rareChance;
    private float _epicChance;
    private float _legenChance;
    [SerializeField]
    [Range(0, 100)]
    private int _boxCnt = 0;

    public bool startScroll = false;

    public GameObject[] Prefabs;
    public GameObject Sp;
    [SerializeField]
    public float _scrollSpeed = -20.0f;

    void Update()
    {
        if (startScroll)
        {
            Debug.Log("I work");
            _scrollSpeed = Mathf.MoveTowards(_scrollSpeed, 0, 85f * Time.deltaTime);
        }
    }
    public void ButtonClick()
    {
        Sp.SetActive(true);
        startScroll = true;
        BoxGenerate(_commonChance);
        Debug.Log(startScroll);
        Debug.Log("common" + _commonChance);
        Debug.Log("rare" + _rareChance);
        Debug.Log("epic" + _epicChance);
        Debug.Log("legen" + _legenChance);
    }
    void BoxGenerate(int comChance)
    {
        _rareChance = (100 - _commonChance) * 0.66f;
        _epicChance = _rareChance * 0.5f;
        _legenChance = _epicChance * 0.01f;

        int boxNum;
        for (int i = 0; i < _boxCnt; i++)
        {
            float randNum = Random.Range(0f, 100f);
            if (randNum <= _commonChance)
            {
                boxNum = 0;
            }
            else if (randNum >= _commonChance && randNum <= 100 - (_epicChance + _legenChance))
            {
                boxNum = 1;
            }
            else if (randNum >= 100 - (_epicChance + _legenChance) && randNum <= 100 - _legenChance)
            {
                boxNum = 2;
            }
            else
            {
                boxNum = 3;
            }

            print(randNum);
            print(boxNum);
            GameObject obj = Instantiate(Prefabs[boxNum], new Vector2(0, 0), Quaternion.identity) as GameObject;
            obj.transform.SetParent(Sp.transform);

        }
    }


}
