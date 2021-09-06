// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#if NET5_0_OR_GREATER

using System.Security.Cryptography.X509Certificates;
using NuGet.Packaging.Signing;
using Xunit;

namespace NuGet.Packaging.Test
{
    public class DefaultTrustStoreX509ChainFactoryTests
    {
        [Fact]
        public void Create_Always_ReturnsX509Chain()
        {
            var factory = new DefaultTrustStoreX509ChainFactory();

            using (X509Chain chain = factory.Create())
            {
                Assert.Equal(X509ChainTrustMode.System, chain.ChainPolicy.TrustMode);
            }
        }
    }
}
#endif
