using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class chasePlayer : MonoBehaviour
{
    public int moveSpeed = 4;
    public int runSpeed = 5;//�����ƶ��ٶ�
    public int rotationSpeed = 5;//����ת���ٶ�
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
    private Transform target;//Ŀ�����
    private Transform myTransform;
    private Vector3 Last;//
    private Ray ray;
    private RaycastHit hitinfo;
    private Vector3 targetPosition;
    //Ŀ����ҵ�����
    private float maxDistance;
    private NavMeshAgent navMeshAgent;//��Ҹ������ľ���

    void Awake()
    {

        myTransform = transform;


        //��ǰ�����transform����myTransform

    }

    void Start()
    {
        hitinfo = new RaycastHit();
        music = gameObject.AddComponent<AudioSource>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        //���ò�һ��ʼ�Ͳ�����Ч
        music.playOnAwake = false;
        //������Ч�ļ����Ұ���Ծ����Ƶ�ļ�����Ϊjump
        GateAnimator = gameObject.GetComponent<Animator>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");//�ҵ�tagΪplayer�Ķ���
        target = player.transform;
        Last = myTransform.transform.position;
        //����player����Ŀ�����

    }

    void Update()
    {
        updateAnimator();

        GameObject player = GameObject.FindGameObjectWithTag("Player");//�ҵ�tagΪplayer�Ķ���
        target = player.transform;
        if (IsVisible())
        {

            Last = player.transform.position;
            targetPosition = new Vector3(target.position.x, target.position.y, target.position.z);//�õ��������xz����
            //Debug.DrawLine(target.position, myTransform.position, Color.green);
            //����player����Ŀ�����
        }
        if (!IsVisible())
        {
            // Debug.Log(Last.position.x);
            targetPosition = new Vector3(Last.x, Last.y, Last.z);//�õ��������xz����
            Debug.DrawLine(Last, myTransform.position, Color.red);
        }

        ray = new Ray(myTransform.position + new Vector3(0, 2f, 0), target.position - myTransform.position);
        Debug.DrawRay(myTransform.position + new Vector3(0, 2f, 0), target.position - myTransform.position, Color.green);

        // myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(targetPosition - myTransform.position), rotationSpeed * Time.deltaTime);//����ת���������

        //���ù���������ƶ�
        maxDistance = Vector3.Distance(target.position, myTransform.position);//��ȡ��������֮��ľ���
        if (maxDistance >= 2 && IsVisible())
        {
            //�������������ʱ�ƶ�
            RunMethod();
            //�ù��ﳯ���Լ��������ƶ�
        }
        else if (maxDistance < 2 && IsVisible())
        {
            AttackMethod();
            //Debug.Log("̫����");//������С������ʱ�Ķ���
        }
        else if (maxDistance >= 2 && !IsVisible())
        {
            // Debug.Log("������");//������С������ʱ�Ķ���
            WalkMethod();

        }
        else
        {
            // StopMethod();
        }

        // Debug.Log("����Ϊ��"+maxDistance);
    }

    private void updateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }

    bool IsVisible()
    {



        if (Physics.Raycast(ray, out hitinfo, 1000) && hitinfo.transform.tag == "Player")
        {
            vis = true;
            Debug.Log("'000000000'");
            return true;
            

        }

        

        if (Physics.Raycast(ray, out hitinfo, 1000) && hitinfo.transform.tag != "Player")
        {
            vis = false;
            Debug.Log("'11111111'");
            Debug.Log(Physics.Raycast(ray, out hitinfo, 1000));
            Debug.Log(hitinfo.transform.name);
            return false;

        }
        Debug.Log("'22222222'");

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
        //������Ч
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
        //������Ч
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
        //������Ч
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
            //������Ч
            music.Play();
        }

        if (AttackTime == 150)
        {
            GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
            music.clip = dead;
            //������Ч
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
