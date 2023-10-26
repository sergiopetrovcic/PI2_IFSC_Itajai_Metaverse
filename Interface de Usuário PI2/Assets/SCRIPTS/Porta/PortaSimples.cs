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
        if(Input.GetKeyDown(KeyCode.O) &&_colidindo)
        {
            _PortaAberta=true;
            _animator.SetTrigger("Abrir");
        }
    }
    private void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.CompareTag("Player"))
        {
            _colidindo=true;
        }
    }
    private void OnTriggerExit(Collider _col)
    {
        if(_col.gameObject.CompareTag("Player"))
        {
            if(_PortaAberta)
            {
                _animator.SetTrigger("Fechar");
            }
            _colidindo = false;
        }
    }
}
