// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#if NET5_0_OR_GREATER

using System.Security.Cryptography.X509Certificates;
using NuGet.Packaging.Signing;
using Xunit;

namespace NuGet.Packaging.Test
{
    public class NoCertificateBundleX509ChainFactoryTests
    {
        [Fact]
        public void Certificates_Always_IsEmpty()
        {
            var factory = new NoCertificateBundleX509ChainFactory();

            Assert.Empty(factory.Certificates);
        }

        [Fact]
        public void FilePath_Always_IsNull()
        {
            var factory = new NoCertificateBundleX509ChainFactory();

            Assert.Null(factory.FilePath);
        }

        [Fact]
        public void Create_Always_ReturnsX509Chain()
        {
            var factory = new NoCertificateBundleX509ChainFactory();

            using (X509Chain chain = factory.Create())
            {
                Assert.Equal(X509ChainTrustMode.CustomRootTrust, chain.ChainPolicy.TrustMode);
                Assert.Empty(chain.ChainPolicy.CustomTrustStore);
            }
        }
    }
}
#endif
