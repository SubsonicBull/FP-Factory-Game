using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count_collectedItems : MonoBehaviour
{

    public Text counter;

    public CheckCollision checkCollision;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = checkCollision.count_collectedItems.ToString();
    }
}
