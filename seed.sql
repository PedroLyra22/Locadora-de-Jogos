-- Criação do banco de dados
CREATE DATABASE locadora_jogos;
USE locadora_jogos;

-- Tabela de Jogos
CREATE TABLE Jogos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(100) NOT NULL,
    genero VARCHAR(50),
    plataforma VARCHAR(50),
    ano_lancamento YEAR,
    preco_diaria DECIMAL(5, 2) NOT NULL
);

-- Tabela de Clientes
CREATE TABLE Clientes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    telefone VARCHAR(20),
    data_nascimento DATE
);

-- Tabela de Locacoes
CREATE TABLE Locacoes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_cliente INT,
    id_jogo INT,
    data_locacao DATE NOT NULL,
    data_devolucao DATE,
    valor_total DECIMAL(7, 2) NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES Clientes(id),
    FOREIGN KEY (id_jogo) REFERENCES Jogos(id)
);

-- Dados iniciais para testes

-- Inserção de Jogos
INSERT INTO Jogos (titulo, genero, plataforma, ano_lancamento, preco_diaria) VALUES 
('The Witcher 3', 'RPG', 'PC', 2015, 15.00),
('FIFA 22', 'Esporte', 'PlayStation', 2021, 20.00),
('Minecraft', 'Aventura', 'Xbox', 2011, 10.00);

-- Inserção de Clientes
INSERT INTO Clientes (nome, email, telefone, data_nascimento) VALUES 
('João Silva', 'joao.silva@gmail.com', '11912345678', '1990-06-15'),
('Maria Oliveira', 'maria.oliveira@hotmail.com', '11987654321', '1985-09-23');

-- Inserção de Locação
INSERT INTO Locacoes (id_cliente, id_jogo, data_locacao, data_devolucao, valor_total) VALUES
(1, 1, '2023-01-15', '2023-01-18', 45.00),
(2, 3, '2023-02-20', NULL, 10.00);
