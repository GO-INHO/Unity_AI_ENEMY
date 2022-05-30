using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class Hero : MonoBehaviour
{
    public GameObject Prefab_enemy;
    // Start is called before the first frame update
    public GameObject childCamera;
    Vector3 HeroPos;
    float HeroRoll;
    float HeroPitch;
    float Done = 100.0f;
    public Text Time_text;
    public Text Humannum;
    public Text Zombienum;
    public Text WinLoss;
    public GameObject[] Human_array;
    public GameObject[] Zombie_array;

    private AudioSource audio;
    public AudioClip footSound;

    //Thread thread;
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.footSound;
        this.audio.loop = false;
        HeroRoll = 0;
        HeroPitch = 0;
        HeroPos = gameObject.transform.position;
        childCamera = GameObject.Find("MainCamera");
    }
    void Invoke_t()
    {
        SceneManager.LoadScene("MenuScene");
    }
    void Update()
    {
        if(Done > 0f)
        {
            Done -= Time.deltaTime;
            if(Done <= 0.0f ) Done = 0.0f;
            Time_text.text = "Time : " + Mathf.Floor(Done).ToString() + "sec";
        }
        else if (Done <= 0.0f)
        {
            WinLoss.text = "Defeat";
            Invoke("Invoke_t", 2f);
        }
        Human_array = GameObject.FindGameObjectsWithTag("Human");
        Zombie_array = GameObject.FindGameObjectsWithTag("Zombie");
        if(Human_array.Length == 0)
        {
            WinLoss.text = "WIN";
            Invoke("Invoke_t", 2f);
        }
        
        Humannum.text = "Human : " +(Human_array.Length).ToString();
        Zombienum.text = "Zombie : " + (Zombie_array.Length).ToString();
        Vector3 dir = childCamera.transform.rotation * Vector3.forward;
        transform.rotation = childCamera.transform.rotation;
        float Speed = 8.00f;
        
        if (Input.GetKey(KeyCode.A))  
        {
            gameObject.transform.Translate(Vector3.left* Speed * Time.deltaTime);
            //gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
            //HeroPos += new Vector3(0-Speed, 0, 0);
            this.audio.Play();
        }
        if (Input.GetKeyUp(KeyCode.A))  
        {
            this.audio.Stop();
        }
        if (Input.GetKey(KeyCode.D))   
        {
            gameObject.transform.Translate(Vector3.right* Speed * Time.deltaTime);
            //HeroPos += new Vector3(0+Speed, 0, 0);
            this.audio.Play();
        }
        if (Input.GetKeyUp(KeyCode.D))  
        {
            this.audio.Stop();
        }
        if (Input.GetKey(KeyCode.W)) 
        {
            gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
           //HeroPos += new Vector3(0, 0, 0+Speed);
           this.audio.Play();
        }
        if (Input.GetKeyUp(KeyCode.W))  
        {
            this.audio.Stop();
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            gameObject.transform.Translate(Vector3.back * Speed * Time.deltaTime);
           // HeroPos += new Vector3(0, 0 , 0- Speed);
           this.audio.Play();
        }
        if (Input.GetKeyUp(KeyCode.S))  
        {
            this.audio.Stop();
        }
        
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
 
        //gameObject.transform.position = HeroPos;
    

    }
    void OnTriggerEnter(Collider col)
    {
        
    }

}