use db_cantina_facil_usuarios;

insert into tb_parametro (NM_PARAMETRO, TX_VALOR, DS_PARAMETRO)
values ('JwtPrivateKey', 'chave-privada', 'Chave privada do token de acesso'),
	   ('JwtPublicKey', 'chave-publica', 'Chave publica do token de acesso'),
       ('JwtExpirationMinutes', '60', 'Tempo de expiração do token em minutos');

insert into tb_dom_perfil (NM_PERFIL, DT_CRIACAO)
values ('Cantina', now()),
	   ('Tutor', now()),
       ('Estudante', now());