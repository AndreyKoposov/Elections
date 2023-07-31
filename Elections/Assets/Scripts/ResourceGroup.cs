using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public enum ResTypes
{
    MONEY, FOOD, METAL, POWER
}

public class ResourceGroup : MonoBehaviour
{
    private static Dictionary<ResTypes, ResourceContainer> resources;

    private void Awake()
    {
        InitResourcesGroup();
    }

    public ResourceContainer this[ResTypes resource]
    {
        get
        {
            return resources[resource];
        }
    }

    public static Dictionary<ResTypes, ResourceContainer> Group
    {
        get { return resources; }
    }

    public void InitResourcesGroup()
    {
        resources = new Dictionary<ResTypes, ResourceContainer>();
        ResourceContainer[] res = gameObject.GetComponentsInChildren<ResourceContainer>();
        for(int i = 0; i < res.Length; i++)
        {
            resources.Add(res[i].Type, res[i]);
        }
    }
    public void InitResourcesGroup(int money, int metal, int food, int power)
    {
        resources = new Dictionary<ResTypes, ResourceContainer>();
        ResourceContainer[] res = gameObject.GetComponentsInChildren<ResourceContainer>();
        for (int i = 0; i < res.Length; i++)
        {
            resources.Add(res[i].Type, res[i]);
        }
    }

    public static ResourceContainer GetLowestValueResourceExceptOne(ResTypes resource)
    {
        List<ResourceContainer> values = ResourceToList();
        List<ResourceContainer> sortValues = SortResourceList(values);

        if (sortValues[0].Type == resource)
        {
            return sortValues[1];
        }
        return sortValues[0];
    }

    private static List<ResourceContainer> ResourceToList()
    {
        List<ResourceContainer> values = new List<ResourceContainer>(resources.Values);
        return values;
    }

    private static List<ResourceContainer> SortResourceList(List<ResourceContainer> values)
    {
        values.Sort(ResourceContainer.CompareResource);
        return values;
    }

    public static GameOverINFO GetGameOverInfo()
    {
        if (resources[ResTypes.MONEY].Value <= 0)
        {
            return new GameOverINFO(ResTypes.MONEY);
        }
        if (resources[ResTypes.FOOD].Value <= 0)
        {
            return new GameOverINFO(ResTypes.FOOD);
        }
        if (resources[ResTypes.POWER].Value <= 0)
        {
            return new GameOverINFO(ResTypes.POWER);
        }
        if (resources[ResTypes.METAL].Value <= 0)
        {
            return new GameOverINFO(ResTypes.METAL);
        }
        return null;
    }

    public static void AppendValuesToResources(Dictionary<ResTypes, int> valuePerTurn)
    {
        resources[ResTypes.METAL].Value += valuePerTurn[ResTypes.METAL];
        resources[ResTypes.MONEY].Value += valuePerTurn[ResTypes.MONEY];
        resources[ResTypes.POWER].Value += valuePerTurn[ResTypes.POWER];
        resources[ResTypes.FOOD].Value += valuePerTurn[ResTypes.FOOD];
    }

    public static void DecreaseRandomResource(int value)
    {
        Random random = new Random();

        ResTypes resType = (ResTypes)random.Next(0, 4);
        resources[resType].Value -= value;
    }
}
