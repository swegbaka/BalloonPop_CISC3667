using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDir : MonoBehaviour
{
    public float dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * 3 * Time.deltaTime * (dir > 0 ? 1 : -1));
    }
}
