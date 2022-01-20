using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameOver = true;
    public bool Mobile = false;
    public GameObject player;
    public GameObject spawnMang;
    public GameObject Bottoes;
    private UIManager UImenu;

    void Start()
    {
        UImenu = GameObject.Find("Canvas").GetComponent<UIManager>();

    }
    void Update()
    {
        if(GameOver == true)
        {
            
            if(Mobile == true)
            {
                Bottoes.SetActive(false);
            }
            UImenu.MostrarUI();
            spawnMang.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                EnableGame();
            }
        }
    }
    public void EnableGame()
    {
        if (GameOver == true)
        {
            GameObject[] objectPower = GameObject.FindGameObjectsWithTag("PowerUp");
            foreach (GameObject powersUPOBJ in objectPower)
            {
                Destroy(powersUPOBJ);
            }
            GameObject[] objectInim = GameObject.FindGameObjectsWithTag("Inimigo");
            foreach (GameObject inimiUPOBJ in objectInim)
            {
                Destroy(inimiUPOBJ);
            }

            if (Mobile == true)
            {
                Bottoes.SetActive(true);
            }
            Instantiate(player, Vector3.zero, Quaternion.identity);
            spawnMang.SetActive(true);
            GameOver = false;
            UImenu.EsconderUI();
        }
    }
}
