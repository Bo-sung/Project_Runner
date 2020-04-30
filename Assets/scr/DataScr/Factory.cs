using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scr.DataScr
{
    public class Factory : MonoBehaviour
    {
        protected Container storage1;
        private int counter1;

        private void Start()
        {
            counter1 = 0;
        }

        public virtual GameObject Make(Vector3 pos,Quaternion rot)
        {
            counter1++;
            GameObject stage = Instantiate(storage1.GetSeqence(),pos,rot);
            return stage;
        }
        public virtual GameObject Make(int type, Vector3 pos,Quaternion rot)
        {
            counter1++;
            GameObject stage = Instantiate(storage1.GetType(type),pos,rot);
            return stage;
        }

        public virtual int GetContainerSize()
        {
            return storage1.getSize();
        }
    }

}
