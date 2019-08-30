using System;
using PlayerInitiallize;
using scr.PlayerScr;
using UnityEngine;


public class User : Player
{
    
    [Header("Upper")]
    Animator Upper;
    public GameObject Normal;
    public GameObject Gun;
    public GameObject Sword;
    
    [Header("Upper-Select")]
    public bool Normal_Upper;
    public bool Gun_Upper;
    public bool Sword_Upper;

    [Header("UI")]
    public GameObject gameoverUI;
    [Header("Effects")]
    public GameObject smoke;
    public GameObject coin;
    enum Mov { Stand, Jump, Crouch };
    enum Dir { Left, Right };
    enum Sta { idle, Run, Attack, Death};
    public override void Set_Ani(Animator ani, int Move, int State)
    {
        base.Set_Ani(ani, Move, State);
        Upper.SetInteger("Mov", Move);
        Upper.SetInteger("State", State);
    }
    public User() : base()
    {
        Upper = GetComponent<Animator>();
        if (Normal_Upper)
        {
            Upper = Normal.GetComponent<Animator>();
            Gun_Upper = false;
            Sword_Upper = false;
            Gun.SetActive(false);
            Sword.SetActive(false);

        }
        else if(!Gun_Upper && Sword_Upper)
        {
            Upper = Sword.GetComponent<Animator>();
            Normal_Upper = false;
            Sword_Upper = false;
            Gun.SetActive(false);
            Normal.SetActive(false);

        }
        else if (Gun_Upper && !Sword_Upper)
        {
            Upper = Gun.GetComponent<Animator>();
            Normal_Upper = false;
            Gun_Upper = false;
            Gun.SetActive(false);
            Normal.SetActive(false);
        }
        else
        {
            Upper = Normal.GetComponent<Animator>();
            Gun.SetActive(false);
            Sword.SetActive(false);
        }
    }
    private struct groggy
    {
        public bool stun;
        public bool freez;
    }

    private float buff;
    public override void Jump()
    {
        if (!state.Standing.jump)
        {
            Set_Ani(ani, (int)Mov.Jump, (int)Sta.idle);
            rb.velocity = new Vector3(0, stat.jump, 0);
            state.Standing.jump = true;
        }
        base.Jump();
    }
    public override void Move_Forard()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        base.Move_Forard();
    }
    // Use this for initialization
    // 사실상 생성자는 start임
    void Start ()
    {
        buff = 0;
        power = 3;
        Set_Status(jump, power, speed);
        rb = GetComponent<Rigidbody>();
        ani = GetComponentInChildren<Animator>();
        ani.SetInteger("Mov", 0);
        ani.SetInteger("State", 1);
    }
    // Update is called once per frame
    void Update ()
    {
        transform.Translate(Vector3.right * buff * Time.deltaTime);
        if (buff > 0)
        {
            buff -= Time.deltaTime;
        }
        if (buff == 0)
        {
            buff = 0;
        }

        if (buff < 0)
        {
            buff += Time.deltaTime;
        }
	}


    private void LateUpdate()
    {
        if(state.death == true)
        {
            Set_Ani(ani, (int)Mov.Stand, (int)Sta.Death);
            gameoverUI.active = true;
        }
    }
    public override void OnColEnter(Collision col)
    {
        base.OnColEnter(col);
        if(col.transform.tag == "GROUND")
        {
            Debug.Log("ON");
            state.Standing.jump = false;
            Set_Ani(ani, (int)Mov.Stand, (int)Sta.Run);
            smoke.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
    }
}
