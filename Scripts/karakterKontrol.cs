using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterKontrol : MonoBehaviour
{
    Rigidbody rigi;

    float kosma = 3.5f;
    bool sag;
    bool sol;
    Transform yol1;
    Transform yol2;
    OyunKontrol Kontrol;
    public GameObject oyunBitti;
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        yol1 = GameObject.Find("yol1").transform;
        yol2 = GameObject.Find("yol2").transform;

        Kontrol = GameObject.Find("OyunKontrol").GetComponent < OyunKontrol > ();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "yol1")
        {
            yol2.position = new Vector3(yol2.position.x, yol2.position.y, yol1.position.z + 10.0f);
        }

        if (other.gameObject.name == "yol2")
        {
            yol1.position = new Vector3(yol1.position.x, yol1.position.y, yol2.position.z + 10.0f);
        }
        if (other.gameObject.tag == "altin")
        {
            other.gameObject.SetActive(false);
            Kontrol.puanArttir(10);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);

            if (parmak.deltaPosition.x > 50.0f)
            {
                sag = true;
                sol = false;
            }
            if (parmak.deltaPosition.x < -50.0f)
            {
                sag = false;
                sol = true;
            }
        }
        if (sag == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(2.40f, transform.position.y, transform.position.z), kosma * Time.deltaTime);
        }
        if (sol == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-2.51f, transform.position.y, transform.position.z), kosma * Time.deltaTime);
        }
        transform.Translate(0, 0, kosma * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "engel")
        {
            oyunBitti.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
