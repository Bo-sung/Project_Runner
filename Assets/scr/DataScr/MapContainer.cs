using System.Collections.Generic;
using UnityEngine;

namespace scr.DataScr
{
    public class MapContainer : Container
    {
        private int s_count;

        public void Add_stage(GameObject stage)
        {
            @group.Add(stage);
        }

        public List<GameObject> GetStages()
        {
            return @group;
        }

        public GameObject GetStage_random()
        {
            GameObject stage;
            stage = @group[Random.Range(0, @group.Count - 1)];
            return stage;
        }
        public GameObject GetStage_seqence()
        {
            if (s_count == null || s_count == @group.Count)
                s_count = 0;
            GameObject stage;
            stage = @group[s_count];
            s_count++;
            return stage;
        }
        public GameObject GetStage(int index)
        {
            GameObject stage = @group[index];
            return stage;
        }
        
    }
}