using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MovieTutorial;

public partial class SpecialityListFormatterAttribute : CustomFormatterAttribute
{
    public const string Key = "MovieTutorial.SpecialityListFormatter";

    public SpecialityListFormatterAttribute()
        : base(Key)
    {
    }
}