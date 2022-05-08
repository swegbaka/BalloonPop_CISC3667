using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSce : MonoBehaviour
{

    private int nextSceneToLoad;
    
    // Start is called before the first frame update
    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
        else if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "TopWall")
        {
            Destroy(collision.gameObject);
        }

    }
}
