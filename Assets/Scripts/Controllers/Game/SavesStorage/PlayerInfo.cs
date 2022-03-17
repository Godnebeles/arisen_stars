using System;

[Serializable]
public class PlayerInfo
{
    public int damage = 100;
    public HealthInfo healthInfo = new HealthInfo();
}

[Serializable]
public class HealthInfo
{
    public int healthPoints = 200;
}
