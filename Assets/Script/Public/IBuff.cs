

public interface IBuff 
{
    void BuffMaxHealthUp(float UpMaxHealthValue);
    void BuffMaxSpeedUp(float UpSpeedValue);
    void BuffDamageUp(float UpDamegeValue);
    void BuffEnableAttack();
    void BuffHealthUp(float UpHealthValue);
    bool BuffISNeedRecovers();
}
