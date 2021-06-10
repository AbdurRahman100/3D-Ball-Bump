using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject sceneManager;
    public float PlayerSpeed = 1500;
    public float DirectionalSpeed=0;
    public AudioClip scoreUP;
    public AudioClip Damage;

    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(500f, 0f, 0f) * Time.deltaTime);

#if UNITY_EDITOR|| UNITY_STANDALONE||UNITY_WEBPLAYER
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3 (Mathf.Clamp(gameObject.transform.position.x + moveHorizontal, -2.5f, 2.5f), gameObject.transform.position.y, gameObject.transform.position.z), DirectionalSpeed * Time.deltaTime);
#endif
        GetComponent<Rigidbody>().velocity = Vector3.forward * PlayerSpeed * Time.deltaTime;
        //Mobile Input
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
        if (Input.touchCount > 0)
        {
            transform.position = new Vector3(touch.x, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
         
        if (other.gameObject.tag == "ScoreUp")
        {
            GetComponent<AudioSource>().PlayOneShot(scoreUP, 0.5f);
        }
        if (other.gameObject.tag == "Triangle")
        {
            GetComponent<AudioSource>().PlayOneShot(Damage, 1.0f);
            sceneManager.GetComponent<App_initialize>().GameOver();
        }
    }
}
