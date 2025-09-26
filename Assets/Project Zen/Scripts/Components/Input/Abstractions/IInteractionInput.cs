using UnityEngine.Events;

public interface IInteractionInput
{
    //public event UnityAction OnWeaponSwitch; // сделать смену оружия на ту же кнопку что и взаимодействие или на отдельную (?). Пока что на ту же сделал

    public event UnityAction OnInteractPressed;
}
