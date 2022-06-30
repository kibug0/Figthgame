using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentcombotest : MonoBehaviour
{
    #region InputSystem
    private PlayerInputActions playercontrol;

    private void Awake() 
    {
        playercontrol = new PlayerInputActions();
        
    }

    private void OnEnable()
    {
        playercontrol.Enable();
    }


    private void OnDisable()
    {
        playercontrol.Disable();
    }
    #endregion

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("up");
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetTrigger("right");
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetTrigger("left");
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetTrigger("down");
        }
        
    }
}
