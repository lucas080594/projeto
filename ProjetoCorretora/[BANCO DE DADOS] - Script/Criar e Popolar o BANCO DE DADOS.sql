/* ...::: Cria��o do banco de dados oficial do projeto :::... */

USE master;

GO

IF EXISTS (SELECT name from master.sys.databases WHERE name = N'BDPIM')
DROP DATABASE BDPIM;

go

--1� Crie o Banco ( Selecione a linha abaixo e pressione F5 ou clique em executar)
CREATE DATABASE BDPIM;
--2� Para criar as tabelas precisa estar com o banco em uso, Selecione a linha abaixo e pressione F5 ou clique em executar)
GO
USE BDPIM;


/*
	Inicia-se pelas entidades fortes do banco de dados.

	Selecione todo o c�digo abaixo at� o final do c�digo e e pressione F5 ou clique em executar
*/
CREATE TABLE EBRX_CLIENTE (
		CLI_INT_ID INT NOT NULL IDENTITY (1,1),
		NOME_STR_CLI VARCHAR(50)  NULL,
		CPF_STR_CLI CHAR(11)  NULL,
		DT_NASC_CLI DATE  NULL,
		EMAIL_STR_CLI VARCHAR (100)  NULL,
		DAT_INCLS_CLI DATETIME  NULL,
		STATS_STR_CLI CHAR(1)  NULL,
		DAT_ATUALIZC DATETIME  NULL,

		CONSTRAINT PK_CLI_INT_ID PRIMARY KEY (CLI_INT_ID),
		CONSTRAINT UK_CPF_EMAIL_ID UNIQUE (CPF_STR_CLI, EMAIL_STR_CLI)
);

CREATE TABLE EBRX_MOEDA(
	MOE_STR_ID INT NOT NULL IDENTITY (1,1),
	MOE_STR_DESC VARCHAR (20)  NULL,
	
	CONSTRAINT UK_MOEDA UNIQUE (MOE_STR_ID)
);

CREATE TABLE EBRX_SOLICT (
	COD_INT_SOL INT NOT NULL IDENTITY (1,1),
	DESC_NOM_SOL VARCHAR(60)  NULL,
	PRAZO_FLOAT_SOL FLOAT NULL,
	DT_ATUALIZAC DATETIME   NULL,

	CONSTRAINT UK_COD_TIP_SOLICT_ID UNIQUE (COD_INT_SOL)
);

CREATE TABLE INSTI_BANCO (
	BANCO_INT_ID INT NOT NULL IDENTITY (1,1),
	NOME_STR_BANK VARCHAR (40)  NULL,
	CNPJ_STR_BANK CHAR (14)  NULL,

	CONSTRAINT PK_BANCO_ID PRIMARY KEY (BANCO_INT_ID),
	CONSTRAINT UK_BANK_CNPJ UNIQUE (CNPJ_STR_BANK, BANCO_INT_ID)
);

CREATE TABLE EBRX_TIP_ORDR(
	COD_INT_ID INT NOT NULL IDENTITY (1,1),
	DESC_STR_ORDER VARCHAR(20)  NULL,

	CONSTRAINT PK_COD_ORDER_ID PRIMARY KEY (COD_INT_ID),
	CONSTRAINT UK_TIP_ORDR_ID UNIQUE (COD_INT_ID)
);

CREATE TABLE EBRX_TIP_TRAN (
	COD_INT_ID INT NOT NULL IDENTITY (1,1),
	DESC_STR_TRAN VARCHAR (15)  NULL,
	PERC_TRAN FLOAT  NULL,

	CONSTRAINT PK_COD_ID PRIMARY KEY (COD_INT_ID),
	CONSTRAINT UK_COD_TIP_ID UNIQUE (COD_INT_ID)
);

