namespace Nlo.Spaceship.Interfaces{
    public interface ITune{
        void MainUp();
        void MainDown();
        void ValueUp();
        void ValueDown();
        void IncrementUp();
        void IncrementDown();
        string Name{get;}
        string Value{get;}
        string Increment{get;}
    }
}