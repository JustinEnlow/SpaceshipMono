using Nlo.Spaceship.Interfaces;

namespace Nlo.Spaceship{
    public class WeaponSystem{
        ShipEventManager eventManager;
        PowerToggle power;
        MasterArm masterArm;
        IWeapon[] weapons;
        bool[] weaponEnabledStatus;
        bool firing;

        public WeaponSystem(ShipEventManager eventManager, PowerToggle power, MasterArm masterArm){
            this.eventManager = eventManager;
            this.power = power;
            this.masterArm = masterArm;

            eventManager.OnFireWeapons += FireWeapon;
            eventManager.OnStopFiringWeapons += StopFiringWeapon;
            power.OnPowerToggled += CheckFiringParameters;
            masterArm.OnMasterArmToggled += CheckFiringParameters;
        }
        ~WeaponSystem(){
            eventManager.OnFireWeapons -= FireWeapon;
            eventManager.OnStopFiringWeapons -= StopFiringWeapon;
        }

        public void UpdateWeapons(IWeapon[] weapons, bool[] weaponEnabledStatus) {
            this.weapons = weapons;
            this.weaponEnabledStatus = weaponEnabledStatus;
            CheckFiringParameters();
        }


        void FireWeapon(){
            firing = true;
            CheckFiringParameters();
        }
        void StopFiringWeapon(){
            firing = false;
            CheckFiringParameters();
        }
        void CheckFiringParameters(){
            for(int i = 0; i < weapons.Length; i++){
                if(power.Enabled && masterArm.Enabled && weaponEnabledStatus[i] == true && firing){
                    weapons[i].Fire();
                }
                else{
                    weapons[i].StopFiring();
                }
            }
        }
    }
}
