CREATE SCHEMA udv_start

    create TABLE IF NOT EXISTS role
    (
    id   uuid primary key not null,
    name varchar(40)      not null
    )

CREATE TABLE IF NOT EXISTS account
(
    id            uuid PRIMARY KEY not null,
    name          varchar(255)     not null,
    surname       varchar(255)     null,
    middle_name   varchar(255)     null,
    email         varchar(255)     not null,
    password_hash varchar(255)     not null,
    role_id       uuid             not null,
    constraint fk_role_id foreign key (role_id) REFERENCES role (id)
    )

CREATE TABLE task
(
    id          UUID PRIMARY KEY not null,
    title       TEXT             not null,
    description TEXT             not null,
    account_id     UUID             not null,
    is_complete BOOLEAN          not null,
    date        TIMESTAMP        not null,
    constraint fk_user_id foreign key (account_id) references account (id) ON DELETE CASCADE
)

CREATE TABLE hr_employee
(
    id          UUID primary key NOT NULL,
    hr_id       UUID NOT NULL,
    employee_id UUID NOT NULL,
    constraint fk_hr_id foreign key (hr_id) references account(id) on delete cascade ,
    constraint fk_employee_id foreign key (employee_id) references  account(id) on delete cascade
)

CREATE TABLE IF NOT EXISTS token
(
    value      varchar(255) primary key not null,
    account_id uuid                     not null,
    create_dt  date                     not null,
    ttl        timestamp                not null,
    constraint fk_user_id foreign key (account_id) references account (id)
    )


CREATE TABLE planet_info
(
    id    UUID PRIMARY KEY not null,
    title UUID             not null,
    text  UUID             not null,
    name  varchar(30)      not null,
    parts int              not null
)

CREATE TABLE Novel
(
    id             uuid primary key not null,
    part           int              not null,
    Dialog         text             not null,
    interlocutor   varchar(30)      not null,
    id_planet_info uuid             not null,

    constraint fk_id_planet_info foreign key (id_planet_info) REFERENCES planet_info (id) on delete cascade
);
