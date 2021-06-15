using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{

    public SpawnBoxes SpawnB;
    void Update()
    {
        gameObject.transform.Translate(new Vector2(SpawnB._scrollSpeed,0) * Time.deltaTime);
    }
}
