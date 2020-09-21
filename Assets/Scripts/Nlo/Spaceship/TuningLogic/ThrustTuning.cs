using Nlo.Spaceship.Interfaces;

namespace Nlo.Spaceship{
	public class ThrustTuning : ITune {
		ShipStats _stats;
		string[] _thrust = new string[6];
		int _main = 0; //incrementor for _thrust[]
		float _value; 
		int[] _increments = new int[5];
		int _increment = 0; //incrementor for _increments[]

		public ThrustTuning(ShipStats stats){
			_stats = stats;

			_thrust[0] = "LatThrst";
			_thrust[1] = "VerThrst";
			_thrust[2] = "LonThrst";
			_thrust[3] = "PitThrst";
			_thrust[4] = "YawThrst";
			_thrust[5] = "RolThrst";

			_increments[0] = 1;
			_increments[1] = 10;
			_increments[2] = 100;
			_increments[3] = 1000;
			_increments[4] = 10000;
		}

		public void MainUp(){if(_main < _thrust.Length - 1){_main++;}}
		public void MainDown(){if(_main > 0){_main--;}}

		public void ValueUp(){
			if(_value <= _stats.LateralMaxThrust - _increments[_increment]){
				if(_thrust[_main] == _thrust[0]){
					_stats.LateralDesiredThrust += _increments[_increment];
				}
			}
			if(_value <= _stats.VerticalMaxThrust - _increments[_increment]){
				if(_thrust[_main] == _thrust[1]){
					_stats.VerticalDesiredThrust += _increments[_increment];
				}
			}
			if(_value <= _stats.LongitudinalMaxThrust - _increments[_increment]){
				if(_thrust[_main] == _thrust[2]){
					_stats.LongitudinalDesiredThrust += _increments[_increment];
				}
			}
			if(_value <= _stats.PitchMaxThrust - _increments[_increment]){
				if(_thrust[_main] == _thrust[3]){
					_stats.PitchDesiredThrust += _increments[_increment];
				}
			}
			if(_value <= _stats.YawMaxThrust - _increments[_increment]){
				if(_thrust[_main] == _thrust[4]){
					_stats.YawDesiredThrust += _increments[_increment];
				}
			}
			if(_value <= _stats.RollMaxThrust - _increments[_increment]){
				if(_thrust[_main] == _thrust[5]){
					_stats.RollDesiredThrust += _increments[_increment];
				}
			}
		}
		public void ValueDown(){
			if(_value >= 0 + _increments[_increment]){
				_value -= _increments[_increment];

				if(_thrust[_main] == _thrust[0]){
					_stats.LateralDesiredThrust = _value;
				}
				else if(_thrust[_main] == _thrust[1]){
					_stats.VerticalDesiredThrust = _value;
				}
				else if(_thrust[_main] == _thrust[2]){
					_stats.LongitudinalDesiredThrust = _value;
				}
				else if(_thrust[_main] == _thrust[3]){
					_stats.PitchDesiredThrust = _value;
				}
				else if(_thrust[_main] == _thrust[4]){
					_stats.YawDesiredThrust = _value;
				}
				else if(_thrust[_main] == _thrust[5]){
					_stats.RollDesiredThrust = _value;
				}
			}
		}

		public void IncrementUp(){if(_increment < _increments.Length - 1){_increment++;}}
		public void IncrementDown(){if(_increment > 0){_increment--;}}

		public string Name{get{UpdateValue(); return _thrust[_main];}}
		public string Value{get{UpdateValue(); return _value.ToString();}}
		public string Increment{get{return _increments[_increment].ToString();}}
		
		void UpdateValue(){
			if	   (_thrust[_main] == _thrust[0]){_value = _stats.LateralDesiredThrust;}
			else if(_thrust[_main] == _thrust[1]){_value = _stats.VerticalDesiredThrust;}
			else if(_thrust[_main] == _thrust[2]){_value = _stats.LongitudinalDesiredThrust;}
			else if(_thrust[_main] == _thrust[3]){_value = _stats.PitchDesiredThrust;}
			else if(_thrust[_main] == _thrust[4]){_value = _stats.YawDesiredThrust;}
			else if(_thrust[_main] == _thrust[5]){_value = _stats.RollDesiredThrust;}
		}
	}
}