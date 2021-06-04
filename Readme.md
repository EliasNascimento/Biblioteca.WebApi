#  Projeto Biblioteca WebAPI

# Introdução

* Este projeto é a uma webAPI, desenvolvido em .netCore 3.1, utilizando DI (injeção de dependência) e utilizando orm hibrido RepoDB. 

* É a parte backend do projeto Biblioteca, desenvolvido com objetivo de gerenciar livros de uma biblioteca, com opções de criar, editar , listar e atualizar. Foi separado em duas partes frontend e backend, sendo esta a parte do backend. 

* Aqui, temos as partes das controllers, rotas mapeadas, que chamam as classes de repositório, que é responsável por fazer a persistência no banco de dados.

* O banco de dados utilizado foi o SqlServer. 
  
* O ORM (Object Relational Mapper) utilizado foi o ORM Híbrido open-source RepoDb, versão="1.12.7".

* Quais tecnologias foram utilizadas? (.netcore 3.1, RepoDb, Serilog)

* Como desafio, foi utilizado um orm híbrido open-source RepoDb, que é uma biblioteca para fazer a persistência em banco de dados. Este orm é de fácil implementação e é considerado híbrido por ser mais completo que um micro-ORM e ser mais simples que um Macro-ORM.