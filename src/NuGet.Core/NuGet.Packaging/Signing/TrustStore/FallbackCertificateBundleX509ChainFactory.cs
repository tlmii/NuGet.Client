// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#if NET5_0_OR_GREATER

using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace NuGet.Packaging.Signing
{
    internal sealed class FallbackCertificateBundleX509ChainFactory : CertificateBundleX509ChainFactory
    {
        internal const string FileName = "certificates.bundle";

        private FallbackCertificateBundleX509ChainFactory(X509Certificate2Collection certificates, string filePath)
        {
            Certificates = certificates;
            FilePath = filePath;
        }

        internal static bool TryCreate(out FallbackCertificateBundleX509ChainFactory factory, string filePath = FileName)
        {
            factory = null;

            string fullFilePath = Path.IsPathRooted(filePath) ? filePath : Path.GetFullPath(filePath);

            if (TryImportFromPemFile(fullFilePath, out X509Certificate2Collection certificates))
            {
                factory = new FallbackCertificateBundleX509ChainFactory(certificates, fullFilePath);

                return true;
            }

            return false;
        }
    }
}

#endif
