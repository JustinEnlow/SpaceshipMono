using UnityEngine;

public interface IHaveHealth{
    float TotalHealth {get;}
    float CurrentHealth {get;}
    float ArmorAmount {get;}
    void ModifyHealth(float _amount);
}