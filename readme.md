# Teste Thomas Greg API

Para que funcione corretamente, siga os passos abaixo:

- Altere a string de conexão no arquivo appsettings.Development.json para a do seu banco;
- Crie as tabelas e procedures na ordem em que estão nomeadas dentro do diretório **/Infrastracture/ThomasGreg.Teste.Infra.SqlServer/SQL**;
- Baixe o **Insomnia Core** https://insomnia.rest/download/
- Importe o arquivo **Insomnia_2020-06-19.json** que está na raiz do projeto;
- Execute o projeto **ThomasGreg.Teste.Api**;
- Apesar do Swagger estar habilitado, como tem autenticação, ele não funciona corretamente, por isso é recomendável o uso do Insomnia;
- Fique atento, pois, como está rodando em https, o Insomnia vai dar o erro de SSL, portanto, abra o menu **Application > Preferences** e na aba **General** procure pela seção **Request/Response** e desabilite a opção **Validate certificates**.
- Lembre-se que após criar o usuário, é necessário autenticar o mesmo para conseguir utilizar os demais endpoints.

Qualquer dúvida estou à disposição no número (11) 98725-8313.
