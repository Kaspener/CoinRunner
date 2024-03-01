using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float velocity = 5.0f;
    public FixedJoystick joystick;
    public float velocityLeftRight = 5.0f;
    private int hp = 100;
    private int coins = 0;
    public Text hpText;
    public Text coinsText;
    private MakeJump jumpScript;
    private bool isGrounded;
    private Animator animator;

    void Start()
    {
        jumpScript = GameObject.Find("JumpButton").GetComponent<MakeJump>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        transform.position += new Vector3(velocity * Time.deltaTime, 0, -velocityLeftRight*(joystick.Direction.x * Time.deltaTime));
        Jump();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.Play("Drunk Run Forward");
        }
        else if (collision.gameObject.tag == "EndGame")
        {
            SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
        }
    }

    private void Jump()
    {
        if (jumpScript.isJumped && isGrounded)
        {
            jumpScript.isJumped = false;
            isGrounded = false;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
            animator.Play("Jump");
        }
    }

    public void UpdateHp(int heal)
    {
        hp += heal;
        if (hp > 100) hp = 100;
        hpText.text = hp.ToString();
        if (hp <= 0)
        {
            SceneManager.LoadScene("LoseScreen", LoadSceneMode.Single);
        }
    }

    public void UpdateCoins(int coin)
    {
        coins += coin;
        coinsText.text = coins.ToString();
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("coins", coins);
    }
}
