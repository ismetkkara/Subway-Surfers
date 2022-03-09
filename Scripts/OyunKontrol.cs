using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public TMPro.TextMeshProUGUI puanText;
    public GameObject altin;
    public GameObject engel;
    List<GameObject> altinlar;
    List<GameObject> engeller;
    Transform cocuk;
    int puan = 0;
    void Start()
    {
        altinlar = new List<GameObject>();
        engeller = new List<GameObject>();
        cocuk = GameObject.Find("cocuk").transform;
        uretme(altin, 10, altinlar);
        uretme(engel, 10, engeller);
        InvokeRepeating("altinUret", 0.0f, 1.0f);
        InvokeRepeating("engelUret", 2.0f, 3.0f);
        puanText.text = "SKOR"+puan.ToString();
    }
    public void puanArttir(int deger)
    {
        puan += deger;
        puanText.text = "SKOR"+puan.ToString();

    }
    void engelUret()
    {
        int rast = Random.Range(0, engeller.Count);
        if (engeller[rast].activeSelf == false)
        {

            engeller[rast].SetActive(true);
           int rastgele = Random.Range(0, 2);
            if (rastgele == 0)
            {
                engeller[rast].transform.position = new Vector3(-0.954f, 0.51f, cocuk.position.z + 10.0f);
            }
            if (rastgele == 1)
            {
                engeller[rast].transform.position = new Vector3(1f, 0.51f, cocuk.position.z + 10.0f);
            }

        }
        else
        {
            foreach (GameObject nesne in engeller)
            {
                if (nesne.activeSelf == false)
                {
                    nesne.SetActive(true);
                    int rastgele2 = Random.Range(0, 2);
                    if (rastgele2 == 0)
                    {
                        nesne.transform.position = new Vector3(-0.954f, 0.51f, cocuk.position.z + 10.0f);
                    }
                    if (rastgele2 == 1)
                    {
                        nesne.transform.position = new Vector3(1f, 0.51f, cocuk.position.z + 10.0f);
                   }

                    return;
                }

            }
        }
    }
    public void tekrarOyna()
    {

        SceneManager.LoadScene("Scenes/oyun");
        Time.timeScale = 1.0f;
    }
    public void oyundanCik()
    {
        Application.Quit();


    }
    void altinUret()
    {
        foreach (GameObject altin in altinlar)
        {
            if (altin.activeSelf == false)
            {
                altin.SetActive(true);
                int rastgele = Random.Range(0, 2);
                if (rastgele == 0)
                {
                    altin.transform.position = new Vector3(-0.954f, 0.51f, cocuk.position.z + 10.0f);
                }
                if (rastgele == 1)
                {
                    altin.transform.position = new Vector3(1f, 0.51f, cocuk.position.z + 10.0f);
                }
                return;
            }
        }
    }
    void uretme(GameObject nesne, int miktar, List<GameObject> liste)
    {
        for (int i = 0; i < miktar; i++)
        {
            GameObject yeniNesne = Instantiate(nesne);
            yeniNesne.SetActive(false);
            liste.Add(yeniNesne);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