CREATE TABLE EBRX_FUNCRH (
	COD_FUNC INT NOT NULL IDENTITY (100,1),
	MATRIC_STR_FUNC CHAR(7)  NULL,
	NOME_STR_FUNC VARCHAR(50)  NULL,
	SITU_STR_FUNC CHAR(1)  NULL,

	CONSTRAINT PK_COD_MATRIC_FUNC PRIMARY KEY (COD_FUNC),
	CONSTRAINT UK_MATRIC_COD_ID UNIQUE (MATRIC_STR_FUNC, COD_FUNC)
);
/*
	Inicio das entidades fracas.
*/
CREATE TABLE EBRX_CARTEIRA (
	CAR_INT_ID INT NOT NULL IDENTITY (10,1),
	EBRX_CLIENT_ID INT  NULL,
	EBRX_MOEDA_MOE_STR_ID INT  NULL,
	SALD_STR_CRIP FLOAT  NULL,
	SALD_STR_DINHR FLOAT  NULL,
	DT_ATUALIZACAO DATETIME  NULL,

	CONSTRAINT PK_CAR_INT_ID PRIMARY KEY (CAR_INT_ID),
	CONSTRAINT FK_CLIENT_CARTEIRA_ID FOREIGN KEY (EBRX_CLIENT_ID) REFERENCES EBRX_CLIENTE(CLI_INT_ID),
	CONSTRAINT FK_MOED_CARTEIR_ID FOREIGN KEY (EBRX_MOEDA_MOE_STR_ID) REFERENCES EBRX_MOEDA(MOE_STR_ID),
	CONSTRAINT UK_EBRX_CART UNIQUE (CAR_INT_ID)
);

CREATE TABLE EBRX_CONTA (
	ACC_INT_ID INT NOT NULL IDENTITY (100, 1),
	EBRX_CARTEIRA_ID INT  NULL,
	EBRX_CLIENT_ID INT  NULL,
	AGC_STR_ACC CHAR(4)  NULL,
	CONT_NUM_ACC CHAR(5)  NULL,
	DIG_STR_ACC CHAR(1)  NULL,
	SENH_STR_ACC VARCHAR(20)  NULL,

	CONSTRAINT PK_ACC_ID PRIMARY KEY (ACC_INT_ID),
	CONSTRAINT FK_CLIENT_CONT_ID FOREIGN KEY (EBRX_CLIENT_ID) REFERENCES EBRX_CLIENTE(CLI_INT_ID),
	CONSTRAINT FK_CONT_CARTEIR_ID FOREIGN KEY (EBRX_CARTEIRA_ID) REFERENCES EBRX_CARTEIRA(CAR_INT_ID),
	CONSTRAINT UK_ACC_DIG_NUM UNIQUE (CONT_NUM_ACC, ACC_INT_ID, EBRX_CARTEIRA_ID, EBRX_CLIENT_ID)
);

CREATE TABLE EBRX_FUNC_PROFILE(
	COD_PROFILE  INT NOT NULL IDENTITY (100,1),
	EBRX_FUNCRH_COD INT  NULL,
	SENH_STR_ACESS VARCHAR(25)  NULL,
	MATRIC_STR_ACESS CHAR(7)  NULL,

	CONSTRAINT PK_PROFILE_ID PRIMARY KEY (COD_PROFILE),

	CONSTRAINT FK_RH_FUNC FOREIGN KEY (EBRX_FUNCRH_COD) REFERENCES EBRX_FUNCRH(COD_FUNC),

	CONSTRAINT UK_ACESS_ID UNIQUE (COD_PROFILE, EBRX_FUNCRH_COD, MATRIC_STR_ACESS)
);

CREATE TABLE EBRX_CLIENT_SOLICIT (
	PROTOCOL_INT_ID INT NOT NULL IDENTITY (10001,3),
	EBRX_FUNC_PROFILE_COD INT NULL,
	EBRX_CLIENTE_CPF CHAR(11)  NULL,
	TIP_STR_SOL INT  NULL,
	DESC_STR_SOL VARCHAR(300)  NULL,
	SITUAC_ATENDMNT INT NULL,
	DT_ATUALIZCAO DATETIME  NULL,

	CONSTRAINT PK_SOLCT_PROTOCOL PRIMARY KEY (PROTOCOL_INT_ID),
	
	CONSTRAINT FK_FUNC_ATENDMNT FOREIGN KEY (EBRX_FUNC_PROFILE_COD) REFERENCES EBRX_FUNC_PROFILE(COD_PROFILE),
	CONSTRAINT FK_TIP_SOLCT_ID FOREIGN KEY (TIP_STR_SOL) REFERENCES EBRX_SOLICT(COD_INT_SOL),


	CONSTRAINT UK_ATENDMNT_ID UNIQUE (PROTOCOL_INT_ID)
);

