using System.Collections.Generic;
using UnityEngine;

namespace scr.DataScr
{
    interface IContainer
    {
        void Add_Item(GameObject Item);
        List<GameObject> Get_List();
        GameObject Get_Item_random();
        GameObject Get_Item_seqence();
        GameObject Get_Item(int index);
    }
    public class Container :  MonoBehaviour
    {
        public List<GameObject> @group;
        private int m_count;

        public virtual void Add_Item(GameObject item)
        {
            @group.Add(item);
        }

        public virtual List<GameObject> Get_List()
        {
            return @group;
        }

        public virtual GameObject Get_Item_random()
        {
            GameObject item;
            item = @group[Random.Range(0, @group.Count - 1)];
            return item;
        }
        public virtual GameObject Get_Item_seqence()
        {
            if (m_count == null || m_count == @group.Count)
                m_count = 0;
            GameObject item;
            item = @group[m_count];
            m_count++;
            return item;
        }
        public virtual GameObject GetStage(int index)
        {
            GameObject item = @group[index];
            return item;
        }
        
    }
}