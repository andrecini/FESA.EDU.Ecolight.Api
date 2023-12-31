﻿using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data;
using Treinamento.REST.Domain.Entities.Auth;
using Treinamento.REST.Domain.Entities.Users;
using Treinamento.REST.Domain.Enums;
using Treinamento.REST.Domain.Interfaces.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace Treinamento.REST.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<User> GetUsers(int skip, int pageSize)
        {
            var sql = $@"SELECT
                            Id as Id,
                            Username as Username,
                            Email as Email,
                            User_Password as Password,
                            Number as Celular,
                            Cpf as Cpf,
                            Uf as Uf,
                            User_Role as Role,
                            Active as Active,
                            Company_Id as EmpresaId
                         FROM dbo.Users
                         ORDER BY Id
                         OFFSET @Skip
                         ROWS
                         FETCH NEXT @PageSize
                         ROWS ONLY;";

            var users = _dbConnection.Query<User>(sql, new { Skip = skip, PageSize = pageSize});

            return users;
        }
        public int GetTotalAmountOfUsers()
        {
            var sql = $@"SELECT COUNT(*) FROM dbo.Users";

            var total = _dbConnection.QueryFirst<int>(sql);

            return total;
        }

        public User GetUserById(int id)
        {
            var sql = $@"SELECT                          
                            Id as Id,
                            Username as Username,
                            Email as Email,
                            User_Password as Password,
                            Number as Celular,
                            Cpf as Cpf,
                            Uf as Uf,
                            User_Role as Role,
                            Active as Active,
                            Company_Id as EmpresaId
                         FROM dbo.Users WHERE Id = @Id;";

            var user = _dbConnection.QueryFirstOrDefault<User>(sql, new { Id = id });

            return user;
        }

        public User AddUser(User user)
        {
            var sql = $@"INSERT INTO dbo.Users
                         (
                            Username,
                            Email,
                            User_Password,
                            Number,
                            Cpf,
                            Uf,
                            User_Role,
                            Active,
                            Company_Id
                         )
                         OUTPUT INSERTED.Id
                         VALUES
                         (
                            @Username,
                            @Email,
                            @Password,
                            @Celular,
                            @Cpf,
                            @Uf,
                            @Role,
                            @Active,
                            @EmpresaId
                         );";

            var newId = _dbConnection.QuerySingle<int>(sql, user);
            
            var newUser = GetUserById(newId);

            return newUser;
        }

        public User UpdateUser(User user)
        {
            var sql = $@"UPDATE dbo.Users
                 SET
                    Number = @Celular,
                    Email = @Email,
                    User_Password = @Password
                 OUTPUT INSERTED.Id
                 WHERE
                    Id = @Id;";

            var Id = _dbConnection.QuerySingle<int>(sql, user);

            return GetUserById(Id);
        }


        public bool DeleteUserById(int Id)
        {
            var sql = "DELETE FROM dbo.Users WHERE Id = @Id";

            var qtdLinhasAfetadas = _dbConnection.Execute(sql, new { Id = Id });

            return qtdLinhasAfetadas > 0;
        }

        public User UpdateUserRole(int Id, Roles role)
        {
            var sql = $@"UPDATE dbo.Users
                         SET
                            User_Role = @Role
                         WHERE
                            Id = @Id;";

            var qtdLinhasAfetadas = _dbConnection.Execute(sql, new { Role = role, Id = Id});

            var userUpdated = GetUserById(Id);

            return userUpdated;
        }

        public User UpdateUserStatus(int Id, UserStatus status)
        {
            var sql = $@"UPDATE dbo.Users
                         SET
                            Active = @Status
                         WHERE
                            Id = @Id;";

            var qtdLinhasAfetadas = _dbConnection.Execute(sql, new { Status = status, Id = Id });

            var userUpdated = GetUserById(Id);

            return userUpdated;
        }

        public Authentication VerifyUser(string email)
        {
            var sql = $@"SELECT                          
                            Id as Id,
                            Username as Username,
                            Email as Email,
                            User_Password as Password,
                            Number as Celular,
                            Cpf as Cpf,
                            Uf as Uf,
                            User_Role as Role,
                            Active as Active,
                            Company_Id as EmpresaId
                            FROM dbo.Users 
                            WHERE Email = @email;";

            var auth = _dbConnection.QueryFirstOrDefault<Authentication>(sql, new { email = email});

            return auth;
        }

    }
}