CREATE TABLE EBRX_BANCO_CONTA (
	COD_INT_CONTA_ID INT NOT NULL IDENTITY (1,1),

	EBRX_CLIENT_CPF CHAR(11)  NULL,
	INSTI_BANCO_COD INT  NULL,

	CONT_STR_BANCO VARCHAR(15)  NULL,
	DIGT_STR_BANCO VARCHAR(3)  NULL,

	CONSTRAINT PK_COD_CONTA_ID PRIMARY KEY (COD_INT_CONTA_ID),


	CONSTRAINT FK_BANC_INST_ID FOREIGN KEY (INSTI_BANCO_COD) REFERENCES INSTI_BANCO(BANCO_INT_ID),

	CONSTRAINT UK_CONT_BANC_ID UNIQUE (CONT_STR_BANCO)
);
CREATE TABLE EBRX_HIST_COD(
	COD_INT_ID INT NOT NULL IDENTITY (1,1),

	EBRX_CLIENTE_CLI_COD INT  NULL,
	ALTER_DESC VARCHAR(40)  NULL,
	DT_ATUALIZAC DATETIME  NULL,

	CONSTRAINT PK_COD_HIST_ID PRIMARY KEY (COD_INT_ID),

	CONSTRAINT FK_H_CAD_CLIENT FOREIGN KEY (EBRX_CLIENTE_CLI_COD) REFERENCES EBRX_CLIENTE (CLI_INT_ID),

	CONSTRAINT UK_HIST_COD UNIQUE (COD_INT_ID) 
);

CREATE TABLE EBRX_ORDER (
	COD_ORDER INT NOT  NULL IDENTITY (201,1),

	EBRX_TIP_ORDR_COD INT  NULL,
	EBRX_MOEDA_MOE_COD INT  NULL,
	EBRX_CLIENTE_CLI_COD INT  NULL,
	VLR_ORDER FLOAT  NULL,
	QTD_CRIPT VARCHAR(20)  NULL,

	CONSTRAINT PK_ORDER_ID PRIMARY KEY (COD_ORDER),

	CONSTRAINT FK_TIP_ORDER_ID FOREIGN KEY (EBRX_TIP_ORDR_COD) REFERENCES EBRX_TIP_ORDR(COD_INT_ID),
	CONSTRAINT FK_MOED_TRAN_ID FOREIGN KEY (EBRX_MOEDA_MOE_COD) REFERENCES EBRX_MOEDA(MOE_STR_ID),
	CONSTRAINT FK_ORDR_CLIENT_ID FOREIGN KEY (EBRX_CLIENTE_CLI_COD) REFERENCES EBRX_CLIENTE(CLI_INT_ID),

	CONSTRAINT UK_ORDER_INFO UNIQUE (COD_ORDER)
);

CREATE TABLE EBRX_TRAN (
	COD_TRAN_ID INT NOT NULL IDENTITY (201, 1),

	EBRX_MOEDA_MOE_COD INT  NULL,
	EBRX_CLIENTE_CLI_COD INT  NULL,
	EBRX_TIP_TRAN_COD INT  NULL,
	VLR_TRANS FLOAT  NULL,


	CONSTRAINT FK_TRAN_MOED_ID FOREIGN KEY (EBRX_MOEDA_MOE_COD) REFERENCES EBRX_MOEDA(MOE_STR_ID),
	CONSTRAINT FK_CLIENT_ORDR_ID FOREIGN KEY (EBRX_CLIENTE_CLI_COD) REFERENCES EBRX_CLIENTE(CLI_INT_ID),
	CONSTRAINT FK_TIP_TRAN_ID FOREIGN KEY (EBRX_TIP_TRAN_COD) REFERENCES EBRX_TIP_TRAN(COD_INT_ID),

	CONSTRAINT UK_TRAN_ID UNIQUE (COD_TRAN_ID)
);


