// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Globalization;
using NuGet.Common;

namespace NuGet.Packaging.Signing
{
    /// <summary>
    /// Represents the X.509 trust store that package signing and signed package verification will use.
    /// </summary>
    public static class X509TrustStore
    {
        private static IX509ChainFactory Instance;
        private static readonly object LockObject = new object();

        /// <summary>
        /// Attempts to discover and load an X.509 trust store and log details about the attempt.
        /// If initialization has already happened, a call to this method will have no effect.
        /// </summary>
        /// <remarks>Explicit initialization is unnecessary for X.509 certificate chain building;
        /// initialization will happen automatically on demand.  This method provides an opportunity
        /// to log diagnostic information about trust store discovery.</remarks>
        /// <param name="logger">A logger.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="logger" /> is <c>null</c>.</exception>
        public static void Initialize(ILogger logger)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _ = GetX509ChainFactory(logger);
        }

        internal static IX509ChainFactory GetX509ChainFactory(ILogger logger)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (Instance is not null)
            {
                return Instance;
            }

            lock (LockObject)
            {
                Instance = CreateX509ChainFactory(logger);
            }

            return Instance;
        }

        // Non-private for testing purposes only
        internal static IX509ChainFactory CreateX509ChainFactory(ILogger logger)
        {
#if NET5_0_OR_GREATER
            if (RuntimeEnvironmentHelper.IsLinux)
            {
                if (SystemCertificateBundleX509ChainFactory.TryCreate(out SystemCertificateBundleX509ChainFactory systemBundleFactory))
                {
                    logger.LogVerbose(string.Format(CultureInfo.CurrentCulture, Strings.ChainBuilding_UsingSystemCertificateBundle, systemBundleFactory.FilePath));

                    return systemBundleFactory;
                }

                if (FallbackCertificateBundleX509ChainFactory.TryCreate(out FallbackCertificateBundleX509ChainFactory fallbackBundleFactory))
                {
                    logger.LogVerbose(string.Format(CultureInfo.CurrentCulture, Strings.ChainBuilding_UsingFallbackCertificateBundle, fallbackBundleFactory.FilePath));

                    return fallbackBundleFactory;
                }

                logger.LogVerbose(Strings.ChainBuilding_UsingNoCertificateBundle);

                return new NoCertificateBundleX509ChainFactory();
            }

            if (RuntimeEnvironmentHelper.IsMacOSX)
            {
                if (FallbackCertificateBundleX509ChainFactory.TryCreate(out FallbackCertificateBundleX509ChainFactory fallbackBundleFactory))
                {
                    logger.LogVerbose(string.Format(CultureInfo.CurrentCulture, Strings.ChainBuilding_UsingFallbackCertificateBundle, fallbackBundleFactory.FilePath));

                    return fallbackBundleFactory;
                }

                logger.LogVerbose(Strings.ChainBuilding_UsingNoCertificateBundle);

                return new NoCertificateBundleX509ChainFactory();
            }
#endif

            logger.LogVerbose(Strings.ChainBuilding_UsingDefaultTrustStore);

            return new DefaultTrustStoreX509ChainFactory();
        }
    }
}
