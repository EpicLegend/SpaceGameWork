
 public class Messenger
{
    public delegate void MethodCounainer();
    static public event MethodCounainer EnHit;
    static public event MethodCounainer ShipConMeteor;
    static public event MethodCounainer RocketDesMet;
    static public event MethodCounainer ShipUsedPo;

    // событие на удар ракеты
    static public void EnemyHit()
    {
        EnHit();
    }

    // событие на прикосновение корабля с метеоритом
    static public void ShipContactMeteorite()
    {
        ShipConMeteor();
    }

    static public void RocketDestroyMeteorite()
    {
        RocketDesMet();
    }

    static public void ShipUsedPortal()
    {
        ShipUsedPo();
    } 


}
