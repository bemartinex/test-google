﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGoogle.Fixtures;

namespace TestGoogle.Fixtures
{
    [CollectionDefinition("Chrome Driver")]
    public class CollectionFixture : ICollectionFixture<TestFixtures>
    {
    }
}