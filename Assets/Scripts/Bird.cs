using UnityEditor.Build.Content;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    private int spriteIndex;

    private Vector3 direction;

    public float gravity = -9.8f;
    public float strength = 25f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
        
        Quaternion rot = transform.rotation;
if (direction.y > 0)
            {
                rot.z = direction.y * 0.02f;
                transform.rotation = rot;
            }
            else
            {
                rot.z = direction.y * 0.02f;
                transform.rotation = rot;
            }
    }
    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "obstacle"){
            FindObjectOfType<ScoreLogic>().GameOver();
        }else if(other.gameObject.tag == "scoring"){
            FindObjectOfType<ScoreLogic>().IncreaseScore();
        }
    }
}
