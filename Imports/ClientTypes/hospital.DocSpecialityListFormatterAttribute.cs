using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace hospital;

public partial class DocSpecialityListFormatterAttribute : CustomFormatterAttribute
{
    public const string Key = "hospital.SpecialityListFormatter";

    public DocSpecialityListFormatterAttribute()
        : base(Key)
    {
    }
}