using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text score;

    private int scoreValue = 0;

    public Text winText;

    public Text LivesText;

    private int Lives;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    private float timer;


    public AudioClip musicClipTwo;

    public AudioClip musicClipFour;

    public AudioSource musicsource2;

    public AudioSource musicSource;

    public AudioSource musicSource3;

    Animator anim;

    private bool facingRight = true;
    private bool isJumping = false;
    private bool bombr = false;
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        winText.text = "";
        Lives = 3;
        LivesText.text = "";
        setLivesText();
        anim = GetComponent<Animator>();
        timer = 0;
    }

  

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && isJumping == false)
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.A) && isJumping == false)
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKey(KeyCode.D) && isJumping == false)
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.D) && isJumping == false)
        {
            anim.SetInteger("State", 0);
        }

        if(bombr ==true)
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                GetComponent<AudioSource>().Play();
            }

            timer = timer + 1;
            if (timer == 400)
            {
                bombr = false;
                timer = 0;
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
               
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            SetCountText();
        }
        else if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            Lives = Lives - 1;
            setLivesText();
        }

        if (collision.collider.tag == "bomb")
        {
            Destroy(collision.collider.gameObject);
            bombr = true;
          
        }

        if (collision.collider.tag == "speed")
        {
            Destroy(collision.collider.gameObject);
            speed = speed + 2;
            

        }
    }
    


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))

            {
                isJumping = true;
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
                anim.SetInteger("State", 2);
                musicSource.clip = musicClipFour;
                musicSource.Play();
                musicSource.loop = false;

            }
            else 
            {
                isJumping = false;
                anim.SetInteger("State", 0);

            }
        }
    }
    void SetCountText()
    {
        if (scoreValue == 4)
        {
            transform.position = new Vector2(-6.5f, -41.06f);
            Lives = 3;
            LivesText.text = "";
            setLivesText();
        }
        if (scoreValue == 8)
        {
           
            musicSource3.Stop();
            musicSource.loop = true;
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            winText.text = "You win! Made by Ricardo Gonzalez";
        }
    }
    void setLivesText()
    {
        LivesText.text = "Lives: " + Lives.ToString();
        if (Lives == 0)
        {
            winText.text = "You Lose! Try again";
            Destroy(gameObject);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
}  
