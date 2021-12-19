using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private Sprite[] redSprites;
    private int spriteIndex;

    private Vector3 direction;
    [SerializeField]
    private float gravity = -9.8f;
    [SerializeField]
    private float strength = 5f;

    private GameController gm;

    private Vector2 lastPos;
    [SerializeField]
    private float rotateSpeed =  90f;

    private float nextCheck;
    [SerializeField]
    private float checkDelay = 0.1f;

    bool redBird = false;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        gm = FindObjectOfType<GameController>();

        nextCheck = Time.time;
    }

    private void Start()
    {
        SelectColor();
        if (redBird)
        {
            InvokeRepeating(nameof(AnimateRedBird), .15f, .15f);
        }
        else
        {
            InvokeRepeating(nameof(AnimateBird), .15f, .15f);
        }
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;

        direction = Vector3.zero;

        SelectColor();
        if (redBird)
        {
            InvokeRepeating(nameof(AnimateRedBird), .15f, .15f);
        }
        else
        {
            InvokeRepeating(nameof(AnimateBird), .15f, .15f);
        }
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(AnimateBird));
        CancelInvoke(nameof(AnimateRedBird));
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

        if (Time.time < nextCheck)
        {
            return;
        }

        if (IsFalling())
        {
            transform.Rotate(transform.forward, -rotateSpeed * Time.smoothDeltaTime);
            if (transform.eulerAngles.z < -30)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -30);
            }
        }
        else
        {
            transform.Rotate(transform.forward, (rotateSpeed * 2) * Time.smoothDeltaTime);

            if (transform.eulerAngles.z > 30)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 30);
            }
        }

        lastPos = transform.position;

        nextCheck = Time.time + checkDelay;
    }

    bool IsFalling()
    {
        return (transform.position.y < lastPos.y);
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

    private void AnimateRedBird()
    {
        spriteIndex++;

        if (spriteIndex >= redSprites.Length)
        {
            spriteIndex = 0;
        }

        sr.sprite = redSprites[spriteIndex];
    }

    public void SelectColor()
    {
        int color = Random.Range(0, 2);

        if (color == 0)
        {
            redBird = false;
        }
        else
        {
            redBird = true;
        }
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
