using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D RB;

    public SpriteRenderer SR;

    private float speed = 5f;

    private float mx;

    private float my;

    private float fireTimer;

    private Vector2 mousePos;

    public AudioClip FirePistol;
    public AudioClip TakingDamage;
    public AudioSource AS;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 2f)]
    [SerializeField] private float fireRate = 0.5f;

    [SerializeField] float health, maxHealth = 3f;

    //public int Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
        else 
        {
            fireTimer -= Time.deltaTime;
        }

        //Make a variable of the type
        Vector2 vel = new Vector2(0, 0);

        //Figure out what value you want
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = 5;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            vel.x = -5;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            vel.y = 5;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vel.y = -5;
        }

        //Plug it into the component
        RB.velocity = vel;
    }

    private void FixedUpdate()
    {
        RB.velocity = new Vector2(mx, my).normalized * speed;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        AS.PlayOneShot(FirePistol);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Defeat");

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage(1);
        AS.PlayOneShot(TakingDamage);
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //  Score++;
    //Destroy(other.gameObject);
    //}
}
