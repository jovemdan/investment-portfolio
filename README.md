# Carteira de Investimento

## Tecnologias e patterns utilizados.

#### .NET 7
#### Entity Framework
#### Docker
#### SqlServer
#### FluentValidations
#### CQRS
#### Mediator
#### DDD
#### Swagger


## Instruções para executar o projeto

#### ⚠️ Docker e Docker Compose
  Para executar o projeto é necessário que você tenha o Docker e o Docker Compose instalados no seu computador, caso não tenha, você pode instalar os dois a partir do site oficial do Docker: [https://www.docker.com/](https://www.docker.com/)

<br />

#### 1 - Clone o repositório
  Faça o clone do repositório no seu computador, no diretório onde você deseja executar o projeto.


  ```sh
  git clone https://github.com/jovemdan/investment-portfolio.git
  ```

#### 2 - Acesse a pasta do projeto e execute o comando:
  ```sh
  docker-compose up
  ```

#### 3 - Navegue até a pasta Infrastructure e execute o comando abaixo para criação do banco:
 ```sh
  cd InvestmentPortfolio.Infrastructure
  ```
 ```sh
  dotnet ef --startup-project ../InvestmentPortfolio.API/ database update
  ```

## O banco de dados

<p align="center">
  <h4>Estrutura do banco de dados</h4>
  <img width="726" alt="diagrama2" src="https://github.com/jovemdan/investment-portfolio/assets/25301052/ae50d03d-5514-49a6-8e09-4b9e85b3c02b">
</p>

## Rotas da API

#### 3 - Administrador
<details>
  <summary><strong>POST em /administrador-register</><a><strong></summary>

  - Rota para cadastrar um administrador

  ```json
{
  "name": "ADM",
  "email": "adm@gmail.com"
}
  ```
</details>

<details>
  <summary><strong>GET em /administrador-register</><a><strong></summary>

  - Rota para buscar todos os administradores

  ```json
{
  "name": "ADM",
  "email": "adm@gmail.com"
}
  ```
</details>

