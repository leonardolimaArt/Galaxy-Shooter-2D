using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pontuacao;
    private int pontInt;
    public Image vidaDisplay;
    public Sprite[] vidas;
    public GameObject MenuImg;
    public void UpdateVida(int vidaPlayer)
    {
        vidaDisplay.sprite = vidas[vidaPlayer];
    }

    public void UpdateScore()
    {
        pontInt += 1;
        pontuacao.text = "Pontuação: " + pontInt;
    }
    public void EsconderUI()
    {
        MenuImg.SetActive(false);
        pontInt = 0;
        pontuacao.text = "Pontuação: " + pontInt;
    }
    public void MostrarUI()
    {
        MenuImg.SetActive(true);
    }
}
