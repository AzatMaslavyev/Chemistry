using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronMove : MonoBehaviour
{
    [HideInInspector] public GameObject[] _pointS1Orbit;
    [HideInInspector] public GameObject[] _pointS2Orbit;
    [HideInInspector] public GameObject[] _pointS3Orbit;
    [HideInInspector] public GameObject[] _pointP1Orbit_x;
    [HideInInspector] public GameObject[] _pointP1Orbit_y;
    [HideInInspector] public GameObject[] _pointP1Orbit_z;
    [HideInInspector] public GameObject[] _pointP2Orbit_x;
    public GameObject _prefabElectron;
    public int _sequenceNumber; //порядковый номер
    int _numberRandPosition; //первое рандомное число для позиции
    int _numberRandPosition2; //второе рандомное число для позиции
    public float _speedMoveAtom = 5f;
    float _speedMoveAtomReset;


    // Start is called before the first frame update
    void Start()
    {
        _speedMoveAtomReset = _speedMoveAtom;
        setpoint();
    }

    //Очистка электронов

    void setpoint()
    {
        //Устаналвиваем точки S1Orbit
        int _countPointOrbitS1 = GameObject.FindGameObjectsWithTag("OrbitS1").Length;
        _pointS1Orbit = new GameObject[_countPointOrbitS1];
        if (_countPointOrbitS1 != 0)
        {
            _pointS1Orbit = GameObject.FindGameObjectsWithTag("OrbitS1");
        }

        //Устаналвиваем точки S2Orbit
        int _countPointOrbitS2 = GameObject.FindGameObjectsWithTag("OrbitS2").Length;
        _pointS2Orbit = new GameObject[_countPointOrbitS2];
        if (_countPointOrbitS2 != 0)
        {
            _pointS2Orbit = GameObject.FindGameObjectsWithTag("OrbitS2");
        }

        //Устаналвиваем точки S3Orbit
        int _countPointOrbitS3 = GameObject.FindGameObjectsWithTag("OrbitS3").Length;
        _pointS3Orbit = new GameObject[_countPointOrbitS3];
        if (_countPointOrbitS3 != 0)
        {
            _pointS3Orbit = GameObject.FindGameObjectsWithTag("OrbitS3");
        }

        //Устаналвиваем точки P1Orbit_x
        int _countPointOrbitP1x = GameObject.FindGameObjectsWithTag("OrbitP1_x").Length;
        _pointP1Orbit_x = new GameObject[_countPointOrbitP1x];
        if (_countPointOrbitP1x != 0)
        {
            _pointP1Orbit_x = GameObject.FindGameObjectsWithTag("OrbitP1_x");

        }

        //Устаналвиваем точки P1Orbit_y
        int _countPointOrbitP1y = GameObject.FindGameObjectsWithTag("OrbitP1_y").Length;
        _pointP1Orbit_y = new GameObject[_countPointOrbitP1y];
        if (_countPointOrbitP1y != 0)
        {
            _pointP1Orbit_y = GameObject.FindGameObjectsWithTag("OrbitP1_y");
        }

        //Устаналвиваем точки P1Orbit_z
        int _countPointOrbitP1z = GameObject.FindGameObjectsWithTag("OrbitP1_z").Length;
        _pointP1Orbit_z = new GameObject[_countPointOrbitP1z];
        if (_countPointOrbitP1z != 0)
        {
            _pointP1Orbit_z = GameObject.FindGameObjectsWithTag("OrbitP1_z");
        }

        //Устаналвиваем точки P2Orbit_x
        int _countPointOrbitP2x = GameObject.FindGameObjectsWithTag("OrbitP2_x").Length;
        _pointP2Orbit_x = new GameObject[_countPointOrbitP2x];
        if (_countPointOrbitP2x != 0)
        {
            _pointP2Orbit_x = GameObject.FindGameObjectsWithTag("OrbitP2_x");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_speedMoveAtom >= 0)
        {
            _speedMoveAtom -= Time.deltaTime;
        }

      
        

        //В атоме существует хотябы S1 орбита (первая), иначе атома нет.
        if (_pointS1Orbit != null) { 
            switch (_sequenceNumber)
            {
                case 1:

                    break;

                case 2:

                    break;

                case 3:

                    break;

                case 4:

                    break;

                case 5:

                    break;

                case 6:

                    break;

                case 7:

                    break;

                case 8:

                    break;

                case 9:

                    break;

                case 10:

                    break;

                case 11:

                    break;

                case 12:

                    break;

                case 13:

                    break;

                case 14:
                    if (_speedMoveAtom <= 0)
                    {
                        if (GameObject.FindGameObjectsWithTag("Electron").Length == 0)
                        {
                            //S1Orbit создание 1 electron
                            _numberRandPosition = Random.Range(0, _pointS1Orbit.Length);
                            Instantiate(_prefabElectron, _pointS1Orbit[_numberRandPosition].transform.position, Quaternion.identity);
                            _numberRandPosition2 = Random.Range(0, _pointS1Orbit.Length);
                            Instantiate(_prefabElectron, _pointS1Orbit[_numberRandPosition2].transform.position, Quaternion.identity);

                            //S2Orbit создание 1 electron
                            _numberRandPosition = Random.Range(0, _pointS2Orbit.Length);
                            Instantiate(_prefabElectron, _pointS2Orbit[_numberRandPosition].transform.position, Quaternion.identity);
                            //S2Orbit создание 2 electron
                            _numberRandPosition2 = Random.Range(0, _pointS2Orbit.Length);
                            Instantiate(_prefabElectron, _pointS2Orbit[_numberRandPosition2].transform.position, Quaternion.identity);


                            //P1Orbit_x создание 1 electron
                            _numberRandPosition = Random.Range(0, _pointP1Orbit_x.Length);
                            Instantiate(_prefabElectron, _pointP1Orbit_x[_numberRandPosition].transform.position, Quaternion.identity);
                            //P1Orbit_x создание 2 electron
                            _numberRandPosition2 = Random.Range(0, _pointP1Orbit_x.Length);
                            Instantiate(_prefabElectron, _pointP1Orbit_x[_numberRandPosition2].transform.position, Quaternion.identity);


                            //P1Orbit_y создание 1 electron
                            _numberRandPosition = Random.Range(0, _pointP1Orbit_y.Length);
                            Instantiate(_prefabElectron, _pointP1Orbit_y[_numberRandPosition].transform.position, Quaternion.identity);
                            //P1Orbit_y создание 2 electron
                            _numberRandPosition2 = Random.Range(0, _pointP1Orbit_y.Length);
                            Instantiate(_prefabElectron, _pointP1Orbit_y[_numberRandPosition2].transform.position, Quaternion.identity);


                            //P1Orbit_z создание 1 electron
                            _numberRandPosition = Random.Range(0, _pointP1Orbit_z.Length);
                            Instantiate(_prefabElectron, _pointP1Orbit_z[_numberRandPosition].transform.position, Quaternion.identity);
                            //P2Orbit_z создание 2 electron
                            _numberRandPosition2 = Random.Range(0, _pointP1Orbit_z.Length);
                            Instantiate(_prefabElectron, _pointP1Orbit_z[_numberRandPosition2].transform.position, Quaternion.identity);


                            //P2Orbit_x создание 1 electron
                            _numberRandPosition = Random.Range(0, _pointP2Orbit_x.Length);
                            Instantiate(_prefabElectron, _pointP2Orbit_x[_numberRandPosition].transform.position, Quaternion.identity);


                            foreach (var item in GameObject.FindGameObjectsWithTag("Electron"))
                            {
                                if (item.transform.parent != GameObject.Find("Atom").transform)
                                {
                                    item.transform.parent = GameObject.Find("Atom").transform;
                                }
                            }

                            _numberRandPosition = 0; // Обновление рандомного первого числа позиции
                            _numberRandPosition2 = 0; // Обновление рандомного второго числа позиции
                            _speedMoveAtom = _speedMoveAtomReset; //обновление счетчика времени методом Swap
                        }
                        else Destroy(GameObject.FindGameObjectWithTag("Electron"));
                       }
                    break;

                case 15:

                    break;
                default:
                    Debug.Log("Не получлось реализовать ElectronMove");
                    break;
            }
        }
    }
}
