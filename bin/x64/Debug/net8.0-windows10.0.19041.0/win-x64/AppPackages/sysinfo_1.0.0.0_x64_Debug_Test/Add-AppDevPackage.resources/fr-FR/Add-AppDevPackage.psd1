# Localized	12/03/2020 06:20 PM (GMT)	303:4.80.0411 	Add-AppDevPackage.psd1
# Culture = "en-US"
ConvertFrom-StringData @'
###PSLOC
PromptYesString=O&ui
PromptNoString=&Non
BundleFound=Lot trouvé : {0}
PackageFound=Package trouvé : {0}
EncryptedBundleFound=Lot chiffré trouvé : {0}
EncryptedPackageFound=Package chiffré trouvé : {0}
CertificateFound=Certificat trouvé : {0}
DependenciesFound=Package(s) de dépendance trouvé(s) :
GettingDeveloperLicense=Acquisition de la licence de développeur...
InstallingCertificate=Installation du certificat...
InstallingPackage=\nInstallation de l'application…
AcquireLicenseSuccessful=Une licence de développeur a été correctement acquise.
InstallCertificateSuccessful=Le certificat a été correctement installé.
Success=\nOpération réussie : votre application a été correctement installée.
WarningInstallCert=\nVous êtes sur le point d'installer un certificat numérique dans le magasin de certificats Personnes autorisées de votre ordinateur. Cette opération comporte un grave risque de sécurité et elle ne doit être exécutée que si l'émetteur de ce certificat numérique est fiable.\n\nLorsque vous avez fini d'utiliser cette application, vous devez supprimer manuellement le certificat numérique associé. Des instructions se rapportant à cette procédure sont disponibles à cette adresse : http://go.microsoft.com/fwlink/?LinkId=243053\n\nVoulez-vous vraiment continuer ?\n\n
ElevateActions=\nAvant d'installer cette application, vous devez exécuter les tâches suivantes :
ElevateActionDevLicense=\t- Acquérir une licence de développeur
ElevateActionCertificate=\t- Installer le certificat de signature
ElevateActionsContinue=Des informations d'identification d'administrateur sont nécessaires pour continuer. Acceptez l'invite du contrôle de compte d'utilisateur et entrez votre mot de passe d'administrateur si nécessaire.
ErrorForceElevate=Vous devez fournir des informations d'identification d'administrateur pour continuer. Exécutez ce script sans le paramètre -Force ou dans une fenêtre PowerShell avec des privilèges élevés.
ErrorForceDeveloperLicense=L'acquisition d'une licence de développeur requiert l'intervention de l'utilisateur. Réexécutez le script sans le paramètre -Force.
ErrorLaunchAdminFailed=Erreur : impossible de démarrer un nouveau processus en tant qu'administrateur.
ErrorNoScriptPath=Erreur : vous devez lancer ce script à partir d'un fichier.
ErrorNoPackageFound=Erreur : aucun package ou lot trouvé dans le répertoire de scripts. Vérifiez que le package ou lot que vous voulez installer se trouve dans le même répertoire que ce script.
ErrorManyPackagesFound=Erreur : plusieurs packages ou lots trouvés dans le répertoire de scripts. Vérifiez que seul le package ou lot que vous voulez installer se trouve dans le même répertoire que ce script.
ErrorPackageUnsigned=Erreur : le package ou lot n'est pas signé numériquement ou sa signature est endommagée.
ErrorNoCertificateFound=Erreur : aucun certificat trouvé dans le répertoire de scripts. Vérifiez que le certificat utilisé pour signer le package ou lot que vous installez se trouve dans le même répertoire que ce script.
ErrorManyCertificatesFound=Erreur : plusieurs certificats trouvés dans le répertoire de scripts. Vérifiez que seul le certificat utilisé pour signer le package ou le lot que vous installez se trouve dans le même répertoire que ce script.
ErrorBadCertificate=Erreur : le fichier "{0}" n'est pas un certificat numérique valide. CertUtil retourné avec le code d'erreur {1}.
ErrorExpiredCertificate=Erreur : le certificat de développeur "{0}" a expiré. Cela peut être dû à un mauvais réglage de la date et de l'heure de l'horloge système. Si les paramètres système sont corrects, contactez le propriétaire de l'application afin qu'il recrée le package ou le lot avec un certificat valide.
ErrorCertificateMismatch=Erreur : le certificat ne correspond pas à celui utilisé pour signer le package ou le lot.
ErrorCertIsCA=Erreur : le certificat ne peut pas être une autorité de certification.
ErrorBannedKeyUsage=Erreur : le certificat ne peut pas avoir l'utilisation de clé suivante : {0}. L'utilisation de la clé ne doit pas être spécifiée ou elle doit être égale à "DigitalSignature".
ErrorBannedEKU=Erreur : le certificat ne peut pas avoir l'utilisation améliorée de la clé suivante : {0}. Seules les utilisations améliorées de la clé (EKU) Signature du code et Signature permanente sont autorisées.
ErrorNoBasicConstraints=Erreur : le certificat ne contient pas les extensions de contraintes de base.
ErrorNoCodeSigningEku=Erreur : le certificat ne contient pas l'utilisation améliorée de la clé pour Signature du code.
ErrorInstallCertificateCancelled=Erreur : l'installation du certificat a été annulée.
ErrorCertUtilInstallFailed=Erreur : impossible d'installer le certificat. CertUtil retourné avec le code d'erreur {0}.
ErrorGetDeveloperLicenseFailed=Erreur : impossible d'acquérir une licence de développeur. Pour plus d'informations, consultez http://go.microsoft.com/fwlink/?LinkID=252740.
ErrorInstallCertificateFailed=Erreur : impossible d'installer le certificat. État : {0}. Pour plus d'informations, consultez http://go.microsoft.com/fwlink/?LinkID=252740.
ErrorAddPackageFailed=Erreur : impossible d'installer l'application.
ErrorAddPackageFailedWithCert=Erreur : impossible d'installer l'application. Pour garantir la sécurité, pensez à désinstaller le certificat de signature jusqu'à ce que vous puissiez installer l'application. Des instructions se rapportant à cette procédure sont disponibles à cette adresse : \nhttp://go.microsoft.com/fwlink/?LinkId=243053
'@

