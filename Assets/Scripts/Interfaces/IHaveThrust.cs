public interface IHaveThrust{
    float lateralMaxThrust{get;}
    float verticalMaxThrust{get;}
    float longitudinalMaxThrust{get;}
    float lateralDesiredThrust{get;}
    float verticalDesiredThrust{get;}
    float longitudinalDesiredThrust{get;}
    float pitchMaxThrust{get;}
    float yawMaxThrust{get;}
    float rollMaxThrust{get;}
    float pitchDesiredThrust{get;}
    float yawDesiredThrust{get;}
    float rollDesiredThrust{get;}
}