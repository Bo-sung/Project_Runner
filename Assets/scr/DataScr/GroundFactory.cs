using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scr.DataScr
{
    public class GroundFactory : Factory
    {
        public MapContainer Map;
        public ItemContainer Item;
        private int ItemCounter;
        private int holeCounter;
        private void Awake()
        {
            ItemCounter = 0;
            storage1 = Map;
        }

        public override GameObject Make(Vector3 pos,Quaternion rot)
        {
            holeCounter++;
            return base.Make(pos, rot);
        }
        public override GameObject Make(int type, Vector3 pos,Quaternion rot)
        {
            holeCounter++;
            return base.Make(type,pos, rot);
        }
        public GameObject Make(Vector3 pos,Quaternion rot,int itemType)
        {
            holeCounter++;
            GameObject stage = base.Make(pos, rot);
            GameObject item;
            return stage;
        }
    }
}
