-- Do not have to run create db line assuming that default connection is to 
-- this db
create database gcass_event_connect;


create table user_type (
	id serial primary key,
    value char(20)
);

INSERT INTO user_type VALUES
(DEFAULT, 'organizer'),
(DEFAULT, 'participant');

create table "user" (
	id uuid primary key,
    username varchar(30),
    password char(64),
    type int,
    created_time timestamptz,
    updated_time timestamptz,
    constraint user_ibfk_1 foreign key (type) references user_type(id)
);

create table user_detail (
	id uuid primary key,
    first_name char(30),
    last_name char(30),
    affiliate char(30),
    constraint user_detail_ibfk_1 foreign key(id) references "user"(id)
);

create table event_type (
	id serial primary key,
    value char(20)
);

INSERT INTO event_type VALUES
(DEFAULT, 'convention'),
(DEFAULT, 'concert');

create table event_status (
	id serial primary key,
    value char(20)
);

INSERT INTO event_status VALUES
(DEFAULT, 'not yet started'),
(DEFAULT, 'ongoing'),
(DEFAULT, 'ended');

create table event (
	id uuid primary key,
    title char(100),
    type int,
    description varchar(500),
    start_time timestamptz,
    end_time timestamptz,
    location char(100),
    status int,
    created_by uuid,
    created_time timestamptz,
    updated_by uuid,
    updated_time timestamptz,
    constraint event_ibfk_1 foreign key(type) references event_type(id),
    constraint event_ibfk_2 foreign key(status) references event_status(id),
    constraint event_ibfk_3 foreign key(created_by) references "user"(id),
    constraint event_ibfk_4 foreign key(updated_by) references "user"(id)
);


create table booth (
	id uuid primary key,
    position char(20),
    event_id uuid,
    constraint booth_ibfk_1 foreign key (event_id) references event(id)
);

create table ballot_status (
	id serial primary key,
    value char(20)
);

INSERT INTO ballot_status VALUES
(DEFAULT, 'pending'),
(DEFAULT, 'successful'),
(DEFAULT, 'unsuccessful');

create table ballot (
	id uuid primary key,
    user_id uuid,
    booth_id uuid,
    amount int,
    status int,
    created_time timestamptz,
    updated_time timestamptz,
    constraint ballot_ibfk_1 foreign key (user_id) references "user"(id),
    constraint ballot_ibfk_2 foreign key (booth_id) references booth(id),
    constraint ballot_ibfk_3 foreign key (status) references ballot_status(id)
);

create table transaction (
	id uuid primary key,
    event_id uuid,
    user_id uuid,
    ballot_id uuid,
    created_time timestamptz,
    constraint transaction_ibfk_1 foreign key (event_id) references event(id),
    constraint transaction_ibfk_2 foreign key (user_id) references "user"(id),
    constraint transaction_ibfk_3 foreign key (ballot_id) references ballot(id)
);
