using UnityEngine;

public class Sensors : MonoBehaviour
{
    [Header("Ground & Wall Sensors")]
    public Sensor_HeroKnight Ground { get; private set; }
    public Sensor_HeroKnight WallR1 { get; private set; }
    public Sensor_HeroKnight WallR2 { get; private set; }
    public Sensor_HeroKnight WallL1 { get; private set; }
    public Sensor_HeroKnight WallL2 { get; private set; }

    void Awake()
    {
        Ground = transform.Find("GroundSensor").GetComponent<Sensor_HeroKnight>();
        WallR1 = transform.Find("WallSensor_R1").GetComponent<Sensor_HeroKnight>();
        WallR2 = transform.Find("WallSensor_R2").GetComponent<Sensor_HeroKnight>();
        WallL1 = transform.Find("WallSensor_L1").GetComponent<Sensor_HeroKnight>();
        WallL2 = transform.Find("WallSensor_L2").GetComponent<Sensor_HeroKnight>();
    }

    public bool IsWallSliding()
    {
        return (WallR1.State() && WallR2.State()) || (WallL1.State() && WallL2.State());
    }
}
