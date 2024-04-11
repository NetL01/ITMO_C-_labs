using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type user_role as enum
        (
            'admin',
            'user'
        );

        create type result as enum
        (
            'success',
            'fail'
        );

        create table users
        (
            user_id bigint primary key generated always as identity ,
            user_name text not null ,
            user_role user_role not null 
        );

        create table bank_account
        (
            bank_account_id bigint primary key generated always as identity,
            user_id bigint not null references users(user_id),
            amount bigint,
            number text not null,
            password text not null
        );

        create table history
        (
            operation_id bigint primary key generated always as identity,
            user_id bigint not null references users(user_id),
            bank_account_id bigint not null references bank_account(bank_account_id),
            action text not null,
            result result not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
            drop table users;
            drop table bank_account;
            drop table history;
        
            drop type result;
            drop type user_role;
        """;
}