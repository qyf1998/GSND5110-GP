using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class chasePlayer : MonoBehaviour
{
    public int moveSpeed = 4;
    public int runSpeed = 5;//怪物移动速度
    public int rotationSpeed = 5;//怪物转身速度
    public Vector3 velocity = Vector3.zero;
    public bool showed = false;
    public bool Killed = false;
    public static int AttackTime = 0;
    public static bool vis = true;
    public AudioSource music;
    public AudioClip walk;
    public AudioClip dead;
    public AudioClip attack;
    public AudioClip run;
    private Animator GateAnimator;
    private bool IsWalk = false;
    private bool IsRun = false;
    private bool IsAttack = false;
    private Transform target;//目标玩家
    private Transform myTransform;
    private Vector3 Last;//
    private Ray ray;
    private RaycastHit hitinfo;
    private Vector3 targetPosition;
    //目标玩家的坐标
    private float maxDistance;
    private NavMeshAgent navMeshAgent;//玩家跟怪物间的距离

    void Awake()
    {

        myTransform = transform;


        //当前怪物的transform付给myTransform

    }

    void Start()
    {
        hitinfo = new RaycastHit();
        music = gameObject.AddComponent<AudioSource>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        //设置不一开始就播放音效
        music.playOnAwake = false;
        //加载音效文件，我把跳跃的音频文件命名为jump
        GateAnimator = gameObject.GetComponent<Animator>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");//找到tag为player的对象
        target = player.transform;
        Last = myTransform.transform.position;
        //定义player就是目标玩家

    }

    void Update()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");//找到tag为player的对象
        target = player.transform;
        if (IsVisible())
        {

            Last = player.transform.position;
            targetPosition = new Vector3(target.position.x, target.position.y, target.position.z);//得到怪物脚下xz坐标
            Debug.DrawLine(target.position, myTransform.position, Color.green);
            //定义player就是目标玩家
        }
        if (!IsVisible())
        {
            // Debug.Log(Last.position.x);
            targetPosition = new Vector3(Last.x, Last.y, Last.z);//得到怪物脚下xz坐标
            Debug.DrawLine(Last, myTransform.position, Color.red);
        }

        ray = new Ray(myTransform.position + new Vector3(0, 0.5f, 0), target.position - myTransform.position);


        // myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(targetPosition - myTransform.position), rotationSpeed * Time.deltaTime);//挂物转身朝向玩家

        //设置怪物想玩家移动
        maxDistance = Vector3.Distance(target.position, myTransform.position);//获取玩家与怪物之间的距离
        if (maxDistance >= 2 && IsVisible())
        {
            //当距离大于两米时移动
            RunMethod();
            //让怪物朝着自己的正面移动
        }
        else if (maxDistance < 2 && IsVisible())
        {
            AttackMethod();
            //Debug.Log("太近了");//当距离小于两米时的动作
        }
        else if (maxDistance >= 2 && !IsVisible())
        {
            // Debug.Log("看不见");//当距离小于两米时的动作
            WalkMethod();

        }
        else
        {
            // StopMethod();
        }

        // Debug.Log("距离为："+maxDistance);
    }

    bool IsVisible()
    {



        if (Physics.Raycast(ray, out hitinfo, 1000) && hitinfo.transform.tag == "Player")
        {
            vis = true;
            return true;

        }
        if (Physics.Raycast(ray, out hitinfo, 1000) && hitinfo.transform.tag != "Player")
        {
            vis = false;
            //Debug.Log(hitinfo.transform.tag);
            return false;

        }

        return false;
    }

    public void WalkMethod()
    {
        GateAnimator.SetBool("canwalk", true);
        GateAnimator.SetBool("canattack", false);
        GateAnimator.SetBool("canstand", false);
        GateAnimator.SetBool("canrun", false);
        music.clip = walk;
        // myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        GetComponent<NavMeshAgent>().destination = targetPosition;
        //Debug.Log("Walking");
        //播放音效
        //music.clip = walk;
        // music.Play();
        // music.pitch = 1.1f;

        IsWalk = true;
        IsAttack = false;

    }

    public void RunMethod()
    {
        GateAnimator.SetBool("canwalk", false);
        GateAnimator.SetBool("canrun", true);
        GateAnimator.SetBool("canattack", false);
        GateAnimator.SetBool("canstand", false);

        GetComponent<NavMeshAgent>().destination = targetPosition;
        // myTransform.position += myTransform.forward * runSpeed * Time.deltaTime;
        // Debug.Log("Runing");

        //music.clip = run;
        //music.Play();
        //music.pitch = 1.1f;

        IsRun = true;
        IsAttack = false;

    }
    public void StopMethod()
    {
        GateAnimator.SetBool("canwalk", false);
        GateAnimator.SetBool("canstand", true);
        GateAnimator.SetBool("canattack", false);
        GateAnimator.SetBool("canrun", false);
        // music.clip = idle;
        //播放音效
        // music.Play();
        // music.pitch = 1.1f;

        IsWalk = false;

    }

    public void AttackMethod()
    {
        GateAnimator.SetBool("canwalk", false);
        GateAnimator.SetBool("canattack", true);
        GateAnimator.SetBool("canstand", false);
        GateAnimator.SetBool("canrun", false);
        //music.clip = attack;
        //播放音效
        // music.Play();
        // music.pitch = 1.1f;

        IsAttack = true;
        IsWalk = false;

    }

    void FixedUpdate()
    {
        Debug.Log(AttackTime);
        if (AttackTime >= 0 && IsAttack)
        {
            AttackTime++;

        }

        if (AttackTime % 50 == 0 && AttackTime < 150)
        {
            music.clip = attack;
            //播放音效
            music.Play();
        }

        if (AttackTime == 150)
        {
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
            music.clip = dead;
            //播放音效
            music.Play();
            Killed = true;
            Timer.t = 0;
        }

        if (Killed && Timer.t == 100)
        {
            SceneManager.LoadScene(0);
        }
    }

}
