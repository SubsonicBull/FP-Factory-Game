using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMarkSprite : MonoBehaviour
{
    public GameObject player;

    private SpriteRenderer _renderer;

    public Rigidbody rb;

    void Start()
    {
        InvokeRepeating("Flipping", 0.2f, 0.2f);  //0.01s delay, repeat every 0.01s
        _renderer = GetComponent<SpriteRenderer>();
        if (_renderer == null)
        {
            Debug.LogError("Player Sprite is missing a renderer");
        }
    }

    void Flipping()
    {
        if(rb.velocity.magnitude >= 5)
        {
            if(_renderer.flipX == false)
            {
                _renderer.flipX = true;
            }
            else
            {
                _renderer.flipX = false;
            }
        }
    }

    void Update()
    {
        transform.LookAt(player.transform);
    }
}