# SIG # Begin signature block
# MIIoQwYJKoZIhvcNAQcCoIIoNDCCKDACAQExDzANBglghkgBZQMEAgEFADB5Bgor
# BgEEAYI3AgEEoGswaTA0BgorBgEEAYI3AgEeMCYCAwEAAAQQH8w7YFlLCE63JNLG
# KX7zUQIBAAIBAAIBAAIBAAIBADAxMA0GCWCGSAFlAwQCAQUABCAFO4b12o9Q47XJ
# hD1wgOoRkZLqDncJWHLhb3O3PI/qnqCCDXYwggX0MIID3KADAgECAhMzAAAEBGx0
# Bv9XKydyAAAAAAQEMA0GCSqGSIb3DQEBCwUAMH4xCzAJBgNVBAYTAlVTMRMwEQYD
# VQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNy
# b3NvZnQgQ29ycG9yYXRpb24xKDAmBgNVBAMTH01pY3Jvc29mdCBDb2RlIFNpZ25p
# bmcgUENBIDIwMTEwHhcNMjQwOTEyMjAxMTE0WhcNMjUwOTExMjAxMTE0WjB0MQsw
# CQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9u
# ZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMR4wHAYDVQQDExVNaWNy
# b3NvZnQgQ29ycG9yYXRpb24wggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIB
# AQC0KDfaY50MDqsEGdlIzDHBd6CqIMRQWW9Af1LHDDTuFjfDsvna0nEuDSYJmNyz
# NB10jpbg0lhvkT1AzfX2TLITSXwS8D+mBzGCWMM/wTpciWBV/pbjSazbzoKvRrNo
# DV/u9omOM2Eawyo5JJJdNkM2d8qzkQ0bRuRd4HarmGunSouyb9NY7egWN5E5lUc3
# a2AROzAdHdYpObpCOdeAY2P5XqtJkk79aROpzw16wCjdSn8qMzCBzR7rvH2WVkvF
# HLIxZQET1yhPb6lRmpgBQNnzidHV2Ocxjc8wNiIDzgbDkmlx54QPfw7RwQi8p1fy
# 4byhBrTjv568x8NGv3gwb0RbAgMBAAGjggFzMIIBbzAfBgNVHSUEGDAWBgorBgEE
# AYI3TAgBBggrBgEFBQcDAzAdBgNVHQ4EFgQU8huhNbETDU+ZWllL4DNMPCijEU4w
# RQYDVR0RBD4wPKQ6MDgxHjAcBgNVBAsTFU1pY3Jvc29mdCBDb3Jwb3JhdGlvbjEW
# MBQGA1UEBRMNMjMwMDEyKzUwMjkyMzAfBgNVHSMEGDAWgBRIbmTlUAXTgqoXNzci
# tW2oynUClTBUBgNVHR8ETTBLMEmgR6BFhkNodHRwOi8vd3d3Lm1pY3Jvc29mdC5j
# b20vcGtpb3BzL2NybC9NaWNDb2RTaWdQQ0EyMDExXzIwMTEtMDctMDguY3JsMGEG
# CCsGAQUFBwEBBFUwUzBRBggrBgEFBQcwAoZFaHR0cDovL3d3dy5taWNyb3NvZnQu
# Y29tL3BraW9wcy9jZXJ0cy9NaWNDb2RTaWdQQ0EyMDExXzIwMTEtMDctMDguY3J0
# MAwGA1UdEwEB/wQCMAAwDQYJKoZIhvcNAQELBQADggIBAIjmD9IpQVvfB1QehvpC
# Ge7QeTQkKQ7j3bmDMjwSqFL4ri6ae9IFTdpywn5smmtSIyKYDn3/nHtaEn0X1NBj
# L5oP0BjAy1sqxD+uy35B+V8wv5GrxhMDJP8l2QjLtH/UglSTIhLqyt8bUAqVfyfp
# h4COMRvwwjTvChtCnUXXACuCXYHWalOoc0OU2oGN+mPJIJJxaNQc1sjBsMbGIWv3
# cmgSHkCEmrMv7yaidpePt6V+yPMik+eXw3IfZ5eNOiNgL1rZzgSJfTnvUqiaEQ0X
# dG1HbkDv9fv6CTq6m4Ty3IzLiwGSXYxRIXTxT4TYs5VxHy2uFjFXWVSL0J2ARTYL
# E4Oyl1wXDF1PX4bxg1yDMfKPHcE1Ijic5lx1KdK1SkaEJdto4hd++05J9Bf9TAmi
# u6EK6C9Oe5vRadroJCK26uCUI4zIjL/qG7mswW+qT0CW0gnR9JHkXCWNbo8ccMk1
# sJatmRoSAifbgzaYbUz8+lv+IXy5GFuAmLnNbGjacB3IMGpa+lbFgih57/fIhamq
# 5VhxgaEmn/UjWyr+cPiAFWuTVIpfsOjbEAww75wURNM1Imp9NJKye1O24EspEHmb
# DmqCUcq7NqkOKIG4PVm3hDDED/WQpzJDkvu4FrIbvyTGVU01vKsg4UfcdiZ0fQ+/
# V0hf8yrtq9CkB8iIuk5bBxuPMIIHejCCBWKgAwIBAgIKYQ6Q0gAAAAAAAzANBgkq
# hkiG9w0BAQsFADCBiDELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24x
# EDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlv
# bjEyMDAGA1UEAxMpTWljcm9zb2Z0IFJvb3QgQ2VydGlmaWNhdGUgQXV0aG9yaXR5
# IDIwMTEwHhcNMTEwNzA4MjA1OTA5WhcNMjYwNzA4MjEwOTA5WjB+MQswCQYDVQQG
# EwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwG
# A1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSgwJgYDVQQDEx9NaWNyb3NvZnQg
# Q29kZSBTaWduaW5nIFBDQSAyMDExMIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIIC
# CgKCAgEAq/D6chAcLq3YbqqCEE00uvK2WCGfQhsqa+laUKq4BjgaBEm6f8MMHt03
# a8YS2AvwOMKZBrDIOdUBFDFC04kNeWSHfpRgJGyvnkmc6Whe0t+bU7IKLMOv2akr
# rnoJr9eWWcpgGgXpZnboMlImEi/nqwhQz7NEt13YxC4Ddato88tt8zpcoRb0Rrrg
# OGSsbmQ1eKagYw8t00CT+OPeBw3VXHmlSSnnDb6gE3e+lD3v++MrWhAfTVYoonpy
# 4BI6t0le2O3tQ5GD2Xuye4Yb2T6xjF3oiU+EGvKhL1nkkDstrjNYxbc+/jLTswM9
# sbKvkjh+0p2ALPVOVpEhNSXDOW5kf1O6nA+tGSOEy/S6A4aN91/w0FK/jJSHvMAh
# dCVfGCi2zCcoOCWYOUo2z3yxkq4cI6epZuxhH2rhKEmdX4jiJV3TIUs+UsS1Vz8k
# A/DRelsv1SPjcF0PUUZ3s/gA4bysAoJf28AVs70b1FVL5zmhD+kjSbwYuER8ReTB
# w3J64HLnJN+/RpnF78IcV9uDjexNSTCnq47f7Fufr/zdsGbiwZeBe+3W7UvnSSmn
# Eyimp31ngOaKYnhfsi+E11ecXL93KCjx7W3DKI8sj0A3T8HhhUSJxAlMxdSlQy90
# lfdu+HggWCwTXWCVmj5PM4TasIgX3p5O9JawvEagbJjS4NaIjAsCAwEAAaOCAe0w
# ggHpMBAGCSsGAQQBgjcVAQQDAgEAMB0GA1UdDgQWBBRIbmTlUAXTgqoXNzcitW2o
# ynUClTAZBgkrBgEEAYI3FAIEDB4KAFMAdQBiAEMAQTALBgNVHQ8EBAMCAYYwDwYD
# VR0TAQH/BAUwAwEB/zAfBgNVHSMEGDAWgBRyLToCMZBDuRQFTuHqp8cx0SOJNDBa
# BgNVHR8EUzBRME+gTaBLhklodHRwOi8vY3JsLm1pY3Jvc29mdC5jb20vcGtpL2Ny
# bC9wcm9kdWN0cy9NaWNSb29DZXJBdXQyMDExXzIwMTFfMDNfMjIuY3JsMF4GCCsG
# AQUFBwEBBFIwUDBOBggrBgEFBQcwAoZCaHR0cDovL3d3dy5taWNyb3NvZnQuY29t
# L3BraS9jZXJ0cy9NaWNSb29DZXJBdXQyMDExXzIwMTFfMDNfMjIuY3J0MIGfBgNV
# HSAEgZcwgZQwgZEGCSsGAQQBgjcuAzCBgzA/BggrBgEFBQcCARYzaHR0cDovL3d3
# dy5taWNyb3NvZnQuY29tL3BraW9wcy9kb2NzL3ByaW1hcnljcHMuaHRtMEAGCCsG
# AQUFBwICMDQeMiAdAEwAZQBnAGEAbABfAHAAbwBsAGkAYwB5AF8AcwB0AGEAdABl
# AG0AZQBuAHQALiAdMA0GCSqGSIb3DQEBCwUAA4ICAQBn8oalmOBUeRou09h0ZyKb
# C5YR4WOSmUKWfdJ5DJDBZV8uLD74w3LRbYP+vj/oCso7v0epo/Np22O/IjWll11l
# hJB9i0ZQVdgMknzSGksc8zxCi1LQsP1r4z4HLimb5j0bpdS1HXeUOeLpZMlEPXh6
# I/MTfaaQdION9MsmAkYqwooQu6SpBQyb7Wj6aC6VoCo/KmtYSWMfCWluWpiW5IP0
# wI/zRive/DvQvTXvbiWu5a8n7dDd8w6vmSiXmE0OPQvyCInWH8MyGOLwxS3OW560
# STkKxgrCxq2u5bLZ2xWIUUVYODJxJxp/sfQn+N4sOiBpmLJZiWhub6e3dMNABQam
# ASooPoI/E01mC8CzTfXhj38cbxV9Rad25UAqZaPDXVJihsMdYzaXht/a8/jyFqGa
# J+HNpZfQ7l1jQeNbB5yHPgZ3BtEGsXUfFL5hYbXw3MYbBL7fQccOKO7eZS/sl/ah
# XJbYANahRr1Z85elCUtIEJmAH9AAKcWxm6U/RXceNcbSoqKfenoi+kiVH6v7RyOA
# 9Z74v2u3S5fi63V4GuzqN5l5GEv/1rMjaHXmr/r8i+sLgOppO6/8MO0ETI7f33Vt
# Y5E90Z1WTk+/gFcioXgRMiF670EKsT/7qMykXcGhiJtXcVZOSEXAQsmbdlsKgEhr
# /Xmfwb1tbWrJUnMTDXpQzTGCGiMwghofAgEBMIGVMH4xCzAJBgNVBAYTAlVTMRMw
# EQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVN
# aWNyb3NvZnQgQ29ycG9yYXRpb24xKDAmBgNVBAMTH01pY3Jvc29mdCBDb2RlIFNp
# Z25pbmcgUENBIDIwMTECEzMAAAQEbHQG/1crJ3IAAAAABAQwDQYJYIZIAWUDBAIB
# BQCgga4wGQYJKoZIhvcNAQkDMQwGCisGAQQBgjcCAQQwHAYKKwYBBAGCNwIBCzEO
# MAwGCisGAQQBgjcCARUwLwYJKoZIhvcNAQkEMSIEIKJRfa5gvhNr5FczOTYQdnyw
# JMAxQeIjIEVA8hufTogsMEIGCisGAQQBgjcCAQwxNDAyoBSAEgBNAGkAYwByAG8A
# cwBvAGYAdKEagBhodHRwOi8vd3d3Lm1pY3Jvc29mdC5jb20wDQYJKoZIhvcNAQEB
# BQAEggEALuwZVSDEpAtYuAQUGupafps6+C2acW7ZuaJCCyCLn8BYtdojVFLXbaNX
# 8W0JQ8eiKgmtJyc0l6orFyyL7NUXSnO5WLnxB95ZUHJTn6bibyGowUIQPdD0cJjN
# OzDsL0RMUXmNv02VuraYcDtS/EUE3cBqmozAryPfzuxDIf2JS6j6vczdz3iuLLSe
# 3y0DPDtLKi0Ztk/u+pRYsunw7RAYlq30Qx47gacUyzhbJOfOho92XkWyjTwFAuEo
# vhobf05TYVt6EQu7/+GU549jUbpakkMCzOx2ubCjgkF/UwQJzJS0AoGQdr7NFnNk
# wMU3nIU69ZRzvRe5ixcWGjTrE2sP56GCF60wghepBgorBgEEAYI3AwMBMYIXmTCC
# F5UGCSqGSIb3DQEHAqCCF4YwgheCAgEDMQ8wDQYJYIZIAWUDBAIBBQAwggFaBgsq
# hkiG9w0BCRABBKCCAUkEggFFMIIBQQIBAQYKKwYBBAGEWQoDATAxMA0GCWCGSAFl
# AwQCAQUABCAfbrJzo6KkSp2T1T4JFv6G9u0bwxqetlPgToDSVSGO+gIGZ7YgQm1N
# GBMyMDI1MDIyNzE5NDE1Mi4yMDFaMASAAgH0oIHZpIHWMIHTMQswCQYDVQQGEwJV
# UzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UE
# ChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMS0wKwYDVQQLEyRNaWNyb3NvZnQgSXJl
# bGFuZCBPcGVyYXRpb25zIExpbWl0ZWQxJzAlBgNVBAsTHm5TaGllbGQgVFNTIEVT
# Tjo0QzFBLTA1RTAtRDk0NzElMCMGA1UEAxMcTWljcm9zb2Z0IFRpbWUtU3RhbXAg
# U2VydmljZaCCEfswggcoMIIFEKADAgECAhMzAAAB/xI4fPfBZdahAAEAAAH/MA0G
# CSqGSIb3DQEBCwUAMHwxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9u
# MRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRp
# b24xJjAkBgNVBAMTHU1pY3Jvc29mdCBUaW1lLVN0YW1wIFBDQSAyMDEwMB4XDTI0
# MDcyNTE4MzExOVoXDTI1MTAyMjE4MzExOVowgdMxCzAJBgNVBAYTAlVTMRMwEQYD
# VQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVNaWNy
# b3NvZnQgQ29ycG9yYXRpb24xLTArBgNVBAsTJE1pY3Jvc29mdCBJcmVsYW5kIE9w
# ZXJhdGlvbnMgTGltaXRlZDEnMCUGA1UECxMeblNoaWVsZCBUU1MgRVNOOjRDMUEt
# MDVFMC1EOTQ3MSUwIwYDVQQDExxNaWNyb3NvZnQgVGltZS1TdGFtcCBTZXJ2aWNl
# MIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEAyeiV0pB7bg8/qc/mkiDd
# JXnzJWPYgk9mTGeI3pzQpsyrRJREWcKYHd/9db+g3z4dU4VCkAZEXqvkxP5QNTtB
# G5Ipexpph4PhbiJKwvX+US4KkSFhf1wflDAY1tu9CQqhhxfHFV7vhtmqHLCCmDxh
# ZPmCBh9/XfFJQIUwVZR8RtUkgzmN9bmWiYgfX0R+bDAnncUdtp1xjGmCpdBMygk/
# K0h3bUTUzQHb4kPf2ylkKPoWFYn2GNYgWw8PGBUO0vTMKjYD6pLeBP0hZDh5P3f4
# xhGLm6x98xuIQp/RFnzBbgthySXGl+NT1cZAqGyEhT7L0SdR7qQlv5pwDNerbK3Y
# SEDKk3sDh9S60hLJNqP71iHKkG175HAyg6zmE5p3fONr9/fIEpPAlC8YisxXaGX4
# RpDBYVKpGj0FCZwisiZsxm0X9w6ZSk8OOXf8JxTYWIqfRuWzdUir0Z3jiOOtaDq7
# XdypB4gZrhr90KcPTDRwvy60zrQca/1D1J7PQJAJObbiaboi12usV8axtlT/dCeP
# C4ndcFcar1v+fnClhs9u3Fn6LkHDRZfNzhXgLDEwb6dA4y3s6G+gQ35o90j2i6am
# aa8JsV/cCF+iDSGzAxZY1sQ1mrdMmzxfWzXN6sPJMy49tdsWTIgZWVOSS9uUHhSY
# kbgMxnLeiKXeB5MB9QMcOScCAwEAAaOCAUkwggFFMB0GA1UdDgQWBBTD+pXk/rT/
# d7E/0QE7hH0wz+6UYTAfBgNVHSMEGDAWgBSfpxVdAF5iXYP05dJlpxtTNRnpcjBf
# BgNVHR8EWDBWMFSgUqBQhk5odHRwOi8vd3d3Lm1pY3Jvc29mdC5jb20vcGtpb3Bz
# L2NybC9NaWNyb3NvZnQlMjBUaW1lLVN0YW1wJTIwUENBJTIwMjAxMCgxKS5jcmww
# bAYIKwYBBQUHAQEEYDBeMFwGCCsGAQUFBzAChlBodHRwOi8vd3d3Lm1pY3Jvc29m
# dC5jb20vcGtpb3BzL2NlcnRzL01pY3Jvc29mdCUyMFRpbWUtU3RhbXAlMjBQQ0El
# MjAyMDEwKDEpLmNydDAMBgNVHRMBAf8EAjAAMBYGA1UdJQEB/wQMMAoGCCsGAQUF
# BwMIMA4GA1UdDwEB/wQEAwIHgDANBgkqhkiG9w0BAQsFAAOCAgEAOSNN5MpLiyun
# m866frWIi0hdazKNLgRp3WZPfhYgPC3K/DNMzLliYQUAp6WtgolIrativXjOG1lI
# jayG9r6ew4H1n5XZdDfJ12DLjopap5e1iU/Yk0eutPyfOievfbsIzTk/G51+uiUJ
# k772nVzau6hI2KGyGBJOvAbAVFR0g8ppZwLghT4z3mkGZjq/O4Z/PcmVGtjGps2T
# CtI4rZjPNW8O4c/4aJRmYQ/NdW91JRrOXRpyXrTKUPe3kN8N56jpl9kotLhdvd89
# RbOsJNf2XzqbAV7XjV4caCglA2btzDxcyffwXhLu9HMU3dLYTAI91gTNUF7BA9q1
# EvSlCKKlN8N10Y4iU0nyIkfpRxYyAbRyq5QPYPJHGA0Ty0PD83aCt79Ra0IdDIMS
# uwXlpUnyIyxwrDylgfOGyysWBwQ/js249bqQOYPdpyOdgRe8tXdGrgDoBeuVOK+c
# RClXpimNYwr61oZ2/kPMzVrzRUYMkBXe9WqdSezh8tytuulYYcRK95qihF0irQs6
# /WOQJltQX79lzFXE9FFln9Mix0as+C4HPzd+S0bBN3A3XRROwAv016ICuT8hY1In
# yW7jwVmN+OkQ1zei66LrU5RtAz0nTxx5OePyjnTaItTSY4OGuGU1SXaH49JSP3t8
# yGYA/vorbW4VneeD721FgwaJToHFkOIwggdxMIIFWaADAgECAhMzAAAAFcXna54C
# m0mZAAAAAAAVMA0GCSqGSIb3DQEBCwUAMIGIMQswCQYDVQQGEwJVUzETMBEGA1UE
# CBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9z
# b2Z0IENvcnBvcmF0aW9uMTIwMAYDVQQDEylNaWNyb3NvZnQgUm9vdCBDZXJ0aWZp
# Y2F0ZSBBdXRob3JpdHkgMjAxMDAeFw0yMTA5MzAxODIyMjVaFw0zMDA5MzAxODMy
# MjVaMHwxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQH
# EwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xJjAkBgNV
# BAMTHU1pY3Jvc29mdCBUaW1lLVN0YW1wIFBDQSAyMDEwMIICIjANBgkqhkiG9w0B
# AQEFAAOCAg8AMIICCgKCAgEA5OGmTOe0ciELeaLL1yR5vQ7VgtP97pwHB9KpbE51
# yMo1V/YBf2xK4OK9uT4XYDP/XE/HZveVU3Fa4n5KWv64NmeFRiMMtY0Tz3cywBAY
# 6GB9alKDRLemjkZrBxTzxXb1hlDcwUTIcVxRMTegCjhuje3XD9gmU3w5YQJ6xKr9
# cmmvHaus9ja+NSZk2pg7uhp7M62AW36MEBydUv626GIl3GoPz130/o5Tz9bshVZN
# 7928jaTjkY+yOSxRnOlwaQ3KNi1wjjHINSi947SHJMPgyY9+tVSP3PoFVZhtaDua
# Rr3tpK56KTesy+uDRedGbsoy1cCGMFxPLOJiss254o2I5JasAUq7vnGpF1tnYN74
# kpEeHT39IM9zfUGaRnXNxF803RKJ1v2lIH1+/NmeRd+2ci/bfV+AutuqfjbsNkz2
# K26oElHovwUDo9Fzpk03dJQcNIIP8BDyt0cY7afomXw/TNuvXsLz1dhzPUNOwTM5
# TI4CvEJoLhDqhFFG4tG9ahhaYQFzymeiXtcodgLiMxhy16cg8ML6EgrXY28MyTZk
# i1ugpoMhXV8wdJGUlNi5UPkLiWHzNgY1GIRH29wb0f2y1BzFa/ZcUlFdEtsluq9Q
# BXpsxREdcu+N+VLEhReTwDwV2xo3xwgVGD94q0W29R6HXtqPnhZyacaue7e3Pmri
# Lq0CAwEAAaOCAd0wggHZMBIGCSsGAQQBgjcVAQQFAgMBAAEwIwYJKwYBBAGCNxUC
# BBYEFCqnUv5kxJq+gpE8RjUpzxD/LwTuMB0GA1UdDgQWBBSfpxVdAF5iXYP05dJl
# pxtTNRnpcjBcBgNVHSAEVTBTMFEGDCsGAQQBgjdMg30BATBBMD8GCCsGAQUFBwIB
# FjNodHRwOi8vd3d3Lm1pY3Jvc29mdC5jb20vcGtpb3BzL0RvY3MvUmVwb3NpdG9y
# eS5odG0wEwYDVR0lBAwwCgYIKwYBBQUHAwgwGQYJKwYBBAGCNxQCBAweCgBTAHUA
# YgBDAEEwCwYDVR0PBAQDAgGGMA8GA1UdEwEB/wQFMAMBAf8wHwYDVR0jBBgwFoAU
# 1fZWy4/oolxiaNE9lJBb186aGMQwVgYDVR0fBE8wTTBLoEmgR4ZFaHR0cDovL2Ny
# bC5taWNyb3NvZnQuY29tL3BraS9jcmwvcHJvZHVjdHMvTWljUm9vQ2VyQXV0XzIw
# MTAtMDYtMjMuY3JsMFoGCCsGAQUFBwEBBE4wTDBKBggrBgEFBQcwAoY+aHR0cDov
# L3d3dy5taWNyb3NvZnQuY29tL3BraS9jZXJ0cy9NaWNSb29DZXJBdXRfMjAxMC0w
# Ni0yMy5jcnQwDQYJKoZIhvcNAQELBQADggIBAJ1VffwqreEsH2cBMSRb4Z5yS/yp
# b+pcFLY+TkdkeLEGk5c9MTO1OdfCcTY/2mRsfNB1OW27DzHkwo/7bNGhlBgi7ulm
# ZzpTTd2YurYeeNg2LpypglYAA7AFvonoaeC6Ce5732pvvinLbtg/SHUB2RjebYIM
# 9W0jVOR4U3UkV7ndn/OOPcbzaN9l9qRWqveVtihVJ9AkvUCgvxm2EhIRXT0n4ECW
# OKz3+SmJw7wXsFSFQrP8DJ6LGYnn8AtqgcKBGUIZUnWKNsIdw2FzLixre24/LAl4
# FOmRsqlb30mjdAy87JGA0j3mSj5mO0+7hvoyGtmW9I/2kQH2zsZ0/fZMcm8Qq3Uw
# xTSwethQ/gpY3UA8x1RtnWN0SCyxTkctwRQEcb9k+SS+c23Kjgm9swFXSVRk2XPX
# fx5bRAGOWhmRaw2fpCjcZxkoJLo4S5pu+yFUa2pFEUep8beuyOiJXk+d0tBMdrVX
# VAmxaQFEfnyhYWxz/gq77EFmPWn9y8FBSX5+k77L+DvktxW/tM4+pTFRhLy/AsGC
# onsXHRWJjXD+57XQKBqJC4822rpM+Zv/Cuk0+CQ1ZyvgDbjmjJnW4SLq8CdCPSWU
# 5nR0W2rRnj7tfqAxM328y+l7vzhwRNGQ8cirOoo6CGJ/2XBjU02N7oJtpQUQwXEG
# ahC0HVUzWLOhcGbyoYIDVjCCAj4CAQEwggEBoYHZpIHWMIHTMQswCQYDVQQGEwJV
# UzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UE
# ChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMS0wKwYDVQQLEyRNaWNyb3NvZnQgSXJl
# bGFuZCBPcGVyYXRpb25zIExpbWl0ZWQxJzAlBgNVBAsTHm5TaGllbGQgVFNTIEVT
# Tjo0QzFBLTA1RTAtRDk0NzElMCMGA1UEAxMcTWljcm9zb2Z0IFRpbWUtU3RhbXAg
# U2VydmljZaIjCgEBMAcGBSsOAwIaAxUAqROMbMS8JcUlcnPkwRLFRPXFspmggYMw
# gYCkfjB8MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UE
# BxMHUmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBvcmF0aW9uMSYwJAYD
# VQQDEx1NaWNyb3NvZnQgVGltZS1TdGFtcCBQQ0EgMjAxMDANBgkqhkiG9w0BAQsF
# AAIFAOtrKhMwIhgPMjAyNTAyMjcxODE0NDNaGA8yMDI1MDIyODE4MTQ0M1owdDA6
# BgorBgEEAYRZCgQBMSwwKjAKAgUA62sqEwIBADAHAgEAAgIEFjAHAgEAAgISnzAK
# AgUA62x7kwIBADA2BgorBgEEAYRZCgQCMSgwJjAMBgorBgEEAYRZCgMCoAowCAIB
# AAIDB6EgoQowCAIBAAIDAYagMA0GCSqGSIb3DQEBCwUAA4IBAQA1/T594UlpG+K9
# VMx0mJi+PtAwb4ArLHiW40z473WkI+wWglBN9Yv82u4NzxaA89ohqSVwgZRpKGGM
# KlSfAWMrb0HTYUM4xyhwVEU+pgclZnGCXU46/9zYoU9W8tKmUB8Pph/RxgFixB0W
# 48o63BUxy8cHDDEryLgWC4P/Z0gdgg5lPnfJ3J1xIAn2UT84zHPa61dMNhnqzORQ
# K9sVcCykP63AC1AnbpsxBAC+UM3LcQoaTtn/cHYhwINf9DXG+LdwpZkTJ8uoTJPB
# MegHSCXzDNL8R7/TuuMxjfup9J+MXi+VqIcBvKDUf+1yU1bV53IXHJJfbiDPwX4I
# K4mkJXwvMYIEDTCCBAkCAQEwgZMwfDELMAkGA1UEBhMCVVMxEzARBgNVBAgTCldh
# c2hpbmd0b24xEDAOBgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBD
# b3Jwb3JhdGlvbjEmMCQGA1UEAxMdTWljcm9zb2Z0IFRpbWUtU3RhbXAgUENBIDIw
# MTACEzMAAAH/Ejh898Fl1qEAAQAAAf8wDQYJYIZIAWUDBAIBBQCgggFKMBoGCSqG
# SIb3DQEJAzENBgsqhkiG9w0BCRABBDAvBgkqhkiG9w0BCQQxIgQgdTlfKsWYtZIA
# ZtocxUecnxBGc8hOkalTFL6H08P86mIwgfoGCyqGSIb3DQEJEAIvMYHqMIHnMIHk
# MIG9BCDkMu++yQJ3aaycIuMT6vA7JNuMaVOI3qDjSEV8upyn/TCBmDCBgKR+MHwx
# CzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRt
# b25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xJjAkBgNVBAMTHU1p
# Y3Jvc29mdCBUaW1lLVN0YW1wIFBDQSAyMDEwAhMzAAAB/xI4fPfBZdahAAEAAAH/
# MCIEIHc9VIsKh4zD+krHurD7jD9yd+ViCzZd1hAl1i4dKMfQMA0GCSqGSIb3DQEB
# CwUABIICALhgOvP367lyiJ7vyW9eriRqp1nqL82973ii76xF6IKJi8iMtJ4kqC4r
# kNLQkSwIl9LQeKT7KuW+j02lx0HQWxKxotCQNe20Wd4TCDViUEeUDnnWIGyr7rs7
# OErC/18K6Vxg5au4Cmumx1vpmptVNfeu9F7kPO1fb2GH3d+/nnqQJ34dgOH5bIqa
# SqPe+44zGOHPLB5t6XsNRGXnZ6Fv2OspK6OgztQhvDLzPOmiHey7Ioo3tPIWwnu4
# ja1qJNklr4s2fQFPK0yGJsJxoMTEIbTVvZYWa0fuRHsSq8lnkMi4yHeoIVNOXcPL
# MNMVHEQ7QfGku2ej8ZdwQJt+Vp2Sa5Y4hJsVEDTMfr/+IwUkaLO72vtndj5w4tT5
# J8b8AjUa5onS9R3rQLcXz/Bki4wxjYomxJnABRONDAH3dxeHEnpli1sDETVG2kvN
# h9FxLup2vN4d7Em/KXbQWV7lEn8/ct00qpimvhIMS4+YDj9pJtx+lzmIqXHI5Si0
# FSADmcF7oIyv6bCFlAiQ2h400foIv6bYVIcMdQNPvY+Tcfz1g9vkcs20LJPCt6g1
# ZTv2LPRNcaui+PL4lZ5OGNTR7V8vhemTZaUp1e1D9JddO+yKAboMeIm/iMiRkt6D
# edz3MZIY3sNxm0QwI0Kj2LFXAbJ+TVqPR3VvsdFKd1g87u/utF3l
# SIG # End signature block
