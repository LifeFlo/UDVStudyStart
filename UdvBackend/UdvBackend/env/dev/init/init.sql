CREATE SCHEMA udv_start

    create TABLE IF NOT EXISTS role
    (
        id uuid primary key not null,
        name varchar(40) not null
    )


    CREATE TABLE IF NOT EXISTS account
    (
        id            uuid PRIMARY KEY not null,
        name          varchar(255)     not null,
        surname       varchar(255)     null,
        email         varchar(255)     not null,
        password_hash varchar(255)     not null,
        role_id       uuid             not null,
        constraint fk_role_id foreign key (role_id) REFERENCES role (id)
    )

   CREATE TABLE IF NOT EXISTS token
    (
        value     varchar(255) primary key not null,
        user_id   uuid                     not null,
        create_dt date                     not null,
        constraint fk_user_id foreign key (user_id) references account (id)
    );

