-----------------------create db---------------
create database colorado_db;

drop table customer;

create table customer(
id bigserial primary key,
name varchar(100) not null,
city varchar(100) not null,
state varchar(2) not null,
date_insert timestamp not null);

drop table address;

create table address(
customer_id bigint primary key not null,
street varchar(100) not null,
number int not null,
neighborhood varchar(100) not null,
city varchar(100) not null,
state varchar(2) not null,
country varchar(100) not null,
zip_code varchar(9) not null,
foreign key(customer_id) references customer(id)                    
);