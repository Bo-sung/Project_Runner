using System;
using PlayerInitiallize;
using scr.PlayerScr;
using Statuses;
using UnityEngine;


public class User : Player
{
    
    [Header("Upper")]
    Animator Upper;
    public Animator Normal;
    public Animator Gun;
    public Animator Sword;
    GameObject upr_Normal;
    GameObject upr_Gun;
    GameObject upr_Sword;

    [Header("Upper-Select")]
    public bool Normal_Upper;
    public bool Gun_Upper;
    public bool Sword_Upper;
    Animator upperSelector()
    {
        Animator upr = null;
        if (Normal_Upper)
        {
            upr = Normal;
            Gun_Upper = false;
            Sword_Upper = false;
        }
        else if (!Gun_Upper && Sword_Upper)
        {
            upr = Sword;
            Normal_Upper = false;
            Gun_Upper = false;
        }
        else if (Gun_Upper && !Sword_Upper)
        {
            upr = Gun;
            Normal_Upper = false;
            Sword_Upper = false;
        }
        else
        {
            upr = Normal;
            Normal_Upper = true;
            Gun_Upper = false;
            Sword_Upper = false;
        }
        upr_Normal.SetActive(Normal_Upper);
        upr_Gun.SetActive(Gun_Upper);
        upr_Sword.SetActive(Sword_Upper);
        return upr;
    }

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
        
    }
    public override void Start()
    {
        base.Start();
        buff = 0;
        power = 3;
        Set_Status(jump, power, speed);
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        ani.SetInteger("Mov", 0);
        ani.SetInteger("State", 1);
        upr_Normal = transform.Find("Normal").gameObject;
        upr_Gun = transform.Find("Gun").gameObject;
        upr_Sword = transform.Find("Sword").gameObject;
        Upper = upperSelector();
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

    public override void Bump(Collision col)
    {
        base.Bump(col);
        if (col.transform.CompareTag("GROUND"))
        {
            Debug.Log("ON");
            if (state.Standing.jump)
            {
                state.Standing.jump = false;
                Set_Ani(ani, (int) Mov.Stand, (int) Sta.Run);
                smoke.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        
        if (col.transform.CompareTag("Item"))
        {
            Debug.Log("Equip");
            if (col.transform.name == "Gun")
            {
                Gun_Upper = true;
                Normal_Upper = false;
                Sword_Upper = false;
            }
            else if(col.transform.name == "Sword")
            {
                Gun_Upper = false;
                Normal_Upper = false;
                Sword_Upper = true;
            }
            Upper = upperSelector();
        }
    }
}
