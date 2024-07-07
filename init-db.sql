    
    DROP TABLE
    IF EXISTS categoria_produto
    CASCADE;
    
    DROP TABLE
    IF EXISTS produto
    CASCADE;
    
    DROP TABLE
    IF EXISTS pedido
    CASCADE;
    
    DROP TABLE
    IF EXISTS item_pedido
    CASCADE;
    
    DROP TABLE
    IF EXISTS pagamento
    CASCADE;

    
    CREATE TABLE categoria_produto (
    id serial
    ,nome VARCHAR(255)
    ,PRIMARY KEY (id)
    );
    
    CREATE TABLE produto (
    id serial
    ,nome VARCHAR(255)
    ,id_categoria INT
    ,STATUS bool
    ,preco numeric
    ,PRIMARY KEY (id)
    );
    
    CREATE TABLE pedido (
    id serial
    ,data_pedido DATE
    ,STATUS SMALLINT
    ,id_cliente INT
    ,horario_inicio TIMESTAMP
    ,horario_fim TIMESTAMP
    ,valor_pedido numeric
    ,PRIMARY KEY (id)
    );
    
    CREATE TABLE item_pedido (
    id_pedido INT
    ,id_produto INT
    ,preco_itempedido numeric
    ,CONSTRAINT fk_pedido FOREIGN KEY (id_pedido) REFERENCES pedido(id)
    ,CONSTRAINT fk_produto FOREIGN KEY (id_produto) REFERENCES produto(id)
    );
    
    CREATE TABLE pagamento (
    id serial
    ,id_pedido INT
    ,STATUS SMALLINT
    ,PRIMARY KEY (id)
    ,CONSTRAINT fk_pedido FOREIGN KEY (id_pedido) REFERENCES pedido(id)
    );
    
    INSERT INTO public.categoria_produto
    (id, nome)
    VALUES(1, 'Bebida');
    INSERT INTO public.categoria_produto
    (id, nome)
    VALUES(2, 'Lanche');
    INSERT INTO public.categoria_produto
    (id, nome)
    VALUES(3, 'Sobremesa');
    
    
    INSERT INTO public.pedido
    (id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
    VALUES(3, '2024-01-24', 4, 1, '2024-01-24 21:05:28.602', '2024-02-25 11:50:31.662', 15.0);
    INSERT INTO public.pedido
    (id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
    VALUES(4, '2024-01-24', 1, 1, '2024-01-24 21:08:34.219', '-infinity', 15.0);
    INSERT INTO public.pedido
    (id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
    VALUES(5, '2024-01-24', 1, 1, '2024-01-24 21:10:19.295', '-infinity', 15.0);
    INSERT INTO public.pedido
    (id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
    VALUES(6, '2024-01-24', 2, 1, '2024-01-24 21:11:39.708', '-infinity', 15.0);
    INSERT INTO public.pedido
    (id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
    VALUES(7, '2024-01-24', 2, 1, '2024-01-24 21:13:36.538', '-infinity', 15.0);
    INSERT INTO public.pedido
    (id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
    VALUES(8, '2024-01-24', 3, 1, '2024-01-24 21:15:41.073', '2024-01-25 21:30:55.096', 15.0);
    INSERT INTO public.pedido
    (id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
    VALUES(9, '2024-01-24', 3, 1, '2024-01-24 21:53:42.029', '2024-01-24 21:54:44.353', 15.0);
    INSERT INTO public.pedido
    (id, data_pedido, status, id_cliente, horario_inicio, horario_fim, valor_pedido)
    VALUES(10, '2024-01-24', 4, 1, '2024-01-24 21:13:41.073', '2024-01-25 21:30:55.096', 15);
    
    INSERT INTO public.produto
    (id, nome, id_categoria, status, preco)
    VALUES(1, 'Coca', 1, true, 5.0);
    INSERT INTO public.produto
    (id, nome, id_categoria, status, preco)
    VALUES(2, 'Agua', 1, true, 2.0);
    INSERT INTO public.produto
    (id, nome, id_categoria, status, preco)
    VALUES(3, 'Agua de Coco', 1, true, 3.0);
    INSERT INTO public.produto
    (id, nome, id_categoria, status, preco)
    VALUES(4, 'Hamburguer', 2, true, 25.0);
    INSERT INTO public.produto
    (id, nome, id_categoria, status, preco)
    VALUES(5, 'Coxinha', 2, true, 7);
    INSERT INTO public.produto
    (id, nome, id_categoria, status, preco)
    VALUES(6, 'Pastel Frango', 2, true, 4);
    INSERT INTO public.produto
    (id, nome, id_categoria, status, preco)
    VALUES(7, 'Empada', 2, true, 2);

    
    --------------------------------------------------------
    
    alter sequence categoria_produto_id_seq restart with 4;
    alter sequence produto_id_seq restart with 8;
    alter sequence pedido_id_seq restart with 11;