CREATE TABLE EBRX_EXTRATO_CONTA (
	
	EBRX_CLIENTE_CLI_COD INT NOT NULL,
	EBRX_ORDER_COD INT  NULL,
	EBRX_TRAN_COD INT  NULL,
	VLR_DOU_TRAN FLOAT  NULL,
	QTD_STR_CRIPT VARCHAR (20)  NULL,
	DT_ATUALIZC DATETIME  NULL,

	CONSTRAINT PK_CLIENT_ID PRIMARY KEY (EBRX_CLIENTE_CLI_COD),
	CONSTRAINT FK_CLIENT_EXTRT_ID FOREIGN KEY (EBRX_CLIENTE_CLI_COD) REFERENCES EBRX_CLIENTE(CLI_INT_ID),
	CONSTRAINT FK_ORDER_EXTRT_COD FOREIGN KEY (EBRX_ORDER_COD) REFERENCES EBRX_ORDER(COD_ORDER),
	CONSTRAINT FK_TRAN_EXTRT_COD FOREIGN KEY (EBRX_TRAN_COD) REFERENCES EBRX_TRAN(COD_TRAN_ID)
);

CREATE TABLE EBRX_COTACAO (
	EBRX_MOEDA_COD INT NOT NULL,
	VLR_DOU_COT FLOAT  NULL,

	CONSTRAINT FK_MOED_COT_ID FOREIGN KEY (EBRX_MOEDA_COD) REFERENCES EBRX_MOEDA(MOE_STR_ID),
	CONSTRAINT UK_MOED_ID UNIQUE (EBRX_MOEDA_COD)
);


/* Ap�s a execu��o, o banco e todas as tabelas foram criadas */


/* Adicionar dados de testes nas tabelas criadas */


INSERT INTO EBRX_CLIENTE (NOME_STR_CLI, CPF_STR_CLI, DT_NASC_CLI, EMAIL_STR_CLI, DAT_INCLS_CLI,  DAT_ATUALIZC)
VALUES (
/*Nome do Cliente*/                  'Gabiriel Ziroldo Cruz Gon�alvez' ,
/* CPF x CNPJ do cliente*/	          09837627809, 
/* Data de Nascimento */	          '2020/09/20' , 
/*Email do Cliente*/		          'pimpim.salabim@gmail.com' , 
/*Data de Inclus�o do Cliente*/	       GETDATE() , 
/*Data de Atualiza��es de informa��es*/GETDATE() );

/***************************************************************************************/
select * from EBRX_MOEDA

INSERT INTO EBRX_MOEDA (MOE_STR_DESC) VALUES		('Etherum');
INSERT INTO EBRX_MOEDA (MOE_STR_DESC) VALUES		('Bitcoin');
INSERT INTO EBRX_MOEDA (MOE_STR_DESC) VALUES		('Real');

/***************************************************************************************/

SELECT * FROM EBRX_SOLICT

INSERT INTO EBRX_SOLICT (DESC_NOM_SOL, PRAZO_FLOAT_SOL, DT_ATUALIZAC)
VALUES (
/* Descri��o Solicita��o */ 'Encerramento de Conta',
/* Prazo de Atendimento */  '15',
/* Ultima Atualiza��o  */   GETDATE());
INSERT INTO EBRX_SOLICT (DESC_NOM_SOL, PRAZO_FLOAT_SOL, DT_ATUALIZAC)VALUES ('Relat�rio de Dados', '15', GETDATE());
INSERT INTO EBRX_SOLICT (DESC_NOM_SOL, PRAZO_FLOAT_SOL, DT_ATUALIZAC)VALUES ('Atualiza��o de Informa��es Do meu cadastro', '5', GETDATE());


/***************************************************************************************/


INSERT INTO INSTI_BANCO (NOME_STR_BANK, CNPJ_STR_BANK)
VALUES (
/* Nome Institui��o  */'Santander',
/* CPNJ da Instiui��o*/ 90400888000142 );

