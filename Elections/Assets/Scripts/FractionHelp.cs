using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractionHelp
{
    public FractionHelpINFO _info;
    public Fraction _whichHelp;
    public ActionPerform _leftChoose;
    public ActionPerform _rightChoose;
    public FractionHelp(Fraction fraction, FractionHelpINFO info)
    {
        _whichHelp = fraction;
        _info = info;

        _leftChoose = (group, resources) =>
        {
            _whichHelp.Rate -= 30;
            Fraction anotherFraction = FractionGroup.GetLowestRateFractionExceptOne(_whichHelp.Type);
            anotherFraction.Rate += 30;
        };

        _rightChoose = (group, resources) =>
        {
            _whichHelp.Rate -= 30;
            ResourceContainer res = ResourceGroup.GetLowestValueResourceExceptOne(_whichHelp.TypeRes);
            res.Value += 30;
        };
    }

    private ResourceContainer GetResourceByEnumFromGroup(ResTypes type, ResourceGroup resGroup)
    {
        return resGroup[type];
    }

    public void InsertInTextFractionName(Fractions fraction)
    {
        string yes = _info._yesAnswer.Replace("_F_", EnumConverter.ToString(fraction));
        _info = new FractionHelpINFO(_info._text, yes, _info._noAnswer);
    }

    public void InsertInTexResourceName(ResTypes resource)
    {
        string no = _info._noAnswer.Replace("_R_", EnumConverter.ToString(resource));
        _info = new FractionHelpINFO(_info._text, _info._yesAnswer, no);
    }
}
