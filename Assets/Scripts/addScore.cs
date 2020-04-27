using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addScore : MonoBehaviour
{
    public int score;
    

    public LevelEnd1 LE;
    // Start is called before the first frame update
    void Start()
    {
        
        LE = GameObject.FindObjectOfType<LevelEnd1>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            LE.score += 1;
            
            
            
            this.gameObject.SetActive(false);

        }

        if (collision.tag == "Stomp")
        {

            LE.score += 1;



            this.gameObject.SetActive(false);

        }
    }
}
