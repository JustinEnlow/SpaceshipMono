namespace Nlo.Math{
    public class PID{
        public float Output{get; private set;}
        public float Integral{get; private set;}
        public float Error{get; private set;}
        float _deltaTime;

        public PID(float deltaTime){_deltaTime = deltaTime;}

        public void Calculate(float setPoint, float measuredValue, float previousError, 
            float previousIntegral, PIDGain gain){
                var error = setPoint - measuredValue;
                Integral = previousIntegral + error * _deltaTime;
                var derivative = (error - previousError) / _deltaTime;      
                Error = error;
            
            Output = error * gain.p + Integral * gain.i + derivative * gain.d;
        }
    }
}