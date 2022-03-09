using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraTakip : MonoBehaviour
{
    Transform cocukPosizyon;
    Vector3 mesafe;
    float hiz = 10f;
    void Start()
    {
        cocukPosizyon = GameObject.Find("cocuk").transform;
    }

 
    void LateUpdate()
    {
        mesafe = new Vector3(cocukPosizyon.position.x, transform.position.y, cocukPosizyon.position.z - 7f);
        transform.position = Vector3.Lerp(transform.position, mesafe, hiz * Time.deltaTime);
    }
}
