using System.Collections;
using System.Collections.Generic;
using Statuses;
using UnityEngine;

namespace scr.MapScr
{
    public class MapContainer : MonoBehaviour
    {
        public List<GameObject> Stages;
        private int s_count;

        public void Add_stage(GameObject stage)
        {
            Stages.Add(stage);
        }

        public List<GameObject> GetStages()
        {
            return Stages;
        }

        public GameObject GetStage_random()
        {
            GameObject stage;
            stage = Stages[Random.Range(0, Stages.Count - 1)];
            return stage;
        }
        public GameObject GetStage_seqence()
        {
            if (s_count == null || s_count == Stages.Count)
                s_count = 0;
            GameObject stage;
            stage = Stages[s_count];
            s_count++;
            return stage;
        }
        public GameObject GetStage(int index)
        {
            GameObject stage = Stages[index];
            return stage;
        }
        
    }
}