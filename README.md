# forum-aspnet-core6
Projeto .NET C# com fluxo simples de cadastro, edição e exclusão de topicos com login simples tudo com RazorPages

# instruções
  dotnet ef database update (Na pasta da aplicação repository)
  dotnet run seeddata (Na pasta da aplicação web)
   
  usuários padrões
  username: maria / password: 123
  username: miguel / password: 123

# fluxo de negócio
- A visualização dos tópicos é pública
- Apenas os usuários autenticados podem cadastrar novos tópicos
- Os usuários autenticados podem editar/excluir apenas seus próprios tópicos

# tecnologias
- .NET 6.0
- EntityFrameWork (With SQLServer)
- Migration
- Bootstrap 5

# padrões de projeto
- Projeto simples porem dividido em camadas distintas (single responsibility principle)
- Contratos de persistência em base de dados (dependency injection)
- Base de dados criada apartir do domínio (code first)
- Versionamento das alterações na base (migration)
- Projeto MVC padão (Only Razor Pages)
- Arquivo configurado para popular inicialmente a base de dados (dotnet run seeddata)

