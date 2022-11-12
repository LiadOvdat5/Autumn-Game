using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCountGameOver : MonoBehaviour
{
    [SerializeField] TMP_Text coinCounterText;

    float coins = GameManager.leavesDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        
        coinCounterText.text = coins.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
