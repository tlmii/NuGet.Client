// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#if NET5_0_OR_GREATER

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using NuGet.Packaging.Signing;
using NuGet.Test.Utility;
using Xunit;

namespace NuGet.Packaging.Test
{
    public class SystemCertificateBundleX509ChainFactoryTests : IClassFixture<CertificatesFixture>, IDisposable
    {
        private readonly TestDirectory _directory;
        private readonly CertificatesFixture _fixture;

        public SystemCertificateBundleX509ChainFactoryTests(CertificatesFixture fixture)
        {
            _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
            _directory = TestDirectory.Create();
        }

        public void Dispose()
        {
            _directory.Dispose();
        }

        [Fact]
        public void TryCreate_WhenFilePathDoesNotExist_ReturnsFalse()
        {
            var nonexistentFile = new FileInfo(Path.Combine(_directory.Path, "certificates.bundle"));

            bool wasCreated = SystemCertificateBundleX509ChainFactory.TryCreate(
                out SystemCertificateBundleX509ChainFactory factory,
                new[] { nonexistentFile.FullName });

            Assert.False(wasCreated);
            Assert.Null(factory);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void TryCreate_WhenFilePathExists_ReturnsTrue(int indexOfMatch)
        {
            using (X509Certificate2 certificate = _fixture.GetDefaultCertificate())
            {
                var files = new FileInfo[2]
                    {
                        new FileInfo(Path.Combine(_directory.Path, "0.bundle")),
                        new FileInfo(Path.Combine(_directory.Path, "1.bundle"))
                    };

                CreateBundleFile(files[indexOfMatch], certificate);

                bool wasCreated = SystemCertificateBundleX509ChainFactory.TryCreate(
                    out SystemCertificateBundleX509ChainFactory factory,
                    files.Select(file => file.FullName).ToArray());

                Assert.True(wasCreated);
                Assert.Equal(1, factory.Certificates.Count);
                Assert.Equal(certificate.Thumbprint, factory.Certificates[0].Thumbprint);
            }
        }

        [Fact]
        public void Create_Always_ReturnsX509Chain()
        {
            using (X509Certificate2 certificate = _fixture.GetDefaultCertificate())
            {
                var bundleFile = new FileInfo(Path.Combine(_directory.Path, "certificates.bundle"));

                CreateBundleFile(bundleFile, certificate);

                bool wasCreated = SystemCertificateBundleX509ChainFactory.TryCreate(
                    out SystemCertificateBundleX509ChainFactory factory,
                    new[] { bundleFile.FullName });

                Assert.True(wasCreated);

                using (X509Chain chain = factory.Create())
                {
                    Assert.Equal(X509ChainTrustMode.CustomRootTrust, chain.ChainPolicy.TrustMode);
                    Assert.Equal(1, chain.ChainPolicy.CustomTrustStore.Count);
                    Assert.Equal(certificate.Thumbprint, chain.ChainPolicy.CustomTrustStore[0].Thumbprint);
                }
            }
        }

        private static void CreateBundleFile(FileInfo file, X509Certificate2 certificate)
        {
            char[] pem = PemEncoding.Write("CERTIFICATE", certificate.RawData);

            File.WriteAllText(file.FullName, new string(pem));
        }
    }
}
#endif
