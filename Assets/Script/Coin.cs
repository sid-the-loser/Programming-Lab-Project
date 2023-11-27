using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Coin : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other) // runs if an object collides/passes through the coin
    {
        if (other.CompareTag("Player")) // checks if it was the player
        {
            Destroy(this.gameObject); // destroys the coin

            other.GetComponent<Player>().addScore(); // runs "addScore" function in Player script

        }
    }
}
