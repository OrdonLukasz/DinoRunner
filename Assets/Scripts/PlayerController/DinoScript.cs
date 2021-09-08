using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DinoScript : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 300f;
    private bool isDead = false;

    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("IsGrounded", IsGrounded());
        if (isDead == false)
        {
            if (IsGrounded() == true)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rb.velocity = Vector2.zero;
                    rb.AddForce(new Vector2(0, jumpForce));
                }
            }
        }
    }
    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position - new Vector3(0.3f, 0.1f, 0.5f), Vector2.right * 0.6f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0.3f, 0.1f, 0.5f), Vector2.right, 1);

        if (hit.collider != null && hit.collider.name == "Ground")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
    }
    public void Die()
    {
        isDead = true;
        anim.SetBool("Die", isDead);
        StartCoroutine(Timer());
        ScriptManager.Instance.restartMenu.ActivationRestartMenu();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScorePoint"))
        {
            ScriptManager.Instance.scoreManager.ScoreCollecting();
        }
    }
}
