using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public enum movatt{Attack, Moviment};
public class ComboSystem : MonoBehaviour
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

    
    [Header("Directions")]
    public List<string> MoveDirections;
    
    [Header("Types of attacks")]
    public List<string> AttackTypes;
    

    [Header("Attacks properties")]
    public List<GameInput> Attacks;

    [Header("combo properties")]
    public List<Combo> combos;

    
    [Header("Time to next attack")]
    public float ComboLeeway = 0.25f;

    [Header("Components")]
    public Animator anim;

    GameInput curAttack = null;
    ComboInput lastInput = null;

    List<int> currentCombos = new List<int>();
    float timer = 0;

    float leeway = 0;

    bool skip = false;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        PrimeCombo();
        
    }

    void PrimeCombo()
    {
        for(int i = 0; i < combos.Count; i++)
        {
            Combo c = combos[i];
            c.onInputted.AddListener(() => 
            {
                //chama a funcao de ataque com os combos do ataque
                skip = true;
                //Attack(c.comboAttack);
                Attack(c.inputs[c.inputs.Count]);
                ResetCombos();
            });
        }
    }

    // Update is called once per frame
    void Update()
    {


        if(curAttack != null) 
        {
            if(timer>0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                curAttack = null;
            }
            return;
        }


        if(currentCombos.Count>0)
        {
            leeway +=Time.deltaTime;

            if(leeway >= ComboLeeway)
            {
               if(lastInput != null)
               {
                    //Attack(GetAttackFromType(lastInput.Attacktype));
                    Attack(lastInput);
                    lastInput = null;
               } 

               ResetCombos();

            }
        }
        else{leeway = 0;}

        ComboInput input = null;

        for(int i = 0; i<Attacks.Count;i++)
        {
            if(Input.GetKeyDown(Attacks[i].KeyInput))
            {
                input = new ComboInput(Attacks[i].Attacktype);
            }
            if(input == null)
            {
                return;
            }
            
        }
        
        
        
        lastInput = input;

        List<int> remove = new List<int>();
        for(int i = 0; i<currentCombos.Count; i++)
        {
            Combo c = combos[currentCombos[i]];
            if(c.continueCombo(input))
            {
                leeway = 0;
            }
            else
            {
                remove.Add(i);
            }
        }

        if(skip)
        {
            skip = false;
            return;
        }

        for(int i = 0; i < combos.Count; i++)
        {
            if(currentCombos.Contains(i)) continue;
            if(combos[i].continueCombo(input))
            {
                currentCombos.Add(i);
                leeway = 0;
            }
            
        }

        foreach(int i in remove)
        {
            currentCombos.RemoveAt(i);
        }

        if(currentCombos.Count<=0)
        {
            //Attack(GetAttackFromType(input.Attacktype));
            Attack(input);
        }
    }

    GameInput GetAttackFromType(AttackEnum t)
    {
        for(int i = 0; i<Attacks.Count;i++)
        {
            if(t == Attacks[i].Attacktype)
            {
                return Attacks[i];
            }
            
        }
        return null;
        
        
    }
    
    void ResetCombos()
    {
        for(int i = 0;i < currentCombos.Count;i++)
        {
            Combo c = combos[currentCombos[i]];
            c.ResetCombo();

        }

        currentCombos.Clear();
    }

    /*void Attack(Attack att)
    {
        curAttack = att;
        timer = att.length;
        anim.Play(att.AnimationName, -1, 0);
    }*/

    void Attack(ComboInput att)
    {
        curAttack = GetAttackFromType(att.Attacktype);
        timer = att.length;
        if(att.MOorAT == movatt.Attack)
        {anim.Play(att.AnimationName, -1, 0);}
        
    }

}

[System.Serializable]
public class GameInput
{
    public string name;
    public float length = 0.5f;

    
    [Header("Choose if is for moviment or Attack")]

    public movatt MOorAT;


    [Header("this Moviment direction")]
    public AttackEnum direction;

    


    [Header("this attack type")]
    public AttackEnum Attacktype;

    public string AnimationName;


    [Header("Input")]
    public KeyCode KeyInput;
    
}


[System.Serializable]
public class ComboInput
{
    [Header("Choose if is for moviment or Attack")]

    public movatt MOorAT;

    public AttackEnum Attacktype;

    public AttackEnum direction;
    public string AnimationName;

    public float length = 0.5f;

    
    
    //Input de movimento para combos mais precisos

    public ComboInput(AttackEnum t)
    {
        Attacktype = t;
    }

    public bool isSameAs(ComboInput test)
    {
        return(Attacktype == test.Attacktype);//Adds && movement == test.movement
    }
    
}

[System.Serializable]
public class Combo
{
    public string name;

    
    public List<ComboInput> inputs;
    //public Attack comboAttack;

    
    public UnityEvent onInputted;

    int curInput = 0;

    public bool continueCombo(ComboInput i)
    {
        if(inputs[curInput].isSameAs(i)) 
        {
            curInput++;
            if(curInput >= inputs.Count)// Finaliza o input e agente deve fazer o ataque
            {
                onInputted.Invoke();
                curInput = 0;
            }
            return true;
        }
        else
        {
            curInput = 0;
            return false;
        }
    }

    public ComboInput currentCombo()
    {
        if(curInput >= inputs.Count){return null;}
        return inputs[curInput];
    }

    public void ResetCombo()
    {
        curInput = 0;
    }
}


