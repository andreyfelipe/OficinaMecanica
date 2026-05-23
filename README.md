
Andrey Felipe 23/05/2026


Este projeto é uma API REST construída com .NET 9, o framework da Microsoft para desenvolvimento do projeto do desafio para .net junior na empresa Code n’ App - codenapp.com  Tecnologia e Inovação para sua empresa
A Code n’ App leva inovação através de tecnologias e serviços de ponta, oferecendo soluções eficientes e acessíveis para o seu negócio.




Tecnologias utilizadas
ASP.NET Core
É o framework principal usado para criar a API. Ele cuida de receber as requisições HTTP (GET, POST, etc.), direcionar para o controller certo e devolver a resposta. É como o "esqueleto" da aplicação.

Entity Framework Core
É um ORM (Object-Relational Mapper) — uma ferramenta que permite trabalhar com o banco de dados usando classes C# em vez de escrever SQL na mão. Por exemplo, em vez de escrever INSERT INTO Orcamentos..., você simplesmente faz _context.Orcamentos.Add(orcamento) e o EF cuida do resto.

Migrations
As migrations são uma funcionalidade do Entity Framework que mantém o banco de dados sincronizado com o código. Toda vez que você muda um model (adiciona uma coluna, cria uma tabela nova), você roda dotnet ef migrations add NomeDaMigration para gerar o script de alteração, e dotnet ef database update para aplicar no banco.

SQL Server
É o banco de dados relacional utilizado para persistir os dados da aplicação. Neste projeto, a conexão é feita via SQL Server Express (versão gratuita), configurada no arquivo appsettings.json através da ConnectionStrings:DefaultConnection.

Swagger (Swashbuckle)
É uma ferramenta que gera automaticamente uma interface visual para testar a API direto no navegador, sem precisar de ferramentas externas como Postman. Basta acessar http://localhost:5000/swagger com a aplicação rodando e você verá todos os endpoints disponíveis, podendo testá-los ali mesmo.

Como rodar o projeto
Pré-requisitos: .NET 9 SDK e SQL Server Express instalados.


# Restaurar dependências
dotnet restore

# Criar o banco de dados e aplicar as migrations
dotnet ef database update

# Rodar a aplicação
dotnet run
Após iniciar, acesse http://localhost:5000/swagger para explorar os endpoints da API.

Testes realizados:

Aplicação rodando - <img width="1684" height="954" alt="image" src="https://github.com/user-attachments/assets/93ab6aa5-e7e2-44a1-bffb-64bfc69d1adb" />

POST - <img width="1228" height="938" alt="image" src="https://github.com/user-attachments/assets/f04760f8-e090-4bcb-a16d-7690a4fe2d79" />

Refletir no Banco - <img width="1491" height="813" alt="image" src="https://github.com/user-attachments/assets/cd7e64da-2457-4dfa-88bc-6f9af8b8be8d" />




