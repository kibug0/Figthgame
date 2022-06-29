using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum AttackType{punchheavyAttack = 0, punchlightAttack = 1, kickheavyAttack = 2, kicklighAttack = 3}
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

    [Header("Inputs")]
    public KeyCode punchheavykey;
    public KeyCode punchlightkey;
    public KeyCode kickheavykey;
    public KeyCode kicklightkey;
    
    [Header("Attacks")]
    public Attack punchheavyAttack;
    public Attack punchlightAttack;
    public Attack kickheavyAttack;
    public Attack kicklighAttack;

    public List<Combo> combos;

    public float ComboLeeway = 0.25f;

    [Header("Components")]
    public Animator anim;

    Attack curAttack = null;
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
                Attack(c.comboAttack);
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
                    Attack(GetAttackFromType(lastInput.type));
                    lastInput = null;
               } 

               ResetCombos();

            }
        }
        else{leeway = 0;}

        ComboInput input = null;
        
        if(playercontrol.Player.HeavyPunch.WasPerformedThisFrame())
        {
            input = new ComboInput(AttackType.punchheavyAttack);
        }
        if(playercontrol.Player.WeakPunch.WasPerformedThisFrame())
        {
            input = new ComboInput(AttackType.punchlightAttack);
        }
        if(playercontrol.Player.HeavyKick.WasPerformedThisFrame())
        {
            input = new ComboInput(AttackType.kickheavyAttack);
        }
        if(playercontrol.Player.WeakKick.WasPerformedThisFrame())
        {
            input = new ComboInput(AttackType.kicklighAttack);
        }
        if(input == null)
        {
            return;
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
            Attack(GetAttackFromType(input.type ));
        }
    }

    Attack GetAttackFromType(AttackType t)
    {
        if(t == AttackType.punchheavyAttack)
        {
            return punchheavyAttack;
        }
        if(t == AttackType.punchlightAttack)
        {
            return punchlightAttack;
        }
        if(t == AttackType.kickheavyAttack)
        {
            return kickheavyAttack;
        }
        if(t == AttackType.kicklighAttack)
        {
            return kicklighAttack;
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

    void Attack(Attack att)
    {
        curAttack = att;
        timer = att.length;
        anim.Play(att.name, -1, 0);
    }

    

}

[System.Serializable]
public class Attack
{
    public string name;
    public float length;
}

[System.Serializable]
public class ComboInput
{
    public AttackType type;
    //Input de movimento para combos mais precisos

    public ComboInput(AttackType t)
    {
        type = t;
    }

    public bool isSameAs(ComboInput test)
    {
        return(type == test.type);//Adds && movement == test.movement
    }
    
}

[System.Serializable]
public class Combo
{
    public string name;
    public List<ComboInput> inputs;
    public Attack comboAttack;
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
