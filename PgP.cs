using Org.BouncyCastle.Bcpg;
using PgpCore;

namespace Pgp.Example
{
    /// <summary>
    /// Fornece métodos para criptografia e descriptografia PGP, bem como geração de chaves.
    /// </summary>
    public static class PgP
    {
        /// <summary>
        /// Criptografa um arquivo usando a chave pública especificada.
        /// </summary>
        /// <param name="publicKeyFile">O arquivo contendo a chave pública.</param>
        /// <param name="inputFile">O arquivo a ser criptografado.</param>
        /// <param name="outputFile">O arquivo para onde os dados criptografados serão escritos.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public static async Task EncryptAsync(FileInfo publicKeyFile, FileInfo inputFile, FileInfo outputFile)
        {
            var encryptionKeys = new EncryptionKeys(publicKeyFile);
            using var pgp = new PGP(encryptionKeys)
            {
                SymmetricKeyAlgorithm = SymmetricKeyAlgorithmTag.Aes256
            };

            await pgp.EncryptFileAsync(inputFile, outputFile);
        }

        /// <summary>
        /// Gera um par de chaves pública e privada.
        /// </summary>
        /// <param name="publicKeyFile">O arquivo para onde a chave pública será salva.</param>
        /// <param name="privateKeyFile">O arquivo para onde a chave privada será salva.</param>
        /// <param name="username">O nome de usuário associado ao par de chaves.</param>
        /// <param name="password">A senha para proteger a chave privada.</param>
        public static void GenerateKeys(FileInfo publicKeyFile, FileInfo privateKeyFile, string username, string password)
        {
            using var pgp = new PGP
            {
                SymmetricKeyAlgorithm = SymmetricKeyAlgorithmTag.Aes256
            };

            pgp.GenerateKey(publicKeyFile, privateKeyFile, username, password);
        }

        /// <summary>
        /// Descriptografa um arquivo usando a chave privada e a senha especificadas.
        /// </summary>
        /// <param name="inputFile">O arquivo a ser descriptografado.</param>
        /// <param name="outputFile">O arquivo para onde os dados descriptografados serão escritos.</param>
        /// <param name="privateKeyFile">O arquivo contendo a chave privada.</param>
        /// <param name="password">A senha usada para acessar a chave privada.</param>
        /// <returns>Uma tarefa que representa a operação assíncrona.</returns>
        public static async Task DecryptAsync(FileInfo inputFile, FileInfo outputFile, FileInfo privateKeyFile, string password)
        {
            var encryptionKeys = new EncryptionKeys(privateKeyFile, password);
            using var pgp = new PGP(encryptionKeys)
            {
                SymmetricKeyAlgorithm = SymmetricKeyAlgorithmTag.Aes256
            };

            await pgp.DecryptFileAsync(inputFile, outputFile);
        }
    }
}
