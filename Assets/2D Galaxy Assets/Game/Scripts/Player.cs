using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool tiroTriplo = false;
    public bool velocidadeUp = false;
    public bool escudoUp = false;
    private AudioSource powerUpAudio;

    [SerializeField]
    private Joystick _joystick;
    [SerializeField]
    private Button _Butao; 
    [SerializeField]
    private GameObject escudoGameObj;
    [SerializeField]
    private GameObject turbina;
    [SerializeField]
    private GameObject dano_motor;
    [SerializeField]
    private float Velocidade = 7f;
    [SerializeField]
    private GameObject Laser;
    [SerializeField]
    private float tempoAtirar = 0.13f;
    private float verifAtirar;
    [SerializeField]
    private int vidas = 3;
    [SerializeField]
    private GameObject explosao;

    private UIManager uimanagerObj;
    private GameManager gameManagr;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        powerUpAudio = GetComponent<AudioSource>();
        uimanagerObj = GameObject.Find("Canvas").GetComponent<UIManager>();
        gameManagr = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(gameManagr.Mobile == true)
        {
            _Butao = GameObject.FindWithTag("BotaoAtirar").GetComponent<Button>();
            _joystick = GameObject.FindWithTag("Joystick").GetComponent<Joystick>();
        }
        
        if(uimanagerObj != null)
        {
            uimanagerObj.UpdateVida(vidas);
        }
    }

    void Update()
    {
        Controlador();

        if(gameManagr.Mobile == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Atirar();
            }
        }
        else
        {
            _Butao.onClick.AddListener(Atirar);
        }
    }
    private void Controlador()
    {
        float eixoX;
        float eixoY;

        if (velocidadeUp == true)
        {
            Velocidade = 13f;
        }
        else
        {
            Velocidade = 7f;
        }

        if(gameManagr.Mobile == false)
        {
            eixoX = Velocidade * Input.GetAxis("Horizontal");
            eixoY = Velocidade * Input.GetAxis("Vertical");
        }
        else
        {
            eixoX = Velocidade * _joystick.Horizontal;
            eixoY = Velocidade * _joystick.Vertical;
        }
        
        transform.Translate(Vector3.right * eixoX * Time.deltaTime);
        transform.Translate(Vector3.up * eixoY * Time.deltaTime);

        //limite horizontal
        if (transform.position.x > 8.25f)
        {
            transform.position = new Vector3(8.25f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.25f)
        {
            transform.position = new Vector3(-8.25f, transform.position.y, 0);
        }

        //limite vertical
        if (transform.position.y > 4.25f)
        {
            transform.position = new Vector3(transform.position.x, 4.25f, 0);
        }
        else if (transform.position.y < -4.25f)
        {
            transform.position = new Vector3(transform.position.x, -4.25f, 0);
        }
    }
    public void Atirar()
    {
        if (Time.time > verifAtirar)
        {
            if (tiroTriplo == true)
            {
                Instantiate(Laser, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
                Instantiate(Laser, transform.position + new Vector3(0.55f, -0.45f, 0), transform.rotation);
                Instantiate(Laser, transform.position + new Vector3(-0.55f, -0.45f, 0), transform.rotation);
            }
            else
            {
                Instantiate(Laser, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
            }
            verifAtirar = Time.time + tempoAtirar;
        }
    }

    public void Dano()
    {
        if(escudoUp == true)
        {
            escudoUp = false;
            escudoGameObj.SetActive(false);
            return;
        }

        vidas--;
        uimanagerObj.UpdateVida(vidas);
        if (vidas < 1)
        {
            Instantiate(explosao, transform.position, transform.rotation);
            gameManagr.GameOver = true;
            Destroy(this.gameObject);
        }
        if (vidas == 1)
        {
            dano_motor.SetActive(true);
        }
    }
    public void escudoAtivar()
    {
        escudoUp = true;
        powerUpAudio.Play();
        escudoGameObj.SetActive(true);
    }

    public void LaserTriploAtivar()
    {
        tiroTriplo = true;
        powerUpAudio.Play();
        StartCoroutine(LaserTriploDesativar());
    }

    public void VelocidadeUP()
    {
        velocidadeUp = true;
        turbina.SetActive(true);
        powerUpAudio.Play();
        StartCoroutine(VelocidadeUPDesativar());
    }

    public IEnumerator LaserTriploDesativar()
    {
        yield return new WaitForSeconds(5);
        tiroTriplo = false;
    }

    public IEnumerator VelocidadeUPDesativar()
    {
        yield return new WaitForSeconds(5);
        turbina.SetActive(false);
        velocidadeUp = false;
    }
}