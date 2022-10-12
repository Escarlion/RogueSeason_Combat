using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] Player player;
    Transform leftWeaponController;
    Transform rightWeaponController;

    [HideInInspector] public bool leftWeaponActive = true;
    [HideInInspector] public bool rightWeaponActive = false;
    [HideInInspector] public bool canSwitchWeapon = true;
    [HideInInspector] public string[] command = new string[] { "Fire1", "Fire2" };
    [HideInInspector] public int commandIndex = 0;

    private void Start()
    {
        leftWeaponController = player.gameObject.transform.GetChild(0);
        rightWeaponController = player.gameObject.transform.GetChild(1);
    }

    //Fun��o Chamada pelos weapons Controler para dizer se pode ou n�o trocar a arma
    public void ReadyToSwitchWeapon()
    {
        canSwitchWeapon = true;
    }
    //Fun��o Chamada pelos weapons Controler para dizer se pode ou n�o trocar a arma
    public void NotReadyToSwitchWeapon()
    {
        canSwitchWeapon = false;
    }

    //Ativa a arma esquerda caso bot�o esquerdo seja pressionado
    public void LeftWeaponConfiguration()
    {
        if (leftWeaponActive != true)
        {
            rightWeaponController.gameObject.SetActive(false);
            rightWeaponActive = false;
            leftWeaponController.gameObject.SetActive(true);
            leftWeaponActive = true;
            ChangeCommand(0);
        }
    }
    //Ativa a arma direita caso bot�o direito seja pressionado
    public void RightWeaponConfiguration()
    {
        if (rightWeaponActive != true)
        {
            leftWeaponController.gameObject.SetActive(false);
            leftWeaponActive = false;
            rightWeaponController.gameObject.SetActive(true);
            rightWeaponActive = true;
            ChangeCommand(1);
        }
    }
    //Muda o bot�o de ataque no manager
    void ChangeCommand(int value)
    {
        commandIndex = value;
    }
}
