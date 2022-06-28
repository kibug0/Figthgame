using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboHit : MonoBehaviour
{
    //animator
    public Animator anim;

    //Variaveis contaveis
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 0.5f;

    private int ComboFases = 1;

    public int MaxComboFases = 3;

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
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<Animator>() != null)
        {
            anim = GetComponent<Animator>();
        }
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
            anim.SetBool("Attack", false);
            ComboFases = 1;
        }

        if(playercontrol.Player.WeakPunch.triggered && noOfClicks!=MaxComboFases)
        {
            Debug.Log("Soco");
            lastClickedTime = Time.time;
            noOfClicks++;

            if(noOfClicks == 1)
            {
                anim.SetBool("Attack", true);
            }
            noOfClicks = Mathf.Clamp(noOfClicks,0,MaxComboFases);
        } 
        else
        {
            anim.SetBool("Attack", false);
        }
        anim.SetInteger("ComboFase", ComboFases);
        
        
    }

    public void return1()
    {
        Debug.Log("Soco");
        if(noOfClicks > ComboFases)
        {
            ComboFases = noOfClicks;
            anim.SetBool("Attack", true);
        }
        else
        {
            noOfClicks = 0;
            anim.SetBool("Attack", false);
            ComboFases = 1;
        }
        
        
        
    }

    
}
