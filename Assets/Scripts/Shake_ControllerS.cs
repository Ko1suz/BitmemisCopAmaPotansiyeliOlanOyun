using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake_ControllerS : MonoBehaviour
{
    [SerializeField]private Transform cam;
    private Vector3 startPos;
    [SerializeField]private float shakePower;
    [SerializeField]private float shakeDuration;
    private float initialDuration; // başlangıç süresi
    [SerializeField]private float downAmount;// bitiş süresi
    static public bool isShake = false;
    [SerializeField] Transform Player;


    void Start()
    {
        cam = Camera.main.transform;
       
        initialDuration = shakeDuration;
    }

    
    
    public ControlS controlS;
    void Update()
    {
        startPos = CameraSystemS.KameraPozisyonu.position;
        if (isShake && controlS.Testere==false)
        {
            if (shakeDuration>0)
            {
                cam.localPosition = startPos + Random.insideUnitSphere * shakePower;
                shakeDuration-=downAmount*Time.deltaTime;
            }
            else
            {
                isShake = false;
                cam.localPosition =  startPos;
                shakeDuration = initialDuration;
            }
        }
    }
}
