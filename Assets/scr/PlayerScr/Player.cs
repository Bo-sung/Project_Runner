
using Statuses;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PlayerInitiallize
{
    public class Player :MonoBehaviour
    {
        private float Jump_Power = 8f;
        public float jump;
        public float power;
        public float speed;
        public State state;
        public void Set_Status(float Jump, float Power, float Speed)
        {
            stat.power = Power;
            stat.jump = Jump;
            stat.speed = Speed;
        }
        public Status stat;

        public Player()
        {
            state = new State();
            state.Standing.jump = false;
            state.Standing.stand = true;
            state.Standing.crouch = false;
            state.Work.attack = false;
            state.Work.Run = true;
            state.Work.idle = true;
            state.death = false;
            stat = new Status();
            stat.jump = 8f;
            stat.power = 0f;
            stat.speed = 1f;
        }
        public void Set_Ani(Animator ani, int Move, int State)
        {
            ani.SetInteger("Mov", Move);
            ani.SetInteger("State", State);
        }
        public string Compare_Ani_State(Animator ani) //만약 state와 에니메이션의 parameter가 일치하는지 검사, 에러가 있다면 부분 출력
        {
            string Error_Message = "No Error";
            if(state.Standing.jump == state.Standing.stand || state.Standing.stand == state.Standing.crouch || state.Standing.crouch == state.Standing.jump)
            {
                Error_Message = "standing is currupted";
            }
            if (state.Standing.jump)
            {
                if (ani.GetInteger("Mov") != (int)mov.Jump)
                {
                    Error_Message = "Jump state is currupted";
                }
            }
            if (ani.GetInteger("Mov") == (int)mov.Jump)
            {
                if (!state.Standing.jump)
                {
                    Error_Message = "Jump state is currupted";
                }
            }

            if (state.Standing.stand)
            {
                if (ani.GetInteger("Mov") != (int)mov.Stand)
                {
                    Error_Message = "stand state is currupted";
                }
            }
            if (ani.GetInteger("Mov") == (int)mov.Stand && ani.GetInteger("State") != (int)sta.Run)
            {
                if (!state.Standing.stand)
                {
                   
                }
            }

            if (state.Standing.crouch)
            {
                if (ani.GetInteger("Mov") != (int)mov.Crouch && ani.GetInteger("State") != (int)sta.Run)
                {
                    
                }
            }
            if (ani.GetInteger("Mov") == (int)mov.Crouch && ani.GetInteger("State") != (int)sta.Run)
            {
                if (!state.Standing.crouch)
                {
                    
                }
            }

            return Error_Message;
        }
        public virtual void Update()
        {

        }
        public void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == "DeathZone")
            {
                state.death = true;
            }
        }
    }
}
