using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    //public int machineGunCount;
    [SerializeField] private GameObject machineGunPrefab;
    //public int mountedGunCount;
    [SerializeField] private GameObject mountedGunPrefub;

    public int turretForBuildCount;
    private GameObject turretForBuild;

    private void Awake()
    {


        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject GetTurretForBuild()
    {
        if (turretForBuildCount < 1)
        {
            return null;
        }

        turretForBuildCount--;
        return turretForBuild;
    }

    public void SetMountedGunForBuild()
    {
        turretForBuild = mountedGunPrefub;
    }

    public void SetMachineGunForBuild()
    {
        turretForBuild = machineGunPrefab;
    }

}
