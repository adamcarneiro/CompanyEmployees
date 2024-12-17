# CompanyEmployee

### Projeto desenvolvido em **C#** com **Onion Architecture**  

## 📑 **Descrição do Projeto**

O projeto **CompanyEmployee** é uma aplicação estruturada para gerenciar informações de empresas e funcionários. A aplicação utiliza a **Onion Architecture** para promover **separação de responsabilidades**, **testabilidade** e **facilidade de manutenção**.  

---

## 🛠 **Tecnologias Utilizadas**

- **C# (.NET 6/7)**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server** (ou outra base de dados relacional)
- **Dependency Injection**
- **AutoMapper** (para mapeamento de DTOs)
- **Swagger** (para documentação da API)
- **Unit Testing Frameworks** (xUnit/NUnit)

---

## 🎯 **Arquitetura - Onion Architecture**  

A **Onion Architecture** organiza o projeto em **camadas** com dependências direcionadas para dentro. Segue o padrão de **Clean Architecture**, separando regras de negócios e infraestrutura.

**Estrutura das Camadas:**  

1. **Domain (Núcleo/Entidade)**  
   - Contém as **entidades** e **contratos** do domínio.  
   - Independente de frameworks e tecnologias externas.  

2. **Application (Lógica de Negócios)**  
   - Contém os **casos de uso** e serviços específicos do projeto.  
   - Regras de negócios são implementadas aqui.  

3. **Infrastructure (Infraestrutura)**  
   - Implementação de interfaces da camada de **Application**.  
   - Gerenciamento de persistência (EF Core, Repositórios, etc.).  

4. **Presentation (Camada Externa)**  
   - API (Controllers e DTOs).  
   - Comunicação com usuários e outras aplicações.  

---

## 📁 **Estrutura do Projeto**  

```plaintext
CompanyEmployee/
│
├── CompanyEmployee.Domain/       # Entidades e contratos
│   ├── Entities/
│   ├── Interfaces/
│
├── CompanyEmployee.Application/  # Regras de negócio e serviços
│   ├── Services/
│   ├── DTOs/
│
├── CompanyEmployee.Infrastructure/ # Repositórios e DB Context
│   ├── Repositories/
│   ├── Data/
│
├── CompanyEmployee.Presentation/ # API Controllers e DTOs
│   ├── Controllers/
│   ├── Swagger/
│
└── CompanyEmployee.Tests/        # Testes Unitários e de Integração
    ├── Application.Tests/
    ├── Infrastructure.Tests/
    └── Presentation.Tests/
```
---

🚀 ## **Como Executar o Projeto**
**Pré-rquisitos**
- **.NET SDK** instalado na máquina
- **SQL Server** configurado e em execução

**Passos:**
1. Clone o repositório:
   `git clone https://github.com/adamcarneiro/CompanyEmployees`
`cd CompanyEmployee`
2. Configure a connection string no appsettings.json:
`"ConnectionStrings": {
   "DefaultConnection": "Server=SEU_SERVIDOR;Database=CompanyEmployeeDB;Trusted_Connection=True;"
}
`
3. Execute as migrações para criar o banco de dados:
   `dotnet ef database update`

4. Execute a aplicação:
   `dotnet run --project CompanyEmployee.Presentation`
   
5. Acesse a API no navegador via Swagger:
   - https://localhost:5001/swagger

---

## 🧪 Testes

Execute os testes unitários:

`dotnet test
`

---

## 📚 Funcionalidades Principais

- CRUD de Empresas
- CRUD de Funcionários
- Associação entre Empresas e Funcionários
- Documentação automática com Swagger

---

## 🔗 Endpoints Principais

|Metódo | Endpoint | Descrição |
|-------|----------|-----------|
|GET | /api/companies | Retorna todas as empresas|
|Get | /api/companiesId/employes | Retorna todos os usuarios de uma empresa|

##👨‍💻 Contribuições
Sinta-se à vontade para contribuir com melhorias:

1. Faça um Fork do projeto.
2. Crie uma branch para a sua funcionalidade: `git checkout -b feature/minha-funcionalidade
`
3. Faça o commit das suas alterações: `git commit -m "Adicionei nova funcionalidade"`
4. Envie a branch: `git push origin feature/minha-funcionalidade`
5. Abra um **Pull Request**.

---

## ©️ Licença
Este projeto está licenciado sob a licença MIT.

---

## 📞 Contato
Nome: Adamastor

Email: adamchimaj@gmail.com

LinkedIn: [adamastor](https://www.linkedin.com/in/adamastor-chimalange/)

