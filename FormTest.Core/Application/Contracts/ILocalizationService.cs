﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormTest.Core.Application.Contracts
{
    public interface ILocalizationService
    {
        string this[string key] { get; }
    }
}
