using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

//Enum criado para definir se o Gameinput ou o botao selecionado no momento e um botao de movimento ou de ataque
public enum movatt{Attack, Moviment};

public class ComboSystem : MonoBehaviour
{
    //Parte para o uso de inputSystem
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

    
    //Uma lista de strings para criar os enuns que iram se referir as direcoes para serem usadas nos combos
    [Header("Directions")]
    public List<string> MoveDirections;
    
    //Os tipos de ataques que iram existir para serem usados como comparativos nos combos
    [Header("Types of attacks")]
    public List<string> AttackTypes;
    

    //Aki vc cria uma lista das propriedades de cada um dos botoes criados como o tipo do ataque e qual botao ele vai usar para ser ativado
    [Header("Input properties")]
    public List<GameInput> Inputproperties;


    //Nessa lista vc ira fazer os combos e suas sequencia podendo fazer mais de um combo
    [Header("combo properties")]
    public List<Combo> combos;

    //Esse vai ser um delay que ira ser usado para definir o tempo entre os ataques quando o ComboLeeway for igual ao Leeway o combo acaba
    [Header("Time to next attack")]
    public float ComboLeeway = 0.25f;


    [Header("Components")]
    //O animator que sera usado para ativar as animacoes
    public Animator anim;

    //Essa variavel ira marcar e dizer qual GameInput ou ataque esta ativado no momento
    GameInput curAttack = null;

    //Essa e para saber qual o ultimo comboinput foi usado. Os comboinputs sao a sequencia que ira estar dentro do combo e eles sao semelahntes aos Gameinputs pq eles seram comparados para saber que o gameinput clicado sera o mesmo que o comboinput na sequancia dos combos
    ComboInput lastInput = null;

    //Um int para saber em qual qual esta no momento
    List<int> currentCombos = new List<int>();

    //O timer para ir contando o tempo entre combos quando ele acaba e vc nao apertou o proximo botao do combo o combo reinicia
    float timer = 0;

    //O contador do delaay dos ataques que ira mudando ate o tempo certo
    float leeway = 0;

    //Quando o ultimo ataque for ativado esse bool ira ficar igual a true e ira retornar o update
    bool skip = false;
    

    void Start()
    {
        //Seta o anim com o animator desse gameobject
        anim=GetComponent<Animator>();

        //Essa funcao ira colocar em cada OnInputted as linhas de codigo que ira deixa o skip = true, chamar a funcao de attack e a funcao de resetCombos
        PrimeCombo();
        
    }

