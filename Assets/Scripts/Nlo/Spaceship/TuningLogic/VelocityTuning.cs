using Nlo.Spaceship.Interfaces;

namespace Nlo.Spaceship{
	public class VelocityTuning : ITune {
		ShipStats _stats;
		string[] _velocity = new string[6];
		int _main = 0; //incrementor for _velocity[]
		float _value; 
		int[] _increments = new int[5];
		int _increment = 0; //incrementor for _increments[]

		public VelocityTuning(ShipStats stats){
			_stats = stats;

			_velocity[0] = "Lat Vel";
			_velocity[1] = "Ver Vel";
			_velocity[2] = "Lon Vel";
			_velocity[3] = "Pit Vel";
			_velocity[4] = "Yaw Vel";
			_velocity[5] = "Rol Vel";

			_increments[0] = 1;
			_increments[1] = 5;
			_increments[2] = 10;
			_increments[3] = 100;
			_increments[4] = 1000;
		}

		public void MainUp(){if(_main < _velocity.Length - 1){_main++;}}
		public void MainDown(){if(_main > 0){_main--;}}

		public void ValueUp(){
			if(_value <= 10000 - _increments[_increment]){
				_value += _increments[_increment];

				if     (_velocity[_main] == _velocity[0]){_stats.LateralMaxVelocity = _value;}
				else if(_velocity[_main] == _velocity[1]){_stats.VerticalMaxVelocity = _value;}
				else if(_velocity[_main] == _velocity[2]){_stats.LongitudinalMaxVelocity = _value;}
				else if(_velocity[_main] == _velocity[3]){_stats.PitchMaxVelocity = _value;}
				else if(_velocity[_main] == _velocity[4]){_stats.YawMaxVelocity = _value;}
				else if(_velocity[_main] == _velocity[5]){_stats.RollMaxVelocity = _value;}
			}
		}
		public void ValueDown(){
			if(_value > 0 + _increments[_increment]){
				_value -= _increments[_increment];

				if     (_velocity[_main] == _velocity[0]){_stats.LateralMaxVelocity = _value;}
				else if(_velocity[_main] == _velocity[1]){_stats.VerticalMaxVelocity = _value;}
				else if(_velocity[_main] == _velocity[2]){_stats.LongitudinalMaxVelocity = _value;}
				else if(_velocity[_main] == _velocity[3]){_stats.PitchMaxVelocity = _value;}
				else if(_velocity[_main] == _velocity[4]){_stats.YawMaxVelocity = _value;}
				else if(_velocity[_main] == _velocity[5]){_stats.RollMaxVelocity = _value;}
			}
		}

		public void IncrementUp(){if(_increment < _increments.Length - 1){_increment++;}}
		public void IncrementDown(){if(_increment > 0){_increment--;}}

		public string Name{get{UpdateValue(); return _velocity[_main];}}
		public string Value{get{UpdateValue(); return _value.ToString();}}
		public string Increment{get{return _increments[_increment].ToString();}}
		
		void UpdateValue(){
			if     (_velocity[_main] == _velocity[0]){_value = _stats.LateralMaxVelocity;}
			else if(_velocity[_main] == _velocity[1]){_value = _stats.VerticalMaxVelocity;}
			else if(_velocity[_main] == _velocity[2]){_value = _stats.LongitudinalMaxVelocity;}
			else if(_velocity[_main] == _velocity[3]){_value = _stats.PitchMaxVelocity;}
			else if(_velocity[_main] == _velocity[4]){_value = _stats.YawMaxVelocity;}
			else if(_velocity[_main] == _velocity[5]){_value = _stats.RollMaxVelocity;}
		}
	}
}