INSERT INTO INSTI_BANCO (NOME_STR_BANK, CNPJ_STR_BANK)VALUES ('Itau',607011900001);
INSERT INTO INSTI_BANCO (NOME_STR_BANK, CNPJ_STR_BANK)VALUES ('Bradesco',60746948000112);
INSERT INTO INSTI_BANCO (NOME_STR_BANK, CNPJ_STR_BANK)VALUES ('Banco do Brasil',00000000000191);
INSERT INTO INSTI_BANCO (NOME_STR_BANK, CNPJ_STR_BANK)VALUES ('Nubank',18236120000158);

/***************************************************************************************/
SELECT * FROM EBRX_CARTEIRA
INSERT INTO EBRX_CARTEIRA ( EBRX_CLIENT_ID ,EBRX_MOEDA_MOE_STR_ID, SALD_STR_CRIP, SALD_STR_DINHR, DT_ATUALIZACAO)
VALUES(
/*Cliente cod*/ 1,
/* ID Moeda */ 3,
/* Saldo Cripto */ 0.9762,
/* SALDO REAL */  1.0987,
/* Data de Atualiza��o*/ GETDATE());


/***************************************************************************************/

INSERT INTO EBRX_BANCO_CONTA (EBRX_CLIENT_CPF, INSTI_BANCO_COD, CONT_STR_BANCO, DIGT_STR_BANCO)
VALUES(
/* C�digo do CPF Cliente */ 09837627809, 
/* C�digo Institui��o */ 4,
/* Conta Banc�ria */ 45632,
/* Digito Conta */ 3)


/***************************************************************************************/

SELECT * FROM EBRX_CONTA

INSERT INTO EBRX_CONTA (EBRX_CARTEIRA_ID, EBRX_CLIENT_ID, AGC_STR_ACC, CONT_NUM_ACC, DIG_STR_ACC, SENH_STR_ACC)
VALUES (
/* Carteira do Cliente */ 10,
/* Cliente COD */		  1,
/* Ag�ncia Corretora */   300,
/* Conta corretora EBRAX*/128954, 
/* Digito Corretora */    2,
/* Senha de acesso */     '123TESTE')
  
/***************************************************************************************/

SELECT * FROM EBRX_FUNCRH

INSERT INTO EBRX_FUNCRH (MATRIC_STR_FUNC, NOME_STR_FUNC, SITU_STR_FUNC)
VALUES (
/* M�tricula Funcion�rio */ 89697,
/* Nome Funcion�rio */      'Cristiano Ronaldo',
/* Situa��o Funcion�rio */  1);

INSERT INTO EBRX_FUNCRH (MATRIC_STR_FUNC, NOME_STR_FUNC, SITU_STR_FUNC)
VALUES (
/* M�tricula Funcion�rio */ 12345,
/* Nome Funcion�rio */      'Professor',
/* Situa��o Funcion�rio */  1);


/***************************************************************************************/
SELECT * FROM EBRX_FUNC_PROFILE

INSERT INTO EBRX_FUNC_PROFILE (EBRX_FUNCRH_COD, SENH_STR_ACESS, MATRIC_STR_ACESS)
VALUES (
/* ID do Funcion�rio */       100,
/* Senha de Acesso */        'TESTANDO123',
/* Matricula Funcion�rio */   89697);


/***************************************************************************************/



INSERT INTO EBRX_CLIENT_SOLICIT (EBRX_FUNC_PROFILE_COD, EBRX_CLIENTE_CPF, TIP_STR_SOL, DESC_STR_SOL, DT_ATUALIZCAO)
VALUES (
/* C�digoFuncion�rio que ir� atender */    100,
/* C�digo do Cliente  */                   09837627809,
/* Tipo de Solicita��o  */                 2,                        
/* Motivo  */                              'Estou excluindo minha conta por que n�o quero mais investir',
/* Ultima Atualiza��o  */                  GETDATE());

