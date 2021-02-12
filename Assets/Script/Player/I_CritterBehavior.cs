using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICtritterBehavior<T>
{
    //void  Attack(T damage);
    void DamageTake(T damage,bool hit);
    void Death(T hp , bool death);
    //void CheckStamina(T Stamina);
    //void CheckXp(T Xp);
}
