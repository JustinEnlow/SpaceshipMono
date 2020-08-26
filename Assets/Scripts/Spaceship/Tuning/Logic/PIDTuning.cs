namespace Nlo.Tuning{
	public class PIDTuning : ITune {
		ShipStats _stats;
		string[] _pids = new string[18];
		int _main = 0; //incrementor for _pids[]
		float _value; 
		float[] _increments = new float[5];
		int _increment = 0; //incrementor for _increments[]
		
		public PIDTuning(ShipStats stats){
			_stats = stats;

			_pids[0] = "Lat P";
			_pids[1] = "Lat I";
			_pids[2] = "Lat D";
			_pids[3] = "Ver P";
			_pids[4] = "Ver I";
			_pids[5] = "Ver D";
			_pids[6] = "Lon P";
			_pids[7] = "Lon I";
			_pids[8] = "Lon D";
			_pids[9] = "Pit P";
			_pids[10] = "Pit I";
			_pids[11] = "Pit D";
			_pids[12] = "Yaw P";
			_pids[13] = "Yaw I";
			_pids[14] = "Yaw D";
			_pids[15] = "Rol P";
			_pids[16] = "Rol I";
			_pids[17] = "Rol D";

			_increments[0] = .001f;
			_increments[1] = .01f;
			_increments[2] = .1f;
			_increments[3] = 1f;
			_increments[4] = 10f;
		}

		public void MainUp(){
			if(_main < _pids.Length - 1){_main++;}
		}
		public void MainDown(){
			if(_main > 0){_main--;}
		}

		public void ValueUp(){
			if(_value <= 100f - _increments[_increment]){
				_value += _increments[_increment];
				
				if	   (_pids[_main] == _pids[0]) {_stats.LinearGainX.p = _value;}
				else if(_pids[_main] == _pids[1]) {_stats.LinearGainX.i = _value;}
				else if(_pids[_main] == _pids[2]) {_stats.LinearGainX.d = _value;}
				else if(_pids[_main] == _pids[3]) {_stats.LinearGainY.p = _value;}
				else if(_pids[_main] == _pids[4]) {_stats.LinearGainY.i = _value;}
				else if(_pids[_main] == _pids[5]) {_stats.LinearGainY.d = _value;}
				else if(_pids[_main] == _pids[6]) {_stats.LinearGainZ.p = _value;}
				else if(_pids[_main] == _pids[7]) {_stats.LinearGainZ.i = _value;}
				else if(_pids[_main] == _pids[8]) {_stats.LinearGainZ.d = _value;}
				else if(_pids[_main] == _pids[9]) {_stats.AngularGainX.p = _value;}
				else if(_pids[_main] == _pids[10]){_stats.AngularGainX.i = _value;}
				else if(_pids[_main] == _pids[11]){_stats.AngularGainX.d = _value;}
				else if(_pids[_main] == _pids[12]){_stats.AngularGainY.p = _value;}
				else if(_pids[_main] == _pids[13]){_stats.AngularGainY.i = _value;}
				else if(_pids[_main] == _pids[14]){_stats.AngularGainY.d = _value;}
				else if(_pids[_main] == _pids[15]){_stats.AngularGainZ.p = _value;}
				else if(_pids[_main] == _pids[16]){_stats.AngularGainZ.i = _value;}
				else if(_pids[_main] == _pids[17]){_stats.AngularGainZ.d = _value;}
			}
		}
		public void ValueDown(){
			if(_value >= 0 + _increments[_increment]){
				_value -= _increments[_increment];

				if	   (_pids[_main] == _pids[0]) {_stats.LinearGainX.p = _value;}
				else if(_pids[_main] == _pids[1]) {_stats.LinearGainX.i = _value;}
				else if(_pids[_main] == _pids[2]) {_stats.LinearGainX.d = _value;}
				else if(_pids[_main] == _pids[3]) {_stats.LinearGainY.p = _value;}
				else if(_pids[_main] == _pids[4]) {_stats.LinearGainY.i = _value;}
				else if(_pids[_main] == _pids[5]) {_stats.LinearGainY.d = _value;}
				else if(_pids[_main] == _pids[6]) {_stats.LinearGainZ.p = _value;}
				else if(_pids[_main] == _pids[7]) {_stats.LinearGainZ.i = _value;}
				else if(_pids[_main] == _pids[8]) {_stats.LinearGainZ.d = _value;}
				else if(_pids[_main] == _pids[9]) {_stats.AngularGainX.p = _value;}
				else if(_pids[_main] == _pids[10]){_stats.AngularGainX.i = _value;}
				else if(_pids[_main] == _pids[11]){_stats.AngularGainX.d = _value;}
				else if(_pids[_main] == _pids[12]){_stats.AngularGainY.p = _value;}
				else if(_pids[_main] == _pids[13]){_stats.AngularGainY.i = _value;}
				else if(_pids[_main] == _pids[14]){_stats.AngularGainY.d = _value;}
				else if(_pids[_main] == _pids[15]){_stats.AngularGainZ.p = _value;}
				else if(_pids[_main] == _pids[16]){_stats.AngularGainZ.i = _value;}
				else if(_pids[_main] == _pids[17]){_stats.AngularGainZ.d = _value;}
			}
		}

		public void IncrementUp(){
			if(_increment < _increments.Length - 1){_increment++;}
		}
		public void IncrementDown(){
			if(_increment > 0){_increment--;}
		}
		
		public string Name{get{UpdateValue(); return _pids[_main];}}
		public string Value{get{UpdateValue(); return _value.ToString();}}
		public string Increment{get{return _increments[_increment].ToString();}}

		void UpdateValue(){
			if	   (_pids[_main] == _pids[0]) {_value = _stats.LinearGainX.p;}
			else if(_pids[_main] == _pids[1]) {_value = _stats.LinearGainX.i;}
			else if(_pids[_main] == _pids[2]) {_value = _stats.LinearGainX.d;}
			else if(_pids[_main] == _pids[3]) {_value = _stats.LinearGainY.p;}
			else if(_pids[_main] == _pids[4]) {_value = _stats.LinearGainY.i;}
			else if(_pids[_main] == _pids[5]) {_value = _stats.LinearGainY.d;}
			else if(_pids[_main] == _pids[6]) {_value = _stats.LinearGainZ.p;}
			else if(_pids[_main] == _pids[7]) {_value = _stats.LinearGainZ.i;}
			else if(_pids[_main] == _pids[8]) {_value = _stats.LinearGainZ.d;}
			else if(_pids[_main] == _pids[9]) {_value = _stats.AngularGainX.p;}
			else if(_pids[_main] == _pids[10]){_value = _stats.AngularGainX.i;}
			else if(_pids[_main] == _pids[11]){_value = _stats.AngularGainX.d;}
			else if(_pids[_main] == _pids[12]){_value = _stats.AngularGainY.p;}
			else if(_pids[_main] == _pids[13]){_value = _stats.AngularGainY.i;}
			else if(_pids[_main] == _pids[14]){_value = _stats.AngularGainY.d;}
			else if(_pids[_main] == _pids[15]){_value = _stats.AngularGainZ.p;}
			else if(_pids[_main] == _pids[16]){_value = _stats.AngularGainZ.i;}
			else if(_pids[_main] == _pids[17]){_value = _stats.AngularGainZ.d;}
		}
	}
}