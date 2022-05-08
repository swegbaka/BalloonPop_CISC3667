using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] Vector3 force;
    [SerializeField] Sprite[] balloonSprites;

    public float Range1;
    public float Range2;


    private UIManager UIMgr;


    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        UIMgr = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        
        
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = balloonSprites[Random.Range(0, 5)];

        transform.position = new Vector3(Random.Range(-9.4f, 9.4f),transform.position.y, transform.position.z);
        
        force = new Vector3(Random.Range(-100, 100), Random.Range(Range1, Range2), 0);

        rb.AddForce(force);
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TopWall")
        {
            Destroy(this.gameObject);
        }else if (collision.gameObject.tag == "bullet")
        {
            UIMgr.AddScore();
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
    


}
