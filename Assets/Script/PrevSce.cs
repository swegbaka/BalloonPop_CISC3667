using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrevSce : MonoBehaviour
{

    private int prevSceneToLoad;

    // Start is called before the first frame update
    private void Start()
    {
        prevSceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(prevSceneToLoad);
        }else if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
        }


        if (collision.gameObject.tag == "TopWall")
        {
            Destroy(collision.gameObject);
        }
    }
}
