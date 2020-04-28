using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KiwiCounter : MonoBehaviour { 


    private int moneyAmount;

    [SerializeField]
    private Text coinCounter;

    // Start is called before the first frame update
    void Start()
    {
        moneyAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinCounter.text = ": " + moneyAmount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Kiwi>())
        {
            moneyAmount += 1;
          //  Destroy(collision.gameObject);
    
        }
    }
}
