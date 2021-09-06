// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#if NET5_0_OR_GREATER

using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace NuGet.Packaging.Signing
{
    internal sealed class SystemCertificateBundleX509ChainFactory : CertificateBundleX509ChainFactory
    {
        internal static readonly IReadOnlyList<string> ProbePaths = new[]
        {
            "/etc/pki/ca-trust/extracted/pem/objsign-ca-bundle.pem"
        };

        private SystemCertificateBundleX509ChainFactory(X509Certificate2Collection certificates, string filePath)
        {
            Certificates = certificates;
            FilePath = filePath;
        }

        internal static bool TryCreate(out SystemCertificateBundleX509ChainFactory factory)
        {
            return TryCreate(out factory, ProbePaths);
        }

        // For testing purposes only.
        internal static bool TryCreate(out SystemCertificateBundleX509ChainFactory factory, IReadOnlyList<string> probePaths)
        {
            factory = null;

            foreach (string probePath in probePaths)
            {
                if (TryImportFromPemFile(probePath, out X509Certificate2Collection certificates)
                    && certificates.Count > 0)
                {
                    factory = new SystemCertificateBundleX509ChainFactory(certificates, probePath);

                    break;
                }
            }

            return factory is not null;
        }
    }
}

#endif
