// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#if NET5_0_OR_GREATER

using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace NuGet.Packaging.Signing
{
    internal abstract class CertificateBundleX509ChainFactory : IX509ChainFactory
    {
        public X509Certificate2Collection Certificates { get; protected set; }
        public string FilePath { get; protected set; }

        public X509Chain Create()
        {
            var x509Chain = new X509Chain();

            x509Chain.ChainPolicy.TrustMode = X509ChainTrustMode.CustomRootTrust;

            x509Chain.ChainPolicy.CustomTrustStore.AddRange(Certificates);

            return x509Chain;
        }

        protected static bool TryImportFromPemFile(string filePath, out X509Certificate2Collection certificates)
        {
            certificates = new X509Certificate2Collection();

            try
            {
                certificates.ImportFromPemFile(filePath);

                return true;
            }
            catch (Exception ex) when (ex is CryptographicException || ex is IOException)
            {
                certificates.Clear();
            }

            return false;
        }
    }
}

#endif
