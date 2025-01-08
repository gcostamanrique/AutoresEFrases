# AutoresEFrases

**AutoresEFrases** é um projeto desenvolvido em ASP.NET Core MVC que permite pesquisar e incluir autores e frases em um banco de dados SQL Server.

O objetivo do projeto é demonstrar a aplicação de diversas técnicas de desenvolvimento de software, incluindo:  
- Utilização dos padrões de projeto **Repository**, **Unit of Work**, **Factory** e **DTO**;  
- Emprego dos pacotes **FluentValidation** para ASP.NET Core e **Entity Framework Core**;  
- Adoção de práticas de programação alinhadas aos princípios **SOLID** e organização do código baseada no modelo **DDD** (Domain-Driven Design).

## Configuração do Projeto  

Para que o projeto funcione corretamente, é necessário seguir os passos abaixo:  

1. **Criar a base de dados:**  
   - No projeto, está disponível uma query SQL que pode ser executada no SQL Server.
   - No projeto `AutoresEFrasesVisualizacao` acesse a pasta `Arquivo` e visualize o arquivo `QuerySQLServer.txt`. 
   - Essa query realiza a criação de um banco de dados, duas tabelas (`TB_AUTOR` e `TB_FRASE`) e insere registros iniciais nas tabelas.  

2. **Atualizar o arquivo `appsettings.json`:**  
   - Localize o arquivo `appsettings.json` no projeto `AutoresEFrasesVisualizacao`.  
   - Atualize o campo `DefaultConnection` com a sua string de conexão ao banco de dados.  

Seguindo essas etapas, o projeto estará configurado e pronto para uso.
