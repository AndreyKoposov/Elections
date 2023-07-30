using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResTypes
{
    MONEY, FOOD, METAL, POWER
}

public class ResourceGroup : MonoBehaviour
{
    private Dictionary<ResTypes, ResourceContainer> resources;

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

    public ResourceContainer GetLowestValueResourceExceptOne(ResTypes resource)
    {
        List<ResourceContainer> values = ResourceToList();
        List<ResourceContainer> sortValues = SortResourceList(values);

        if (sortValues[0].Type == resource)
        {
            return sortValues[1];
        }
        return sortValues[0];
    }

    private List<ResourceContainer> ResourceToList()
    {
        List<ResourceContainer> values = new List<ResourceContainer>(resources.Values);
        return values;
    }

    private List<ResourceContainer> SortResourceList(List<ResourceContainer> values)
    {
        values.Sort(ResourceContainer.CompareResource);
        return values;
    }
}
