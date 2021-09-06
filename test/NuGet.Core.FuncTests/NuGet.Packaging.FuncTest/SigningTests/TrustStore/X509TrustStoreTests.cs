// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using NuGet.Packaging.Signing;
using NuGet.Test.Utility;
using Xunit;

namespace NuGet.Packaging.FuncTest
{
    public class X509TrustStoreTests
    {
        private readonly TestLogger _logger;

        public X509TrustStoreTests()
        {
            _logger = new TestLogger();
        }

        [Fact]
        public void Initialize_WhenArgumentIsNull_Throws()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => X509TrustStore.Initialize(logger: null));

            Assert.Equal("logger", exception.ParamName);
        }

        [PlatformFact(Platform.Windows)]
        public void CreateX509ChainFactory_OnWindowsAlways_ReturnsFactory()
        {
            IX509ChainFactory factory = X509TrustStore.CreateX509ChainFactory(_logger);

            Assert.IsType<DefaultTrustStoreX509ChainFactory>(factory);
            Assert.Equal(1, _logger.Messages.Count);
            Assert.Equal(1, _logger.VerboseMessages.Count);
            Assert.True(_logger.VerboseMessages.TryDequeue(out string actualMessage));
            Assert.Equal("X.509 certificate chain validation will use the default trust store.", actualMessage);
        }

#if NET5_0_OR_GREATER
        [PlatformFact(Platform.Linux)]
        public void CreateX509ChainFactory_OnLinuxAlways_ReturnsFactory()
        {
            IX509ChainFactory factory = X509TrustStore.CreateX509ChainFactory(_logger);

            bool wasFound = TryReadFirstBundle(
                SystemCertificateBundleX509ChainFactory.ProbePaths,
                out X509Certificate2Collection certificates,
                out string _);
            var certificateBundleFactory = (CertificateBundleX509ChainFactory)factory;

            if (wasFound)
            {
                Assert.IsType<SystemCertificateBundleX509ChainFactory>(factory);
                Assert.Equal(certificates.Count, certificateBundleFactory.Certificates.Count);
            }
            else
            {
                Assert.IsType<FallbackCertificateBundleX509ChainFactory>(factory);
                Assert.True(certificateBundleFactory.Certificates.Count > 0);
            }

            Assert.Equal(1, _logger.Messages.Count);
            Assert.Equal(1, _logger.VerboseMessages.Count);
            Assert.True(_logger.VerboseMessages.TryDequeue(out string actualMessage));

            string expectedMessage;

            if (wasFound)
            {
                expectedMessage = string.Format(
                    CultureInfo.CurrentCulture,
                    "X.509 certificate chain validation will use the system certificate bundle at {0}.",
                    certificateBundleFactory.FilePath);
            }
            else
            {
                expectedMessage = string.Format(
                    CultureInfo.CurrentCulture,
                    "X.509 certificate chain validation will use the fallback certificate bundle at {0}.",
                    certificateBundleFactory.FilePath);
            }

            Assert.Equal(expectedMessage, actualMessage);
        }

        [PlatformFact(Platform.Darwin)]
        public void CreateX509ChainFactory_OnMacOsAlways_ReturnsFactory()
        {
            IX509ChainFactory factory = X509TrustStore.CreateX509ChainFactory(_logger);

            Assert.IsType<FallbackCertificateBundleX509ChainFactory>(factory);

            Assert.Equal(1, _logger.Messages.Count);
            Assert.Equal(1, _logger.VerboseMessages.Count);
            Assert.True(_logger.VerboseMessages.TryDequeue(out string actualMessage));

            string expectedMessage = string.Format(
                CultureInfo.CurrentCulture,
                "X.509 certificate chain validation will use the fallback certificate bundle at {0}.",
                ((CertificateBundleX509ChainFactory)factory).FilePath);

            Assert.Equal(expectedMessage, actualMessage);
        }

        private static bool TryReadFirstBundle(
            IReadOnlyList<string> probePaths,
            out X509Certificate2Collection certificates,
            out string successfulProbePath)
        {
            certificates = null;
            successfulProbePath = null;

            var oneProbePath = new string[1];

            foreach (string probePath in probePaths)
            {
                oneProbePath[0] = probePath;

                if (SystemCertificateBundleX509ChainFactory.TryCreate(out SystemCertificateBundleX509ChainFactory factory, oneProbePath))
                {
                    certificates = factory.Certificates;
                    successfulProbePath = probePath;

                    return true;
                }
            }

            return false;
        }
#endif
    }
}
