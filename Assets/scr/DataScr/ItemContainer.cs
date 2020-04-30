using System.Collections;
using System.Collections.Generic;
using scr.DataScr;
using UnityEngine;

namespace scr.DataScr
{
    public class ItemContainer : Container
    {
        public override GameObject GetSeqence()
        {
            return base.GetSeqence();
        }

        public override List<GameObject> GetList()
        {
            return base.GetList();
        }

        public override GameObject GetType(int index)
        {
            return base.GetType(index);
        }

        public override GameObject GetRandom()
        {
            return base.GetRandom();
        }
        
    }
}
