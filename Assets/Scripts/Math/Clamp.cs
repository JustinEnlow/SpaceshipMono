namespace Nlo.Math{
    public static class Clamp{
        public static int Int(int currentValue, int min, int max){
            if(currentValue > max){return max;}
            else if(currentValue < min){return min;}
            else{return currentValue;}
        }
        public static float Float(float currentValue, float min, float max){
            if(currentValue > max){return max;}
            else if(currentValue < min){return min;}
            else{return currentValue;}
        }
    }
}