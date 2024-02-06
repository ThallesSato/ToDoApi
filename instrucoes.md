# Instruções para rodar a api

## Banco de dados (SqlServer)

### Docker
- 1 - Clone a imagem usando o seguinte comando:  
<code>docker pull mcr.microsoft.com/mssql/server:2022-latest</code>
- 2 - Rode o container usando o comando:  
<code>
  docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<YourStrong@Passw0rd>"   
  -p 1433:1433 --name sqlserver --hostname sqlserver 
  -d  
  mcr.microsoft.com/mssql/server:2022-latest
</code>

- 3 - [Continuação](#Continuação)

### SqlServer
- 1 - Crie o banco com o nome = sqlserver, senha = <YourStrong@Passw0rd> e porta = 1433
- 2 - [Continuação](#Continuação)

### Continuação

- Independente do modo usado, caso não seja possivel usar as configurações ja programadas na api, 
configure no arquivo appsettings.json para atender as especificações de sua necessidade

## Aplicação

- Clone a aplicação do github
- Configure o bd de uma das formas acima
- A migração de bd ja está criada
- Rode o ef migrations update para criar o banco de dados e tabelas
- Rode o programa e teste :)

## Swagger

- Para acessar o swagger, navegue até <code>http://localhost:5266/swagger/index.html</code>
troque a porta 5266 conforme necessidade
