using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorAnimaciones : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animatorComponent;
    public const string WRAP_OUT = "WrapOut";
    public const string WRAP_IN = "WrapIn";
    // Start is called before the first frame update
    void Start()
    {
        animatorComponent = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            animatorComponent.Play(WRAP_IN);
        }
        if (Input.GetKey(KeyCode.O))
        {
            animatorComponent.Play(WRAP_OUT);
        }
    }
}

