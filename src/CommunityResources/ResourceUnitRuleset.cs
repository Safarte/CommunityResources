﻿using Newtonsoft.Json.Linq;
using PatchManager.SassyPatching;
using PatchManager.SassyPatching.Attributes;
using PatchManager.SassyPatching.Interfaces;
using PatchManager.SassyPatching.NewAssets;
using PatchManager.SassyPatching.Selectables;

namespace CommunityResourceUnits;

[PatcherRuleset("resource_units","resource_units")]
public class ResourceUnitRuleset : IPatcherRuleSet
{
    public bool Matches(string label) => label == "resource_units";

    public ISelectable ConvertToSelectable(string type, string name, string jsonData) =>
        new JTokenSelectable(() => { }, JObject.Parse(jsonData), name, type);

    private static int _globallyIncrementingId = 0;
    public INewAsset CreateNew(List<DataValue> dataValues)
    {
        var id = _globallyIncrementingId++;
        return new NewGenericAsset("resource_units", $"resource_unit_definition_{id}", new JTokenSelectable(
            () => { }, new JObject(), $"resource_unit_definition_{id}", "resource_units"));
    }
}