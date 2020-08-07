using System;

public class HCSR04 : ArdunityController, IWireInput<float>
{

    public int trig;
    public int echo;
    public bool down_flag;     // 내려갔음을 인식하는 변수
    public bool up_flag;     // 올라갔음을 인식하는 변수
    public int count;   // 운동횟수 변수 

    public float c;    // range of motion(얼마만큼 범위로 움직였는지 인식하는 변수, 70cm 올라갔을때 100%에 수렴하고, 각 무게에 해당되는 맨 밑 높이에서 정지했을때는 0%에 수렴한다.)
    public FloatEvent OnDistanceChanged;
    public float Stime;  // 운동 시작하고 총 경과한 시간(초 단위)


    private UINT16 _distance = 0;  // 초음파센서가 측정한 거리 변수, 처음에는 0으로 초기화. 여기서 0.1을 곱해야 cm단위가 된다.
    private float chestdistance;   // 체스트머신이 이동한 거리변수
    private float legdistance;   // 레그머신이 이동한 거리변수
    private float backdistance;  // 렛풀다운머신이 이동한 거리변수
    private float butterdistance;   // 버터플라이머신이 이동한 거리변수

    public Vector3 target_chest;   // 체스트머신이 이동한 목표지점    ??
    public Vector3 target_leg;  // 레그머신이 이동한 목표지점
    public Vector3 target_back;  // 렛풀다운머신이 이동한 목표지점
    public Vector3 target_butter;  // 버터플라이머신이 이동한 목표지점

    public Text REPS;   // REPS는 운동횟수를 의미한다.

    public static string WEIGHT;   // 장착한 무게 해당 변수  
                                   //  WEIGHT는 무게추(핀)이 몇 kg에 장착되어있는지, 지면~초음파센서 사이 수직거리(_distance * 0.1f)에 따라서 판단해준다.

    void start()
    {
        count = 0;
    }
    //운동횟수는 처음 시작할땐 0이기 떄문에 초기화시켰다.



    void Update()
    {



        if (tag.Equals("Weight_chest"))    //체스트프레스 무게추 태그이름에 해당된다.
        {
            chestdistance = (0.003f * _distance) - 0.5f;      // 체스트프레스 무게추가 초기높이~최고높이 왕복운동 함에 따라 무게추 바 내에서만 움직일 수 있는 거리 비율, 실험을 통해 초음파센서 거리의 상수배에 특정 상수를 빼 줌으로서 맞춰주었다.
            target_chest = new Vector3(-0.12f, 0.09f + chestdistance, -0.4f);     // 체스트프레스 무게추가 이동한 목표지점. (-0.12f,0.09f,-0.4f)는 처음 체스트프레스 무게추 위치를 나타내고, 윗 방향이 y축방향이기떄문에 0.09f에 chestdistance를 더해주었다.
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target_chest, 0.5f * Time.deltaTime);    // 목표지점으로 이동시켜주는 함수, 그냥 Position이 아닌 localPosition을 사용해야 프리팹(한 운동머신 내)에서의 상대적인 위치 이동을 계산해줄 수 있다.

        }




        else if (tag.Equals("Weight_leg"))    // 레그머신 무게추 태그이름에 해당된다.
        {
            legdistance = (0.003f * _distance) - 0.5f;
            target_leg = new Vector3(0.0001539739f, 0.1270574f + legdistance, -0.3146576f);   // (0.0001539739f,0.1270574f,-0.3146576f)는 레그머신 무게추 처음 위치

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target_leg, 0.5f * Time.deltaTime);



        }



        else if (tag.Equals("Weight_back"))    // 렛풀다운머신 무게추 태그이름에 해당된다.
        {
            backdistance = (0.003f * _distance) - 0.5f;
            target_back = new Vector3(0.0001140333f, 0.2480541f + backdistance, -0.1547323f);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target_back, 0.5f * Time.deltaTime);
        }

        else if (tag.Equals("Weight_butter"))    // 버터플라이머신 무게추 태그이름에 해당된다.
        {
            butterdistance = (0.003f * _distance) - 0.5f;
            target_butter = new Vector3(-0.016f, 0.07f + butterdistance, -0.31f);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target_butter, 0.5f * Time.deltaTime);
        }



        Exercise_count();          // 운동 함수를 호출시켜 void Exercise_count() 로 이동한다.



    }