/***************************************************************************************/
INSERT INTO EBRX_TIP_TRAN ( DESC_STR_TRAN,  PERC_TRAN)
VALUES(
/* Tipo de Movimento */       'Dep�sito / TED', 
/* Percentual de Saque */      0.07);
INSERT INTO EBRX_TIP_TRAN ( DESC_STR_TRAN,  PERC_TRAN)
VALUES('Dep�sito / TED', 0.10);

/***************************************************************************************/

SELECT * FROM EBRX_TRAN
INSERT INTO EBRX_TRAN(EBRX_MOEDA_MOE_COD, EBRX_CLIENTE_CLI_COD, EBRX_TIP_TRAN_COD, VLR_TRANS)
VALUES (
/* ID Moeda */             3,
/* Cliente ID */           1,
/* Tipo de movimento */     1,
/* Valor da Transa��o */   105.98);


/***************************************************************************************/
SELECT * FROM EBRX_TIP_ORDR

INSERT INTO EBRX_TIP_ORDR(DESC_STR_ORDER)
VALUES(
/* Tipo de Movimento */       'COMPRA CRIPT-ATIV');

INSERT INTO EBRX_TIP_ORDR(DESC_STR_ORDER) VALUES('VENDA CRIPT-ATIV');

/***************************************************************************************/

SELECT * FROM EBRX_ORDER
INSERT INTO EBRX_ORDER(EBRX_TIP_ORDR_COD, EBRX_MOEDA_MOE_COD, EBRX_CLIENTE_CLI_COD, VLR_ORDER, QTD_CRIPT)
VALUES (
/* ID Tipo Order */        1,
/* Cripto-Ativo ID */      2,
/* CLIENTE ID */           1,
/* Valor R$ */             97.78,
/* Qtd de Cripto-ATV*/     0.004)

INSERT INTO EBRX_ORDER(EBRX_TIP_ORDR_COD, EBRX_MOEDA_MOE_COD, EBRX_CLIENTE_CLI_COD, VLR_ORDER, QTD_CRIPT)
VALUES (2, 1, 1, 102.78, 0.08)

/***************************************************************************************/


SELECT * FROM EBRX_EXTRATO_CONTA
INSERT INTO EBRX_EXTRATO_CONTA ( EBRX_CLIENTE_CLI_COD, EBRX_ORDER_COD, EBRX_TRAN_COD, VLR_DOU_TRAN, QTD_STR_CRIPT, DT_ATUALIZC)
VALUES (
/*Cliente ID*/                        1,
/*Tipor de Ordem*/                    201,
/* Transa��o */                       201,
/*Valor em REAL*/                     200,
/* Quantidade de CriptoMovimentados*/ 0.878,
/* Data de Atualiza��o*/              GETDATE());



/***************************************************************************************/


/***************************************************************************************/

SELECT * FROM EBRX_HIST_COD

INSERT INTO EBRX_HIST_COD ( EBRX_CLIENTE_CLI_COD, ALTER_DESC, DT_ATUALIZAC)
VALUES (
/*Cliente ID*/                1,
/* Qual foi a altera��o ? */ 'Atualiza��o de Endere�o',
/* Data de Atualiza��o*/      GETDATE());


INSERT INTO EBRX_HIST_COD ( EBRX_CLIENTE_CLI_COD, ALTER_DESC, DT_ATUALIZAC)
VALUES (1,  'Atualiza��O de Telefone', GETDATE());


/*Corre��es*/

GO
USE BDPIM;
ALTER TABLE EBRX_BANCO_CONTA
	ADD  AGENC_NUMERO VARCHAR(6) NULL;
		
		GO
		UPDATE EBRX_BANCO_CONTA
		SET AGENC_NUMERO = 0355
		WHERE EBRX_CLIENT_CPF = 09837627809;

/*********************************************/
GO
USE BDPIM;
ALTER TABLE EBRX_CLIENTE 
	ADD SENH_ACC VARCHAR(40) NULL;
		
		GO
		UPDATE EBRX_CLIENTE 
		SET SENH_ACC = '123teste'
		WHERE CLI_INT_ID = 1


/******************************************/

