# PgP Example Project

Este projeto demonstra como usar a biblioteca `PgpCore` para criptografia e descriptografia de arquivos usando o padrão PGP (Pretty Good Privacy). O projeto inclui exemplos de geração de chaves, criptografia e descriptografia de arquivos.

## Como Funciona a Criptografia PGP
A PGP (Pretty Good Privacy) combina técnicas de criptografia, compressão e hashing para proteger dados, similar a métodos como SSL para sites e SFTP para transferências seguras de arquivos.

### Processo de Criptografia PGP
**1. Geração da Chave de Sessão:**
 * A PGP cria uma chave de sessão única e aleatória, que é uma chave temporária usada para criptografar o conteúdo da mensagem.

**2. Criptografia da Chave de Sessão:**
 * A chave de sessão é criptografada com a chave pública do destinatário. Isso garante que apenas o destinatário, que possui a chave privada correspondente, possa descriptografar a chave de sessão.

**3. Descriptografia da Mensagem:**
 * O destinatário usa sua chave privada para descriptografar a chave de sessão e, em seguida, utiliza essa chave para descriptografar a mensagem.

### Algoritmos Utilizados
 * **RSA:** Um sistema de chave pública tradicional que usa dois números primos para criar chaves públicas e privadas. É seguro, mas pode ser lento para criptografia de grandes volumes de dados.
 * **Diffie-Hellman:** Permite a troca segura de chaves privadas compartilhadas para criptografar dados em canais inseguros. Utiliza o algoritmo CAST e o SHA-1 para criar hashes de segurança.

### Benefícios da Criptografia PGP
 * **Eficiência:** A PGP utiliza algoritmos rápidos para criptografar dados, economizando tempo e espaço.
 * **Compressão:** A PGP comprime os dados antes da criptografia para reduzir o tamanho do arquivo e acelerar a transmissão.
 * **Assinaturas Digitais:** Utiliza algoritmos de hashing para criar resumos matemáticos das mensagens, garantindo a autenticidade e integridade dos dados.

PGP combina criptografia simétrica e assimétrica para proteger dados durante a transmissão, oferecendo uma abordagem robusta e eficiente para a segurança da informação.

## Como Funciona a Criptografia de Arquivos com PGP
O PGP utiliza o algoritmo RSA, conhecido por sua segurança robusta e resistência à quebra, tornando-o ideal para criptografar arquivos. Quando combinado com ferramentas de detecção de ameaças, o PGP proporciona uma proteção adicional eficaz. Softwares de criptografia de arquivos baseados em PGP simplificam o processo de proteção de dados, facilitando a criptografia e descriptografia para os usuários.

**1. Gerar Chaves**
  * **Chave Pública:** Usada para criptografar dados. Pode ser compartilhada com outras pessoas.
  * **Chave Privada:** Usada para descriptografar dados. Deve ser mantida em segredo.

  *Comando para gerar chaves:*
  ```csharp
  PgP.GenerateKey(publicKey, privateKey, username, password);
  ```

**2. Criptografar Arquivos**
  * **Preparar o Arquivo de Entrada:** O arquivo que você deseja criptografar.
  * **Criptografar:** O arquivo é criptografado com uma chave secreta gerada aleatoriamente. Esta chave secreta é então criptografada com a chave pública do destinatário.

  *Comando para criptografar um arquivo:*
  ```csharp
    await PgP.EncryptAsync(publicKey, inputFile, encryptedFile);
  ```

**3. Descriptografar Arquivos**
  * **Preparar o Arquivo Criptografado:** O arquivo que foi criptografado e precisa ser recuperado.
  * **Descriptografar:** A chave secreta é recuperada usando a chave privada, e o conteúdo do arquivo é então descriptografado com a chave secreta.

  *Comando para descriptografar um arquivo:*
  ```csharp
    await PgP.DecryptAsync(decryptedFile, inputFile, privateKey, password);
  ```

## Estrutura do Projeto

- **Program.cs**: Ponto de entrada principal do aplicativo.
- **PgP.cs**: Classe que contém métodos para criptografia, descriptografia e geração de chaves.
- **keys/**: Pasta para armazenar as chaves pública e privada.
- **files/**
  - **input/**: Arquivos a serem criptografados.
  - **encrypteds/**: Arquivos criptografados.
  - **decrypteds/**: Arquivos descriptografados.

## Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) (versão recomendada: 6.0 ou superior)
- [PgpCore](https://www.nuget.org/packages/PgpCore) (biblioteca para PGP)

## Configuração do Projeto

1. **Clone o repositório**

   ```sh
   git clone https://github.com/
   cd pgp-example-project
   ```

2. **Restaurar as dependências**

    ```sh
    dotnet restore
    ```

3. **Configurar as Chaves**

    Para gerar as chaves públicas e privada, execute o seguinte código no **Program.cs**: 
    ```bash 
    GenerateKeys();
    ```

    Isso criará as chaves **publicKey.asc** e **privateKey.asc** na pasta **keys/**.

4. **Criptografar Arquivos**

    Adicione arquivos à pasta **files/input/** e execute o método EncryptFilesAsync para criptografá-los.

5. **Descriptografar Arquivos**

    Adicione arquivos criptografados à pasta **files/encrypteds/** e execute o método DecryptFilesAsync para descriptografá-los.

## Uso

#### Executar o Projeto
Para executar o projeto, compile e execute o código:
```bash 
dotnet run
```

#### Gerar Chaves
Para gerar novas chaves, descomente e execute o método **GenerateKey()** no Program.cs.

#### Criptografar Arquivos
Os arquivos na pasta **files/input/** serão criptografados e salvos na pasta **files/encrypteds/**.

#### Descriptografar Arquivos
Os arquivos na pasta **files/encrypteds/** serão descriptografados e salvos na pasta **files/decrypteds/**.