using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusController : MonoBehaviour
{
    public ScriptableCactus scriptableCactus;
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;

    private void Start()
    {
        spriteRenderer.sprite = scriptableCactus.obsticleSprite;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity -= new Vector2(scriptableCactus.speed, 0);
    }
    private void Update()
    {
        if (ScriptManager.Instance.scoreManager.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<DinoScript>().Die();
        }
    }
}
