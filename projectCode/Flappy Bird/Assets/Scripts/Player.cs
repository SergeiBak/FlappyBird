using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField]
    private Sprite[] sprites;
    private int spriteIndex;

    private Vector3 direction;
    [SerializeField]
    private float gravity = -9.8f;
    [SerializeField]
    private float strength = 5f;

    private GameController gm;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        gm = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateBird), .15f, .15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;

        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // Keyboard / mouse input
        {
            direction = Vector3.up * strength;
        }

        if (Input.touchCount > 0)   // mobile / touchscreen input
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateBird()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        sr.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gm.GameOver();
        }
        else if (collision.gameObject.tag == "Scoring")
        {
            gm.IncreaseScore();
        }
    }
}
