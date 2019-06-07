using System;
using PlayerInitiallize;
using scr.PlayerScr;
using UnityEngine;


public class User : Player
{ 
    public GameObject gameoverUI;
    public GameObject smoke;
    public GameObject coin;
    enum Mov { Stand, Jump, Crouch };
    enum Dir { Left, Right };
    enum Sta { idle, Run, Attack, Death};
    public User() : base()
    {
       
    }
    private struct groggy
    {
        public bool stun;
        public bool freez;
    }

    private float buff;
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
        
        
        if (Input.GetKey(KeyCode.Space) && !state.Standing.jump)
        {            
            Set_Ani(ani, (int)Mov.Jump, (int)Sta.idle);
            rb.velocity = new Vector3(0, stat.jump, 0);
            state.Standing.jump = true;
        }
        
	}

    
    

    public override void Attacked(float _power)
    {
        buff = _power * -1;
    }

    public override void Attack(GameObject target)
    {
        target.GetComponent<Enemy>().Attacked();
        buff = power;
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
        else if(col.transform.CompareTag("Enemy")&&col.transform.name == "Head")//col.transform.parent.CompareTag("Enemy") && 
        {
            Debug.Log(col.transform.name);
            Attack(col.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
    }
}
