public interface IHaveVelocity{
    // meters per second
    float lateralMaxVelocity{get;}
    float verticalMaxVelocity{get;}
    float longitudinalMaxVelocity{get;}
    // degrees per second
    float pitchMaxVelocity{get;}
    float yawMaxVelocity{get;}
    float rollMaxVelocity{get;}
}