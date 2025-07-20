using UnityEngine;
using UnityEngine.Networking;

public class BypassCertificateHandler : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
        {
            // Ritorna sempre true per bypassare il controllo del certificato
            return true;
        }
}
