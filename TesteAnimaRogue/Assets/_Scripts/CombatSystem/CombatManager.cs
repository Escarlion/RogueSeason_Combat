using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    //Objetos
    [SerializeField] Player player;
    Transform leftWeaponController;
    Transform rightWeaponController;
    MeleeWeaponController meleeCheck;
    RangedWeaponController rangedCheck;

    //Variaveis
    [HideInInspector] public string[] command = new string[] { "Fire1", "Fire2" };
    [HideInInspector] public int commandIndex = 0;
    [HideInInspector] public int activeWeaponDamage;
    [HideInInspector] public bool leftWeaponActive = true;
    [HideInInspector] public bool rightWeaponActive = false;
    [HideInInspector] public bool canSwitchWeapon = true;
    int LeftWeaponDamage = 0, RightWeaponDamage = 0;
    
    private void Start()
    {
        leftWeaponController = player.gameObject.transform.GetChild(0);
        rightWeaponController = player.gameObject.transform.GetChild(1);
        GetWeaponDamage(); //Detecta o dano da arma ativa no começo do jogo
    }

    //Função Chamada pelos weapons Controler para dizer se pode ou não trocar a arma
    public void ReadyToSwitchWeapon()
    {
        canSwitchWeapon = true;
    }
    //Função Chamada pelos weapons Controler para dizer se pode ou não trocar a arma
    public void NotReadyToSwitchWeapon()
    {
        canSwitchWeapon = false;
    }

    //Ativa a arma esquerda caso botão esquerdo seja pressionado
    public void LeftWeaponConfiguration()
    {
        if (leftWeaponActive != true)
        {
            LeftWeaponActivate();
        }
        GetWeaponDamage();
    }
    //Ativa a arma direita caso botão direito seja pressionado
    public void RightWeaponConfiguration()
    {
        if (rightWeaponActive != true)
        {
            RightWeaponActivate();
        }
        GetWeaponDamage();
    }
    //Muda o botão de ataque no manager
    void ChangeCommand(int value)
    {
        commandIndex = value;
    }

    // Ativa e desetiva as armas de acordo com o comando pressionado (chamada pela classe Player)
    void RightWeaponActivate()
    {
        leftWeaponController.gameObject.SetActive(false);
        leftWeaponActive = false;
        rightWeaponController.gameObject.SetActive(true);
        rightWeaponActive = true;
        ChangeCommand(1);
    }
    void LeftWeaponActivate()
    {
        rightWeaponController.gameObject.SetActive(false);
        rightWeaponActive = false;
        leftWeaponController.gameObject.SetActive(true);
        leftWeaponActive = true;
        ChangeCommand(0);
    }

    //Verifica o tipo da arma, assim pegando o dano que foi inserido nela
    void GetWeaponDamage()
    {
        if(leftWeaponActive == true)
        {
            meleeCheck = player.GetComponentInChildren<MeleeWeaponController>();
            if (meleeCheck == null)
            {
                rangedCheck = player.GetComponentInChildren<RangedWeaponController>();
                LeftWeaponDamage = rangedCheck.GetDamage();
            }
            else
            {
                LeftWeaponDamage = meleeCheck.GetDamage();
            }
        }
        if(rightWeaponActive == true)
        {
            meleeCheck = player.GetComponentInChildren<MeleeWeaponController>();
            if (meleeCheck == null)
            {
                rangedCheck = player.GetComponentInChildren<RangedWeaponController>();
                RightWeaponDamage = rangedCheck.GetDamage();
            }
            else
            {
                RightWeaponDamage = meleeCheck.GetDamage();
            }
        }
    }

    //Determina o dano da arma atual, é usado por outra classes
    public int GetActiveWeaponDamage()
    {
        if (leftWeaponActive == true)
        {
            activeWeaponDamage = LeftWeaponDamage;
        }
        if (rightWeaponActive == true)
        {
            activeWeaponDamage = RightWeaponDamage;
        }
        return activeWeaponDamage;
    }
}
