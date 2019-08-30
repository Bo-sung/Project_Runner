using System.Collections;
using System.Collections.Generic;
using scr.DataScr;
using UnityEngine;
using UnityEngine.Serialization;

public class base_loop : MonoBehaviour {
    public float speed = 0;
    public float Gab = 0;
    public int nextStage = 0;
    public MapContainer mapcontainer;
    public List<GameObject> stages;

    private float stage_size = 10;
    //public GameObject firstZone;
    //public GameObject secondZone;
    //public GameObject thirdZone;
    // Use this for initialization
    
    private Vector3 Genpos()
    {
        return new Vector3(20 + Gab * 2,-5,-2);
    }

    private Quaternion Genrot()
    {
        return new Quaternion(0,180,0,0);
    }
    
    void Start ()
    {
        float size_x = Gab * -1;
        foreach (var stage in stages)
        {
            stage.transform.position = new Vector3(0 + size_x + Gab,-5,-2);
            size_x += stage.transform.localScale.x + Gab;
        }

        stage_size = stages[0].transform.localScale.x;
    }
	
	// Update is called once per frameC_zone
	void Update ()
    {
        Move();
	}
    void Move()
    {
        foreach (var stage in stages)
        {
            stage.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

       
        
        if(stages[0].transform.position.x <= -stage_size -Gab)
        {
            Destroy(stages[0]);
            stages.RemoveAt(0);
            if (nextStage != 0)
            {
                Make(nextStage);
                nextStage = 0;
            }
            else
            {
                Make();
            }
        }
        //firstZone.transform.Translate(Vector3.right * speed * Time.deltaTime);
        //secondZone.transform.Translate(Vector3.right * speed * Time.deltaTime);
        //thirdZone.transform.Translate(Vector3.right * speed * Time.deltaTime);
        //if(firstZone.transform.position.x <= -14)
        //{
        //    Destroy(firstZone);
        //    firstZone = secondZone;
        //    secondZone = thirdZone;
        //    Make();
        //}
    }
    //void Make()
    //{
    //    thirdZone = Instantiate(mapcontainer.GetStage_seqence(), Genpos(),Genrot());
    //}
    void Make()
    {
        GameObject stage = Instantiate(mapcontainer.GetStage_seqence(), Genpos(),Genrot());
        stages.Add(stage);
    }

    void Make(int type)
    {
        stages.Insert(2,Instantiate(mapcontainer.GetStage(type), Genpos(),Genrot()));
    }
    
}
