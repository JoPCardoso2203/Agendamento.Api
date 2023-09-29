create database gerenciador_agendamento;

use gerenciador_agendamento;

create table motorista(
	moto_id int primary key not null auto_increment,
    moto_nome varchar(150) not null,
    moto_cnh varchar(11) not null,
    moto_cpf varchar(11) not null,
    moto_placa_veiculo varchar(7) not null,
    moto_data_criacao datetime not null,
    moto_data_cancelamento datetime
);

create table transportadora(
	tran_id int primary key not null auto_increment,
    tran_razao_social varchar(150) not null,
    tran_nome_fantasia varchar(150) not null,
    tran_cnpj varchar(14) not null,
    tran_data_criacao datetime not null,
    tran_data_cancelamento datetime
);

create table amr_transportadora_motorista(
	amtm_id int primary key not null auto_increment,
    amtm_tran_id int,
    amtm_moto_id int,
    amtm_data_criacao datetime not null,
    amtm_data_cancelamento datetime,
    FOREIGN KEY (amtm_tran_id) REFERENCES transportadora(tran_id),
    FOREIGN KEY (amtm_moto_id) REFERENCES motorista(moto_id)
);

create table agendamento(
	agen_id int primary key not null auto_increment,
    agen_numero_conteiner varchar(11) not null,
    agen_data_janela datetime not null,
    agen_data_entrada datetime,
    agen_data_saida datetime,
    agen_amtm_id int,
    agen_data_criacao datetime not null,
    agen_data_cancelamento datetime,	
    FOREIGN KEY (agen_amtm_id) REFERENCES amr_transportadora_motorista(amtm_id)
);
