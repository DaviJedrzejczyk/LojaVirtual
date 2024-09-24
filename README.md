# Loja Virtual
Um sistema simples e funcional

## 🌐 Redes Sociais
[![LinkedIn](https://img.shields.io/badge/LinkedIn-0E76A8?style=for-the-badge&logo=linkedin&logoColor=white&color=0E76A8&labelColor=0E76A8&)](https://www.linkedin.com/in/davi-jedrzejczyk-03b22a245)

## 📕 Sobre

Este projeto em .NET Framework 4.8.1 é uma aplicação simples de gerenciamento de clientes, produtos e pedidos. Ele permite cadastrar clientes, associar produtos aos pedidos e registrar todas as transações. A aplicação fornece operações básicas de CRUD para cada entidade, garantindo uma gestão eficaz dos dados. É ideal para demonstrar funcionalidades de relacionamento entre entidades no contexto de um sistema de vendas.

## 🔨 Ferramentas

- .NET Framework 4.8.1
- Visual Studio
- SQL Server
- EntityFramework

## 🚀 Funcionalidades

- Cadastro de clientes
- Cadastro de produtos
- Criação e gerenciamento de pedidos
- Operações CRUD para clientes, produtos e pedidos
- Relacionamento entre entidades

## 📦 Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/LojaVirtual.git
   ```
2. Abra o projeto no Visual Studio.

3. Extraia a pasta do Banco.zip para Banco.

4. Configure a string de conexão com o banco de dados no arquivo Web.config se você não deixou a pasta como Banco.

5. Compile e execute o projeto.

## 📋 Uso

1. Inicie a aplicação.
2. Utilize a interface para cadastrar clientes, produtos e criar pedidos.
3. Gerencie as entidades através das operações CRUD disponíveis.

## 📜 Regras 📜

### Clientes 👤

1. Cliente deve ter um nome com no minimo 2 caracteres e no maximo 50
2. Email é único, seguindo o padrão da Google, até no maximo 50 caracteres
3. Data de nascimento é obrigatorio

### Produtos 🛒

1. Produto deve ter um nome com no minimo 2 caracteres e no maximo 30
2. Preço dele deve ser de no minimo R$ 0,01
3. Quantidade deve ser no minimo de 1

### Pedidos 📦

1. Deve ter um Cliente Selecionado.
2. Deve ter pelo menos um Produto selecionado.
3. Pode selecionar quantos produtos quiseres e definir a quantidade para cada um.
