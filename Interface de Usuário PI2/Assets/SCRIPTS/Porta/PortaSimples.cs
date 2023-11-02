using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public Animator _animator;
    private bool _colidindo;
    private bool _PortaAberta = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            _PortaAberta = true;
            _animator.SetTrigger("Abrir");
        }
        if (Input.GetKey(KeyCode.C))
        {
            _PortaAberta = true;
            _animator.SetTrigger("Fechar");
        }
    }
}
