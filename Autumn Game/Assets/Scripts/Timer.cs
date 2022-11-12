using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float startingTime = 30;
    public float currentTime;

    [SerializeField] Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime += 1 * Time.deltaTime;
        if (timerText != null)
        {
            timerText.text = currentTime.ToString("0");
        }
    }
}
