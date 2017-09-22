using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CoinCounter : MonoBehaviour {

    static int coins = 0;
    public int maxCoins = 0;

    public static void addToCoins()
    {
        coins++;
    }
	
	// Update is called once per frame
	void Update () {
		if(coins == maxCoins)
        {
            coins = 0;
            SceneManager.LoadScene(0);
        }
	}
}
