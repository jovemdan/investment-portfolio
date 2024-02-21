# investment-portfolio

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
  <img width="812" alt="diagrama" src="https://github.com/jovemdan/investment-portfolio/assets/25301052/fd3b0cfe-e3e6-4e16-ba76-78b86bf61d52">

</p>
