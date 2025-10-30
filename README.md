# 🏨 Hotel Management System (.NET 9 + Blazor WebAssembly + MySQL)

Aplicação web completa de **gestão de hotel** desenvolvida em **C# com .NET 9**.  
Inclui **API RESTful** com Entity Framework Core e **frontend em Blazor WebAssembly**,  
ligados a uma **base de dados MySQL**.

---

## 🚀 Funcionalidades

- 👤 **Gestão de Clientes**
  - Criar, listar, editar e eliminar clientes.
- 🛏️ **Gestão de Reservas**
  - Associar reservas a clientes.
  - Ver check-in, check-out e observações.
- 💾 **Persistência de dados** com Entity Framework Core e MySQL.
- 🌐 **Frontend moderno** feito com Blazor WebAssembly (C# puro).
- 🔗 **Comunicação via API HTTP** entre frontend e backend.

---

## 🧱 Estrutura do Projeto

Hotel/
├── HotelApi/ → Backend (.NET 9 Web API + EF Core + MySQL)
└── HotelWeb/ → Frontend (Blazor WebAssembly)


---

## ⚙️ Tecnologias

- .NET 9  
- C#  
- Entity Framework Core 9  
- MySQL  
- Blazor WebAssembly  
- Postman  

---

▶️ Como Executar Localmente
1️⃣ Clonar o repositório
git clone https://github.com/islanmir/HotelApp.git

2️⃣ Executar o backend
cd HotelApi
dotnet run

A API estará disponível em:
http://localhost:5026

3️⃣ Executar o frontend
cd ../HotelWeb
dotnet run

A aplicação Blazor estará disponível em:
http://localhost:5201

🌍 Versão Online (Frontend)
O frontend é publicado automaticamente através do GitHub Actions e pode ser acedido aqui:

👉 (https://islanmir.github.io/HotelApp/)

(Apenas o frontend é executado online — a API deve correr localmente para persistência de dados.)

🔁 Deploy Automático

O fluxo de publicação é gerido por GitHub Actions, que:
Compila o projeto Blazor (HotelWeb);
Publica os ficheiros de produção;
Atualiza automaticamente o branch gh-pages;
Disponibiliza o site em GitHub Pages.

O ficheiro do workflow encontra-se em:
.github/workflows/deploy.yml

✅ Estado do Projeto

<img width="326" height="20" alt="image" src="https://github.com/user-attachments/assets/185d095f-64f8-4d12-98c8-bd2704b64de0" />



🧑‍💻 Autor

Raquel Monteiro

Projeto criado para estudo e portfólio.

“Aprender é transformar curiosidade em criação.” ✨
