# EducaMais

## Descrição

O **EducaMais** é uma aplicação focada na gestão de alunos de uma plataforma educacional. O objetivo do projeto é fornecer uma estrutura de backend robusta para o gerenciamento de informações de alunos, incluindo cadastro, atualização, remoção e consulta de dados como nome, CPF, e-mail, data de nascimento e endereço.

Esse projeto está sendo desenvolvido utilizando as tecnologias **.NET 8**, **Entity Framework**, **AutoMapper** e **SQL Server**, com uma arquitetura que segue os princípios de **Domain-Driven Design (DDD)** e **Clean Architecture**.

A aplicação oferece uma interface API RESTful para facilitar a integração com outros sistemas e a manipulação dos dados dos alunos.

## Funcionalidades

- **Cadastro de Aluno**: Permite adicionar novos alunos ao sistema, validando informações como CPF único e requisitos de idade.
- **Atualização de Dados**: Permite a atualização dos dados de um aluno, como nome, e-mail, senha e endereço.
- **Remoção de Aluno**: Permite excluir um aluno do sistema com base no CPF.
- **Consulta de Aluno**: Permite buscar um aluno específico ou todos os alunos cadastrados.

## Tecnologias Utilizadas

- **.NET 8**: Framework principal utilizado para o desenvolvimento da aplicação.
- **Entity Framework**: ORM para interação com o banco de dados.
- **AutoMapper**: Ferramenta para mapeamento de objetos entre as camadas do sistema.
- **SQL Server**: Banco de dados utilizado para armazenar os dados persistentes.

## Estrutura do Projeto

O projeto segue a arquitetura **Clean Architecture**, dividindo a aplicação nas seguintes camadas:

- **Core**: Contém as entidades de domínio e as interfaces.
- **Application**: Contém os serviços que implementam a lógica de negócio.
- **Infra**: Implementação de repositórios e acesso ao banco de dados.
- **API**: A camada de apresentação da aplicação, que expõe os endpoints para interação com o cliente.

