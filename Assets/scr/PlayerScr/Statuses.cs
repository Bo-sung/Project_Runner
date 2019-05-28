using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statuses
{
    public struct State     //상태
    {
        public struct standing
        {
            public bool jump;
            public bool crouch;
            public bool stand;
        }
        public struct Do
        {
            public bool idle;
            public bool Run;
            public bool attack;
        }
        public standing Standing;
        public Do Work;
        
        public bool death; //생존
    }
    public struct Status
    {
        public float jump;
        public float power;
        public float speed;
        public float HP;
    }
    enum mov { Stand, Jump, Crouch };
    enum dir { Left, Right };
    enum sta { idle, Run, Attack ,Death };
}
