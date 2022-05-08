using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public static int Score = 0;
    [SerializeField] float speed;
    [SerializeField] SoundManager soundManager;
    Rigidbody2D rb;

    [SerializeField] Animator animator;

    public GameObject bulletPrefab;
    public Transform FirePoint;
    private float timer = 0;
    public Transform up;

    private int Horizontal;
    private int Vertical;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1")) {
            if (timer > 0.3f)
            {

                timer = 0;
                Shoot();

            }
        }


        PlayerPrefs.SetInt("score", Score);
        if(Score > 4)
        {
            SceneManager.LoadScene("ScoreBoard");
        }




        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            animator.SetBool("IsRun", true);

            transform.localScale = new Vector3(horizontal > 0 ? 0.7f : -0.7f, 0.7f, 0.7f);
            
            transform.Translate(Vector2.right * horizontal * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsRun", false);
        }
        
    
    
    }

    /*private void FixedUpdate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.right).z;
        rb.angularVelocity = -rotateAmount * speed * Time.deltaTime;
    }*/


    void Shoot()
    {
        animator.SetTrigger("Attack");
        soundManager.PlaySound();

        Transform trans;
        if(GetComponent<SpriteRenderer>().flipX == false)
        {
            if (Vertical > 0)
            {
                trans = up;
            }
        }

        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation).GetComponent<BulletDir>().dir = transform.localScale.x * 1;
    }
     


}
