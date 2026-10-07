# Sistema de Artigos - API Backend

API RESTful desenvolvida como parte de estudos em C# e arquitetura web, aplicando conceitos modernos de desenvolvimento de software e boas práticas de back-end.

## 🚀 Tecnologias Utilizadas
- **C# / .NET**
- **ASP.NET Core Web API**
- **Entity Framework Core (EF Core)**
- **MySQL / MariaDB**
- **Swagger / OpenAPI**

## 🛠️ Arquitetura e Módulos
O projeto segue uma arquitetura em camadas bem definida (**Controller -> Service -> Repository**), contemplando:
- **Usuários:** Gestão de contas e perfis.
- **Artigos & Rascunhos:** Criação, publicação, histórico de versões e rascunhos.
- **Interações:** Comentários (com suporte a árvore de respostas/auto-relacionamento) e Favoritos.
- **Categorias:** Organização de artigos via relação N:N.
