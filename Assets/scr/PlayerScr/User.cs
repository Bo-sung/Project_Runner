using PlayerInitiallize;
using UnityEngine;


public class User : Player
{ 
    public GameObject gameoverUI;
    Rigidbody rb;
    Animator ani;
    public GameObject smoke;
    public GameObject coin;
    enum Mov { Stand, Jump, Crouch };
    enum Dir { Left, Right };
    enum Sta { idle, Run, Attack, Death};
    public User() : base()
    {
       
    }
    // Use this for initialization
    // 사실상 생성자는 start임
    void Start ()
	{
        Set_Status(jump, power, speed);
        rb = GetComponent<Rigidbody>();
        ani = GetComponentInChildren<Animator>();
        ani.SetInteger("Mov", 0);
        ani.SetInteger("State", 1);
    }
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey(KeyCode.Space) && !state.Standing.jump)
        {            
            Set_Ani(ani, (int)Mov.Jump, (int)Sta.idle);
            rb.velocity = new Vector3(0, stat.jump, 0);
            state.Standing.jump = true;
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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "GROUND")
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
