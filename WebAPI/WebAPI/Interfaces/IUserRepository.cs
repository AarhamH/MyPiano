﻿using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IUserRepository
    {
        UserModel Build(UserModel user);
    }
}