using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpButton : MonoBehaviour
{
    public TMP_Text weaponName;
    public TMP_Text weaponDescription;
    public Image weaponIcon;

    public Weapon assignedWeapon;
    public void ActivateButton(Weapon weapon)
    {
        weaponName.text = weapon.name;
        weaponDescription.text = weapon.stats[weapon.weaponLevel].descrription;
        weaponIcon.sprite = weapon.weaponImage;

        assignedWeapon = weapon;
    }

    public void SelectUpgrade()
    {
        assignedWeapon.LevelUp();
        UIController.Instance.LevelUpPanelClose();
    }
}
