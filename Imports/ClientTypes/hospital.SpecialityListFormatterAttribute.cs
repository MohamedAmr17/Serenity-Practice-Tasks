using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace hospital;

public partial class SpecialityListFormatterAttribute : CustomFormatterAttribute
{
    public const string Key = "hospital.SpecialityListFormatter";

    public SpecialityListFormatterAttribute()
        : base(Key)
    {
    }
}