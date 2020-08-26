namespace Nlo.Math{
    public class PID{
        float _output;
        float _integral;
        float _error;
        float _deltaTime;

        public PID(float deltaTime){_deltaTime = deltaTime;}

        public void Calculate(float setPoint, float measuredValue, float previousError, 
            float previousIntegral, PIDGain gain){
                var error = setPoint - measuredValue;
                _integral = previousIntegral + error * _deltaTime;
                var derivative = (error - previousError) / _deltaTime;      
                _error = error;
            
            _output = error * gain.p + _integral * gain.i + derivative * gain.d;
        }
        
        public float GetOutput(){return _output;}
        public float GetError(){return _error;}
        public float GetIntegral(){return _integral;}
    }
}