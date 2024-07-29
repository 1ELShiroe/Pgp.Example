using Pgp.Example;

class Program
{
    private static readonly string Username = "elshiroe";
    private static readonly string Password = "123456789";
    private static readonly FileInfo PublicKey = new("./keys/publicKey.asc");
    private static readonly FileInfo PrivateKey = new("./keys/privateKey.asc");

    /// <summary>
    /// Ponto de entrada principal para o aplicativo.
    /// </summary>
    /// <param name="args">Argumentos da linha de comando.</param>
    /// <returns>Tarefa representando a execução assíncrona.</returns>
    public static async Task Main(string[] args)
    {
        // Gera as chaves se necessário
        // GenerateKeys();

        // Criptografa arquivos
        await EncryptFilesAsync();

        // Descriptografa arquivos
        await DecryptFilesAsync();

        Console.WriteLine("Operações concluídas com sucesso.");
    }

    /// <summary>
    /// Criptografa todos os arquivos na pasta de entrada.
    /// </summary>
    /// <returns>Tarefa representando a operação assíncrona.</returns>
    private static async Task EncryptFilesAsync()
    {
        string path = "./files/";
        string[] fileEntries = Directory.GetFiles($"{path}/input");

        foreach (string filePath in fileEntries)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            FileInfo inputFile = new(filePath);
            FileInfo encryptedFile = new(@$"{path}/encrypteds/{fileName}.pgp");

            await PgP.EncryptAsync(PublicKey, inputFile, encryptedFile);
        }
    }

    /// <summary>
    /// Descriptografa todos os arquivos na pasta de arquivos criptografados.
    /// </summary>
    /// <returns>Tarefa representando a operação assíncrona.</returns>
    private static async Task DecryptFilesAsync()
    {
        string path = "./files/";
        string[] fileEntries = Directory.GetFiles($"{path}/encrypteds");

        foreach (string filePath in fileEntries)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            FileInfo inputFile = new(filePath);
            FileInfo decryptedFile = new(@$"{path}/decrypteds/{fileName}.pdf");

            await PgP.DecryptAsync(inputFile, decryptedFile, PrivateKey, Password);
        }
    }

    /// <summary>
    /// Gera chaves pública e privada.
    /// </summary>
    private static void GenerateKeys()
    {
        // Cria o diretório se não existir
        Directory.CreateDirectory("./keys");

        PgP.GenerateKeys(PublicKey, PrivateKey, Username, Password);

        Console.WriteLine("Chaves geradas com sucesso.");
    }
}
