﻿using CryptidCartographer.Models;
using System.Collections.Generic;

namespace CryptidCartographer.Repositories
{
    public interface ICryptidRepository
    {
        void Add(Cryptid cryptid);
        void Update(Cryptid cryptid);
        void Delete(int id);
        bool IsCryptidTrackedByUser(int userId, int cryptidId);
        List<Cryptid> GetAll();
        List<Cryptid> GetAllUserTrackedCryptids(int userId);
        List<Cryptid> GetCryptidByStateName(string name);
        List<Cryptid> GetCryptidByClassification(int id);
        List<Cryptid> GetCryptidSightingByUserId(int id);
        Cryptid GetCryptidById(int id);

    }
}