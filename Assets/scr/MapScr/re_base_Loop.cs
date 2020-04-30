using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using scr.DataScr;

public class re_base_Loop : MonoBehaviour
{ 
    public float speed = 0;
    public float Gab = 0;
    [Space,Range(0,2)]
    public int Theme = 0;

    private int nowTheme;

    public int MapSize = 10;
    public GameObject Startpoint;
    public GameObject EndPoint;
    [Tooltip("INT값으로 변환할 예정이기떄문에 9자리까지.")]
    public string Pattern;//2,147,483,647‬/
    private Stack<int> patternStack;
    public List<GameObject> stages;
    public GroundFactory Fac;
    //public GameObject firstZone;
    //public GameObject secondZone;
    //public GameObject thirdZone;
    void parsePattern()
    {
        patternStack = new Stack<int>();
        int i_parse = int.Parse(Pattern);
        
        for(int i = 0 ; i < Pattern.Length -1 ; ++i)
        {
            patternStack.Push( i_parse % 10);
            i_parse = i_parse / 10;
        }
        
    }
    
    
    
    private Vector3 Genpos()
    {
        return Startpoint.transform.position;
    }


    private Quaternion Genrot()
    {
        return Startpoint.transform.rotation;
    }

    void stageInit()
    {
        int count = MapSize;
        do
        {
            Make(Theme);
            count--;
        } while (count != 0);
    }
    
    
    void Start ()
    {
        parsePattern();
        float size_x = Gab * -1;
        stageInit();
        foreach (var stage in stages)
        {
            stage.transform.position = EndPoint.transform.position + new Vector3(size_x, 0, 0); 
            size_x += stage.transform.localScale.x + Gab;
        }
    }
	
	// Update is called once per frameC_zone
	void Update ()
    {
        Move();
	}

    private bool themechange;
    void checkTheme()
    {
        if (stages[0].transform.name == "Hole" && themechange)
        {
            nowTheme = Theme;
            themechange = false;
        }
        if (themechange)
        {
            GameObject temp = stages[0];
            stages[0] = Fac.Make(Theme,temp.transform.position,temp.transform.rotation);
            Destroy(temp);
        }
        if (stages[0].transform.name == "Hole" && nowTheme != Theme)
        {
            themechange = true;
        }
        
    }
    

    void Move()
    {
        if (stages[0].transform.position.x <= EndPoint.transform.position.x)
        {
            //stages[0].transform.position = stages[stages.Count-1].transform.position + new Vector3(stages[stages.Count-1].transform.localScale.x,0,0);
            stages[0].transform.position = new Vector3(stages[stages.Count-1].transform.localScale.x +stages[stages.Count-1].transform.position.x ,Genpos().y + (patternStack.Pop()/2) ,stages[stages.Count-1].transform.position.z);
            checkTheme();
            if (patternStack.Count <= 0)
                parsePattern();
            stages.Add(stages[0]);
            stages.RemoveAt(0);
        }
        foreach (var stage in stages)
        {
            stage.transform.Translate(Vector3.left * speed * Time.deltaTime);
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
        GameObject newG = Fac.Make(Genpos(),Genrot());
        stages.Add(newG);
    }

    void Make(int type)
    {
        stages.Add(Fac.Make(type, Genpos(),Genrot()));
    }
    
}