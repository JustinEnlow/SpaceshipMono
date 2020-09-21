namespace Nlo.Math{
    public class PID{
        public float Output{get; private set;}
        public float Integral{get; private set;}
        public float Error{get; private set;}

        public PID(){}

        public void Calculate(float setPoint, float measuredValue, float previousError, 
            float previousIntegral, PIDGain gain, float deltaTime){
                var error = setPoint - measuredValue;
                Integral = previousIntegral + error * deltaTime;
                var derivative = (error - previousError) / deltaTime;      
                Error = error;
            
            Output = error * gain.p + Integral * gain.i + derivative * gain.d;
        }
    }
}