    void PrimeCombo()
    {
        
        for(int i = 0; i < combos.Count; i++)
        {
            
            //setando o combo atual(i) da lista de combos na variavel c
            Combo c = combos[i];
            //coloca no unityeventy chamando onInputted a linha de codigo abaixo
            c.onInputted.AddListener(() => 
            {
                //skip fica igual a true para terminar o uodade
                skip = true;

                //Esse era uma linha de codigo do codigo original que eu deixei comentada para referencias
                //Attack(c.comboAttack);

                

                
                //chama a funcao Attack que ira ativar a animcao e definir outras coisas
                Attack(c.inputs[c.inputs.Count-1]);

                //Reseta o combo
                ResetCombos();
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < currentCombos.Count; i++)
        {
            Debug.Log(currentCombos[i]);
        }


        //Se o CurAttack for diferente a null
        if(curAttack != null) 
        {
            //Se o Timer for mairo que 0
            if(timer>0)
            {
                //O timer vai diminuir graduamente pelo tempo exitente
                timer -= Time.deltaTime;
            }

            //Se o if nao for ativado
            else
            {
                
                //Seta o CurAttack para null
                curAttack = null;
            }

            //retorna a funcao
            return;
        }

        //Se o currentCombos.Count for maior que 0
        if(currentCombos.Count>0)
        {
            //O leeway sera almentado pelo tempo existente
            leeway +=Time.deltaTime;

            //Se o leeway for maior ou igual ao ComboLeeway
            if(leeway >= ComboLeeway)
            {
                //se o lastInput for diferente de null
               if(lastInput != null)
               {
                    //Esse era uma linha de codigo do codigo original que eu deixei comentada para referencias
                    //Attack(GetAttackFromType(lastInput.Attacktype));

                    
                    
                    //chama a funcao Attack que ira ativar a animcao e definir outras coisas
                    
                    Attack(lastInput);

                    //Seta o lastInput para null
                    lastInput = null;
               } 

                //Reseta os combos por que acabou o tempo
               ResetCombos();

            }
        }

        //Se o if nao ativar
        else
        {
            //Seta o leeway para 0
            leeway = 0;
        }

        //Cria um ComboInput vazio para o input ser referente ao input apertado
        ComboInput input = null;

        //For que vai rodar para todos da lista Inputproperties
        for(int i = 0; i<Inputproperties.Count;i++)
        {
            //Debug.Log(i);

            //Se o botao apertado for de alguns dos botoes setados em alguns dos Gameinputs da lista Inputproperties
            if(Input.GetKeyDown(Inputproperties[i].KeyInput))
            {
                //Seta no Input um novo ComboInput com o mesmo attack.Type do Gameinput apertado nomomento
                input = new ComboInput(Inputproperties[i].Attacktype);
                
                
            }
            
            
        }

        //Se O input for igual a null
        if(input == null)
        {
            //Retorna o update
            return;
        }
        
        
        //Fazendo o LastInput ser igual ao input atual que foi apertado
        lastInput = input;
        

        lastInput.Activate = false;


        //Uma lista de int que ira colocar todos os combos passados
        List<int> remove = new List<int>();

        for(int i = 0; i<currentCombos.Count; i++)
        {
            //Uma variavel Combo chamada c que ira receber uma das variaveis da lista combos
            Combo c = combos[currentCombos[i]];

            //Se a funcao continueCombo usando o input como referencia retornar true
            if(c.continueCombo(input))
            {
                //O leeway fica igual a 0
                leeway = 0;
            }
            //Se o if nao ativar
            else
            {
                //Ele coloca o int i atual do looping na lista remove 
                remove.Add(i);
            }
        }

        //Se o skip for igual a true
        if(skip)
        {
            //O skip se torna false
            skip = false;

            //Retorna o update
            return;
        }

        

        for(int i = 0; i < combos.Count; i++)
        {
            
            //Se na lista int currentCombos contiver dentro dela o int i atual ele ativara o continue que ira pular ignorar todas as linhas a baixo e começar o proximo looping 
            if(currentCombos.Contains(i))
            { //Problema ele esta pulando o 0 e ja se tornando 1
                continue;
            }
            
            //Se a funcao continueCombo usando o input como referencia retornar true
            if(combos[i].continueCombo(input))
            {
                
                //Ele coloca na lista currentCombos o int i atual do looping
                currentCombos.Add(i);

                //Ele deixa o leeway igual a 0
                leeway = 0;
            }
            
        }

        foreach(int i in remove)
        {
            //Remove todos os ints que existem dentro da lista remove da lista currentCombos
            currentCombos.RemoveAt(i);
        }

        //Se o currentCombos.Count for menor o igual a 0
        if(currentCombos.Count<=0)
        {
            //Esse era uma linha de codigo do codigo original que eu deixei comentada para referencias
            //Attack(GetAttackFromType(input.Attacktype));
            
            
            //Chama a funcao Attack
            Attack(input);
        }
    }


    
    //Funcao criada para resetar os combos
    void ResetCombos()
    {
        for(int i = 0;i < currentCombos.Count;i++)
        {
            //Variavel criada com a classe Combo para receber o combos baseado no currentcombos
            Combo c = combos[currentCombos[i]];

            

            //Chama a funcao do c atual que reseta o combo
            c.ResetCombo();

        }

        //Esvazia a lista de int currentCombos
        currentCombos.Clear();
    }

    //Esse era uma linha de codigo do codigo original que eu deixei comentada para referencias
    /*void Attack(Attack att)
    {
        curAttack = att;
        timer = att.length;
        anim.Play(att.AnimationName, -1, 0);
    }*/

    //Funcao do ataque que ira ativar a animacao do ataque
    void Attack(ComboInput att)
    {
        //Seta no curAttack usando a funcao GetAttackFromType para colocar o GameInput baseado no mesmo AttackType do Comboinput atual
        curAttack = GetAttackFromType(att.Attacktype);

        //Seta o tempo com o tempo do Comboinput atual
        timer = att.length;


        //Ele peregunta se o ComboInput que foi apertado e um de movimento ou de ataque
        if(att.MOorAT == movatt.Attack)
        {
            Debug.Log(att.AnimationName);
            //Se for de ataque ele ativa a animacao pelo nome dela que esta nesse ComboInput
            anim.Play(att.AnimationName, -1, 0);
            
        }
        
    }



    //Funcao que chama um gameInput baseado no AttackEnum recebido
    GameInput GetAttackFromType(AttackEnum t)
    {
        for(int i = 0; i<Inputproperties.Count;i++)
        {
            //Se o t for igual ao mesmo Attacktype do Inputproperties defenido com o int i atual
            if(t == Inputproperties[i].Attacktype)
            {
                
                //Ele retorna esse GameInput Inputproperties
                return Inputproperties[i];
            }
            
        }
        //Se nao retornar nada antes ele retorna um null
        return null;
        
        
    }

    

}





//Classe criada para definir as propriedades do GameInput
[System.Serializable]
public class GameInput
{
    //O nome do Gameinput
    public string name;
    

    //O botao ou tecla que ira ativar esse GameInput
    [Header("KeyInput")]
    public KeyCode KeyInput;

    //Enum para definir se esse GameInput e um de movimento ou um de ataque
    [Header("Choose if is for moviment or Attack")]
    public movatt MOorAT;


    //Enum criado para no caso esse for um GameInput de movimento definir para qual direcao esse movimento ele leva
    [Header("this Moviment direction")]
    public DirectionEnum direction;

    

    //Enum criado para caso esse for um GameInput de ataque qual tipo de ataque ele seria
    [Header("this attack type")]
    public AttackEnum Attacktype;
    
}

//Classe dos inputs que seram colocados dentros dos combos
[System.Serializable]
public class ComboInput
{
    //Bool para eu poder ver se esta ativo o input no momento
    public bool Activate;

    //Nome do ComboInput atual
    public string name;

    //Definir se esse ComboInput vai ser de ataque ou movimento
    [Header("Choose if this Input is for moviment or Attack")]
    public movatt MOorAT;

    
    //Enum criado para no caso esse for um GameInput de movimento definir para qual direcao esse movimento ele leva
    [Header("this Moviment direction")]
    public DirectionEnum direction;

    

    //Enum criado para caso esse for um GameInput de ataque qual tipo de ataque ele seria
    [Header("this attack type")]
    public AttackEnum Attacktype;
    
    //A string que vai ter o nome desse ComboInput que sera ativada se for um ataque e quando esse ataque for ativado
    public string AnimationName;

    //Tempo do ataque
    public float length = 0.5f;

    
    
    
    //Funcao para quando receber um AttackEnum chamado t que ira subistituir o Attacktype desse ComboInput
    public ComboInput(AttackEnum t)
    {
        Attacktype = t;
    }

    //Uma funca que retorna um bool baseado num ComboInput para saber se o ComboInput e esse ComboInput sao iguais
    public bool isSameAs(ComboInput test)
    {
        return(Attacktype == test.Attacktype);//retorna um bool se forem iguais
    }
    
}

//Uma classe para criar os combos
[System.Serializable]
public class Combo
{
    //Nome do combo
    public string name;

    //A lista dos inputs que seram a sequencia de inputs que definira esse combo
    public List<ComboInput> inputs;

    //Esse era uma linha de codigo do codigo original que eu deixei comentada para referencias
    //public Attack comboAttack;

    //O Evento que vai ser chamado
    public UnityEvent onInputted;

    //O Int que representa o ComboInput da lista inputs que esta ativado no momento
    int curInput = 0;

    //Funcao que retorna um bool baseado no ComboInput que ela receber
    public bool continueCombo(ComboInput i)
    {
        //Se o input da lista inputs for igual ao ComboInput recebida
        if(inputs[curInput].isSameAs(i)) 
        {
            //Aumenta +1 no int curInput
            curInput++;

            i.AnimationName = inputs[curInput].AnimationName;
            inputs[curInput].Activate = true;
            

            //Se o curInput for maior ou igual a o inputs.Count
            if(curInput >= inputs.Count)
            {
                
                //Eles chama o evento que esta no onInputted
                onInputted.Invoke();
                
                //Ele torna o curInput para 0
                curInput = 0;
            }

            //Retorna true
            return true;
        }
        //Se o if nao for ativado
        else
        {
            //curInput for igual a 0
            curInput = 0;

            //Retorna false
            return false;
        }
    }

    //Funcao que retorna ComboInput
    public ComboInput currentCombo()
    {
        //Se o curInput for maior ou igual ao inputs.Count retorna o ComboInput null
        if(curInput >= inputs.Count){return null;}

        //Retorna o ComboInput da lista inputs baseado no int curInput
        return inputs[curInput];
    }

    //funcao que reseta o combo
    public void ResetCombo()
    {
        

        //Deixando o curinput igual a 0
        curInput = 0;
    }
}


